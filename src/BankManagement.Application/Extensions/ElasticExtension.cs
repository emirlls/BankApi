using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BankManagement.Repositories.ElasticSearchs;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using Volo.Abp.Domain.Entities;
using IObjectMapper = Volo.Abp.ObjectMapping.IObjectMapper;

namespace BankManagement.Extensions;

public static class ElasticExtension
{
    /// <summary>
    /// The generic method used to map to elastic model and index the entities in the database.
    /// </summary>
    /// <param name="serviceProvider"></param>
    /// <param name="repository"></param>
    /// <param name="indexName"></param>
    /// <param name="clearDatabase"></param>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TModel"></typeparam>
    public static async Task LogModelsToElasticAsync<TEntity, TModel>(
        this IServiceProvider serviceProvider,
        Volo.Abp.Domain.Repositories.IRepository<TEntity> repository,
        string indexName,
        bool clearDatabase = false
    )
        where TEntity : class, IEntity
        where TModel : class
    {
        var elasticClient = serviceProvider.GetRequiredService<ElasticClient>();
        var entities = await repository.GetListAsync();
        var objectMapper = serviceProvider.GetRequiredService<IObjectMapper>();
        var elasticModel = objectMapper.Map<List<TEntity>, List<TModel>>(entities);

        await elasticClient.IndexManyAsync(elasticModel,
            indexName);
        if (clearDatabase)
        {
            await repository.DeleteManyAsync(entities);
        }
    }

    /// <summary>
    /// The generic method used to map to elastic model and create document.
    /// </summary>
    /// <param name="serviceProvider"></param>
    /// <param name="model"></param>
    /// <param name="indexName"></param>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TModel"></typeparam>
    public static async Task LogModelToElasticAsync<TEventModel, TModel>(
        this IServiceProvider serviceProvider,
        TEventModel model,
        string indexName
    )
        where TEventModel : class
        where TModel : class
    {
        var elasticSearchRepository = serviceProvider.GetRequiredService<IElasticSearchRepository<TModel,Guid>>();
        var objectMapper = serviceProvider.GetRequiredService<IObjectMapper>();
        var elasticModel = objectMapper.Map<TEventModel,TModel>(model);
        await elasticSearchRepository.CreateDocumentAsync(elasticModel, indexName);
    }
}