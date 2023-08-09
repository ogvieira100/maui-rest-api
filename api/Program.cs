using Microsoft.EntityFrameworkCore;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using domain;
using data;
using api.Migration;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration; // allows both to access and to set up the config
IWebHostEnvironment environment = builder.Environment;

builder.Configuration.AddJsonFile("appsettings.json", true, true)
                    .SetBasePath(environment.ContentRootPath)
                    .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true, true)
                    .AddEnvironmentVariables();
;


// Add services to the container.
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{

    options.AddPolicy("Development",
          builder =>
              builder
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowAnyOrigin()
              ); // allow credentials

    options.AddPolicy("Production",
        builder =>
            builder
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowAnyOrigin()
              ); // allow credentials
});

#region  " Sql "

var connectionString = configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<data.AplicationpContext>(options =>
     options.UseSqlServer(connectionString)
     .EnableSensitiveDataLogging()
     .UseLazyLoadingProxies()
     );


#endregion

builder.Services.AddScoped<IClienteQuery, ClienteQuery>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IBaseConsultRepository<>), typeof(BaseConsultRepository<>));
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));


/*injeções*/

var culture = new CultureInfo("pt-BR");
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MigrateDatabase();

app.Run();
