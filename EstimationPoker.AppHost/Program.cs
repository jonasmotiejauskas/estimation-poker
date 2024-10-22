var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres");

var postgresdb = postgres.AddDatabase("postgresdb");

var apiService = builder.AddProject<Projects.EstimationPoker_ApiService>("apiservice")
    .WithReference(postgresdb);

builder.AddProject<Projects.EstimationPoker_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
