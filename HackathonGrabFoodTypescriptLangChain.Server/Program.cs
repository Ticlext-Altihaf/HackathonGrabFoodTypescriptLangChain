using System.Net.Mime;
using System.Reflection;
using System.Text.Json;
using HackathonGrabFoodTypescriptLangChain.Server.Properties;
using HackathonGrabFoodTypescriptLangChain.Server.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();
builder.Services.Configure<Configuration>(builder.Configuration);
builder.Services.AddSingleton<IChatSessionService, InMemoryChatSessionService>();
builder.Services.AddSingleton<IChatService, StubChatService>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "HackathonGrabFoodTypescriptLangChain.Server",
        Description = "Cool API",
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseExceptionHandler(exceptionHandlerApp =>
{
    exceptionHandlerApp.Run(async context =>
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        // using static System.Net.Mime.MediaTypeNames;
        context.Response.ContentType = MediaTypeNames.Application.Json;


        var exceptionHandlerPathFeature =
            context.Features.Get<IExceptionHandlerFeature>();

        if (exceptionHandlerPathFeature?.Error is ArgumentException)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsync(JsonSerializer.Serialize(new
                {message = exceptionHandlerPathFeature.Error.Message}));
        }
    });
});

app.UseAuthorization();

app.MapControllers();

app.Run();