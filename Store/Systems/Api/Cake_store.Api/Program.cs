using Cake_store.Api;
using Cake_store.Services.Settings;
using Cake_store.Context;
using Cake_store.Context.Seeder;
using Cake_store.Api.Configuration;
using Cake_store.Services.Logger;
using Cake_store.Settings;

var mainSettings = Settings.Load<MainSettings>("Main");
var logSettings = Settings.Load<LogSettings>("Log");
var swaggerSettings = Settings.Load<SwaggerSettings>("Swagger");
var identitySettings = Settings.Load<IdentitySettings>("Identity");

var builder = WebApplication.CreateBuilder(args);

builder.AddAppLogger(mainSettings, logSettings);


var services = builder.Services;

services.AddHttpContextAccessor();

services.AddAppDbContext(builder.Configuration);

services.AddAppCors();

services.AddAppHealthChecks();

services.AddAppVersioning();

services.AddAppSwagger(mainSettings, swaggerSettings, identitySettings);

services.AddAppAutoMappers();

services.AddAppValidator();

services.AddAppAuth(identitySettings);

services.AddAppControllerAndViews();

services.RegisterServises(builder.Configuration);



var app = builder.Build();

var logger = app.Services.GetRequiredService<IAppLogger>();

app.UseAppCors();

app.UseAppHealthChecks();

app.UseAppSwagger();

app.UseAppAuth();

app.UseAppControllerAndViews();

DbInitializer.Execute(app.Services);

DbSeeder.Execute(app.Services);

logger.Information("The DSRNetSchool.API has started");

app.Run();

logger.Information("The DSRNetSchool.API has stopped");
