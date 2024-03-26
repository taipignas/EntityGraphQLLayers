using EntityGraphQL;
using EntityGraphQL.Schema;
using EntityGraphQL.Schema.FieldExtensions;
using EntityGraphQLLayers.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EntityGraphQLLayers
{
    public class GraphQLFunctions
    {
        private readonly ILogger<GraphQLFunctions> _logger;
        private readonly DocumentDbContext _ctx;

        public GraphQLFunctions(ILogger<GraphQLFunctions> logger, DocumentDbContext ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        private SchemaProvider<DocumentDbContext> GetSchema()
        {
            var schemaBuilderOptions = new SchemaBuilderOptions();
            schemaBuilderOptions.OnFieldCreated = (field) =>
            {
                if (field.ReturnType.IsList && field.ReturnType.SchemaType.GqlType == GqlTypes.QueryObject && !field.FromType.IsInterface)
                {
                    field.UseFilter();
                    field.UseSort();
                    field.UseOffsetPaging();
                }
            };

            var schema = SchemaBuilder.FromObject<DocumentDbContext>(schemaBuilderOptions);
            return schema;
        }

        [Function("GraphQL")]
        public async Task<IActionResult> GraphQL([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "graphql")] HttpRequest req)
        {
            DbSeed.Seed(_ctx);
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var query = JsonConvert.DeserializeObject<QueryRequest>(requestBody);

            var schema = GetSchema();
            schema.AddCustomTypeConverter(new JObjectTypeConverter());
            schema.AddCustomTypeConverter(new JTokenTypeConverter());
            schema.AddCustomTypeConverter(new JValueTypeConverter());

            var results = await schema.ExecuteRequestWithContextAsync(query, _ctx, null, null);

            return new OkObjectResult(JsonConvert.SerializeObject(results));
        }

        [Function("schema")]
        public async Task<IActionResult> Schema([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "schema")] HttpRequest req)
        {
            var schema = GetSchema();
            var schemaString = schema.ToGraphQLSchemaString();

            return new OkObjectResult(schemaString);
        }
    }
}
