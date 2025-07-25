using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using BankManagement.Constants;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using Volo.Abp.DependencyInjection;

namespace BankManagement.Repositories.ElasticSearchs;

public class ElasticSearchRepository<T, TKey> : IElasticSearchRepository<T, TKey>, ITransientDependency
    where T : class
{
    private readonly Lazy<Task<ElasticClient>> _clientLazy;
    public ElasticClient Client => _clientLazy.Value.GetAwaiter().GetResult();

    public ElasticSearchRepository(IServiceProvider serviceProvider)
    {
        _clientLazy = new Lazy<Task<ElasticClient>>(async () =>
        {
            var client = await GetClientAsync(serviceProvider);
            return client;
        });
    }

    private async Task<ElasticClient> GetClientAsync(IServiceProvider serviceProvider)
    {
        return serviceProvider.GetRequiredService<ElasticClient>();
    }

    public async Task<bool> CreateIndexAsync(
        string indexName = ElasticSearchConstants.DefaultIndex,
        CancellationToken cancellationToken = default
    )
    {
        var indexExistsRequest = new IndexExistsRequest(indexName);
        var existsResponse = await Client.Indices.ExistsAsync(indexExistsRequest, cancellationToken);

        if (!existsResponse.Exists)
        {
            var createResponse = await Client.Indices.CreateAsync(indexName, ct: cancellationToken);
            return createResponse.IsValid;
        }

        return existsResponse.Exists;
    }

    public async Task<CreateResponse> CreateDocumentAsync(
        T document,
        string indexName = ElasticSearchConstants.DefaultIndex,
        CancellationToken cancellationToken = default
    )
    {
        CreateRequest<T> createRequest = new(
            indexName,
            document.GetType().GetProperty(ElasticSearchConstants.IdPropertyName)?.GetValue(document)!.ToString())
        {
            Document = document
        };

        var response = await Client.CreateAsync(createRequest, cancellationToken);
        return response;
    }

    public async Task<BulkResponse> BulkCreateDocumentsAsync(
        IEnumerable<T> documents,
        string indexName = ElasticSearchConstants.DefaultIndex,
        CancellationToken cancellationToken = default
    )
    {
        var response = await Client.BulkAsync(b =>
            b.Index(indexName)
                .IndexMany(documents), cancellationToken);
        return response;
    }

    public async Task<BulkResponse> BulkDeleteDocumentsAsync(
        IEnumerable<T> documents,
        string indexName = ElasticSearchConstants.DefaultIndex,
        CancellationToken cancellationToken = default
    )
    {
        var response = await Client.BulkAsync(b =>
        {
            b.Index(indexName);

            foreach (var document in documents)
            {
                b.Delete<T>(d => d
                    .Index(indexName)
                    .Document(document)
                );
            }

            return b;
        }, cancellationToken);

        return response;
    }

    public async Task<DeleteResponse> DeleteDocumentAsync(
        TKey id,
        string indexName = ElasticSearchConstants.DefaultIndex,
        CancellationToken cancellationToken = default
    )
    {
        var response = await Client.DeleteAsync<T>(id!.ToString(), d => d
            .Index(indexName), cancellationToken);
        return response;
    }

    public async Task ClearIndexAsync<TModel>(string indexName, CancellationToken cancellationToken)
        where TModel : class
    {
        await Client.DeleteByQueryAsync<TModel>(q =>
            q.Index(indexName)
                .Query(q => q.MatchAll()), cancellationToken);
    }

    public async Task<long> CountDocumentsAsync(
        string indexName = ElasticSearchConstants.DefaultIndex,
        CancellationToken cancellationToken = default
    )
    {
        var countResponse = await Client.CountAsync<T>(c => c
                .Index(indexName), cancellationToken
        );

        return countResponse.Count;
    }

    public async Task<IReadOnlyCollection<T>> GetDocumentsAsync(string indexName = ElasticSearchConstants.DefaultIndex,
        CancellationToken cancellationToken = default)
    {
        var response = await Client.SearchAsync<T>(s => s
            .Index(indexName)
            .Query(q => q.MatchAll()), cancellationToken);

        return response.Documents;
    }

    public async Task<T?> GetDocumentAsync(TKey id, string indexName = ElasticSearchConstants.DefaultIndex,
        CancellationToken cancellationToken = default)
    {
        var response = await Client.GetAsync<T>(id!.ToString(), g => g
            .Index(indexName), cancellationToken);

        return response.Found ? response.Source : default;
    }

    public async Task<IReadOnlyCollection<T>> SearchAsync(
        string indexName = ElasticSearchConstants.DefaultIndex,
        Func<QueryContainerDescriptor<T>, QueryContainer>? queryDescriptor = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await Client.SearchAsync<T>(s => s
                .Index(indexName)
                .Size(ElasticSearchConstants.ElasticPageSize)
                .Query(q => queryDescriptor != null ? queryDescriptor(q) : q.MatchAll()),
            cancellationToken);

        return response.Documents;
    }

    public async Task<IReadOnlyCollection<TModel>> GetCreationTimeFilteredBetweenAsync<TModel>(
        DateTime startDate,
        DateTime endDate,
        string indexName,
        Expression<Func<TModel, object>> expression,
        CancellationToken cancellationToken
    )
        where TModel : class
    {
        var dateColumnName = string.Empty;
        if (expression.Body is MemberExpression memberExpression)
        {
            dateColumnName = memberExpression.Member.Name;
        }

        var response = await Client.SearchAsync<TModel>(s => s
                .Index(indexName)
                .Query(q => q
                    .DateRange(dr => dr
                        .Field(dateColumnName)
                        .GreaterThanOrEquals(startDate)
                        .LessThanOrEquals(endDate)
                    )
                )
                .Size(ElasticSearchConstants.ElasticPageSize),
            cancellationToken);

        return response.Documents;
    }
}