using hack4good.BLL;
using hack4good.Infrastructure;
using hack4good.Web;
using hack4good.Web.Middlewares;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder();

builder.Services.AddCors();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.Configure();
});
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "hack4good API",
        Description = "hack4good API"
    });
});

builder.Services.AddDb(builder.Configuration);
builder.Services.AddBLL();
// ---

var app = builder.Build();

await app.Services.MigrateDb();

if (!builder.Environment.IsProduction())
{
    app.UseSwagger(options =>
    {
        options.RouteTemplate = "swagger/{documentName}/swagger.json";
        options.PreSerializeFilters.Add((swaggerDoc, httpReq) => swaggerDoc.Servers = new List<OpenApiServer>
        {
            new() { Url = $"https://{httpReq.Host.Value}/api" }
        });
    });
    app.UseSwaggerUI();
}

app.UseCors(policyBuilder => policyBuilder.AllowAnyOrigin());

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseMiddleware<ExceptionCatcherMiddleware>();

app.UseRouting();

app.MapControllers();

app.Run();