using Microsoft.OpenApi.Models;
using System.Globalization;

var culture = new CultureInfo("en-Us");
culture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
culture.DateTimeFormat.LongTimePattern = "HH:mm:ss";
culture.DateTimeFormat.DateSeparator = "/";
culture.DateTimeFormat.TimeSeparator = ":";

culture.NumberFormat.NumberDecimalSeparator = ".";
culture.NumberFormat.NumberGroupSeparator = ",";
culture.NumberFormat.CurrencyGroupSeparator = ",";
culture.NumberFormat.CurrencySymbol = "";
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

var servicename = "Gateway";

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = $"{servicename} WebApi",
        Description = $"TCCPOS Backend {servicename} WebApi"
    });

    x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    x.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });

});

builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("ReverseProxy")); // add YARP

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(x =>
{
    x.RoutePrefix = string.Empty;
    x.SwaggerEndpoint("securityswagger/v1/swagger.json", "Security API (v1)");
    x.SwaggerEndpoint("saleswagger/v1/swagger.json", "Sale API (v1)");
    x.SwaggerEndpoint("reportswagger/v1/swagger.json", "Report API (v1)");
    x.SwaggerEndpoint("inventoryswagger/v1/swagger.json", "Inventory API (v1)");
    //x.SwaggerEndpoint("masterdataswagger/v1/swagger.json", "Master data API (v1)");
});

//app.UseHttpsRedirection();
//app.UseAuthorization();
//app.MapControllers();
app.MapReverseProxy();

app.Run();
