using ClienteAPI.Data;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Prometheus;
using HealthChecks.UI.Client;

AppContext.SetSwitch("Microsoft.EntityFrameworkCore.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

// Configurar DbContext con SQL Server
builder.Services.AddDbContext<BdClientesContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("ClienteDB")));

// Agregar controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar HealthChecks con SQL Server
builder.Services.AddHealthChecks()
    .AddSqlServer(builder.Configuration.GetConnectionString("ClienteDB"), name: "sqlserver")
    .ForwardToPrometheus(); // Reemplazo para ForwardHealthChecksToPrometheus

var app = builder.Build();

// Exponer métricas Prometheus en /metrics
app.UseMetricServer();
// Recolectar métricas HTTP automáticamente
app.UseHttpMetrics();

// Swagger UI para documentación
app.UseSwagger();
app.UseSwaggerUI();

// Redirigir HTTP a HTTPS (descomentar para producción)
// app.UseHttpsRedirection();

app.UseAuthorization();

// Mapear endpoints API
app.MapControllers();

// Endpoint health checks en formato Prometheus para monitoreo
app.MapHealthChecks("/healthz", new HealthCheckOptions
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse // Reemplazo para PrometheusHealthCheckResponseWriter
});

app.Run();