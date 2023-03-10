using gRPC2.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGrpcReflection();
// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy(name: "grpcui",
//                       policy  =>
//                       {
//                           policy.WithOrigins("https://grpcui.dev/");
//                       });
// });

var app = builder.Build();
IWebHostEnvironment env = app.Environment;
if (env.IsDevelopment())
{
    app.MapGrpcReflectionService();
}
// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
