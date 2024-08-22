var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres")
    .WithDataVolume();
var postgresdb = postgres.AddDatabase("postgresdb");

var redis = builder.AddRedis("redis")
    .WithDataVolume();

var elasticsearch = builder.AddElasticsearch("elasticsearch")
    .WithDataVolume();

var flowCmsBack = builder.AddProject<Projects.FlowCms_WebApi>("flowcms-webapi")
    .WithReference(elasticsearch)
    .WithReference(postgresdb)
    .WithReference(redis);

builder.AddNpmApp("vue", "../FlowCms.App")
    .WithReference(flowCmsBack)
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.Build().Run();