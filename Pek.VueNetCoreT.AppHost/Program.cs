var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Pek_VueNetCoreT_Server>("pek-vuenetcoret-server");

builder.Build().Run();
