var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache")
    .WithRedisCommander();

var api = builder.AddProject<Projects.PlayedOff_Api>("backend")
    .WithReference(cache);

builder.AddProject<Projects.PlayedOff_Web>("frontend")
    .WithExternalHttpEndpoints()
    .WithReference(api);

builder.Build().Run();
