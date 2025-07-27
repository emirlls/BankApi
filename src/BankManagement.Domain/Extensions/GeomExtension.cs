using System.IO;
using System.Threading.Tasks;
using NetTopologySuite.Features;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BankManagement.Extensions;

public static class GeomExtension
{
    public static async Task<string> ConvertGeomToGeoJson(this Geometry? geometry)
    {
        var feature = new Feature(geometry, new AttributesTable());
        var featureCollection = new FeatureCollection { feature };

        var serializer = GeoJsonSerializer.Create();
        await using var stringWriter = new StringWriter();
        await using var jsonWriter = new JsonTextWriter(stringWriter);

        serializer.Serialize(jsonWriter, featureCollection);
        return stringWriter.ToString();
    }
    
    public static Geometry? ConvertGeoJsonToGeometry(this string geoJson)
    {
        var jObject = JObject.Parse(geoJson);
        var geometryJson = jObject["features"]?[0]?["geometry"]?.ToString();

        if (geometryJson == null)
        {
            return null;
        }

        var reader = new GeoJsonReader();
        var geom = reader.Read<Geometry>(geometryJson);
        return geom;
    }

}