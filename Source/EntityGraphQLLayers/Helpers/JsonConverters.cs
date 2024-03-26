using EntityGraphQL.Schema;
using Newtonsoft.Json.Linq;

namespace EntityGraphQLLayers.Helpers
{
    internal class JObjectTypeConverter : ICustomTypeConverter
    {
        public Type Type => typeof(JObject);

        public object ChangeType(object value, Type toType, ISchemaProvider schema)
        {
            return ((JObject)value).ToObject(toType);
        }
    }

    internal class JTokenTypeConverter : ICustomTypeConverter
    {
        public Type Type => typeof(JToken);

        public object ChangeType(object value, Type toType, ISchemaProvider schema)
        {
            return ((JToken)value).ToObject(toType);
        }
    }

    internal class JValueTypeConverter : ICustomTypeConverter
    {
        public Type Type => typeof(JValue);

        public object ChangeType(object value, Type toType, ISchemaProvider schema)
        {
            return ((JValue)value).ToString();
        }
    }
}
