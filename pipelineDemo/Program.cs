var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

//Middlewear 1
app.Use(async(context, next) =>
{
    Console.WriteLine("Request Start");
    await next();
    Console.WriteLine("Respond End");
});

//Middlewear 2
app.Use(async(context, next) =>
{
    Console.WriteLine("Second Middlewear");
    await next();
});

app.MapGet("/", () => "Hello from Web API Pipeline");
app.Run();