using ZenDriver.API.DriverProfile.Services;
using ZenDriver.API.Security.Authorization.Handlers.Implementations;
using ZenDriver.API.Security.Authorization.Handlers.Interfaces;
using ZenDriver.API.Security.Authorization.Middleware;
using ZenDriver.API.Security.Authorization.Settings;
using ZenDriver.API.Security.Domain.Repositories;
using ZenDriver.API.Security.Domain.Services;
using ZenDriver.API.Security.Persistence.Repositories;
using ZenDriver.API.Security.Services;
using ZenDriver.API.Shared.Domain.Repositories;
using ZenDriver.API.Shared.Persistence.Contexts;
using ZenDriver.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using ZenDriver.API.ApplyForJob.Domain.Repositories;
using ZenDriver.API.ApplyForJob.Domain.Services;
using ZenDriver.API.ApplyForJob.Persistence.Repositories;
using ZenDriver.API.ApplyForJob.Services;
using ZenDriver.API.DriverProfile.Domain.Models.Persistence.Repositories;
using ZenDriver.API.DriverProfile.Domain.Repositories;
using ZenDriver.API.DriverProfile.Domain.Services;
using ZenDriver.API.DriverProfile.Persistence.Repositories;
using ZenDriver.API.DriverProfile.Services;
using ZenDriver.API.Message.Domain.Repositories;
using ZenDriver.API.Message.Domain.Services;
using ZenDriver.API.Message.Persistence.Repositories;
using ZenDriver.API.Message.Services;
using ZenDriver.API.Notification.Domain.Repositories;
using ZenDriver.API.Notification.Domain.Services;
using ZenDriver.API.Notification.Persistence.Repositories;
using ZenDriver.API.Notification.Services;
using ZenDriver.API.Settings.Domain.Repositories;
using ZenDriver.API.Settings.Domain.Services;
using ZenDriver.API.Settings.Persistence.Repositories;
using ZenDriver.API.Settings.Services;
using ZenDriver.API.SocialNetworking.Domain.Repositories;
using ZenDriver.API.SocialNetworking.Domain.Services;
using ZenDriver.API.SocialNetworking.Persistence.Repositories;
using ZenDriver.API.SocialNetworking.Services;


var builder = WebApplication.CreateBuilder(args);

// Add CORS
builder.Services.AddCors();

//Add services to the container
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//AppSettings Configuration
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddSwaggerGen(options =>
{
    //Add API Documentation Information

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "INNOVAMIND Center API",
        Description = "INNOVAMIND Center API RESTful API",
        TermsOfService = new Uri("https://innova-mind.com/tos"),
        Contact = new OpenApiContact
        {
            Name = "INNOVAMIND.studio",
            Url = new Uri ("https://acme.studio")
        },
        License = new OpenApiLicense
        {
            Name = "INNOVAMIND Learning Center Resources License",
            Url = new Uri("https://innova-mind.com/license")
        }
    });
    options.EnableAnnotations();
    options.AddSecurityDefinition("bearearAuth", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Description = "JWT Authorization header using the Bearer Scheme"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearearAuth"}
            },
            Array.Empty<string>()
        }
    });
});



// Add Database Connection

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
    .LogTo(Console.WriteLine, LogLevel.Information)
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors());

//Add lowecase routes

builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Dependency Injection Configuration

//Shared Injection Configuration

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


// InnovaMind Injection Configuration
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
//builder.Services.AddScoped<IPostRepository, PostRepository>();
//builder.Services.AddScoped<IPostService, PostService>();
// builder.Services.AddScoped<IRecruiterRepository, RecruiterRepository>();
// builder.Services.AddScoped<IRecruiterService, RecruiterService>();
builder.Services.AddScoped<IDriverprofileService, DriverprofileService>();
builder.Services.AddScoped<IDriverprofileRepository, DriverprofileRepository>();
builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddScoped<ILicenseRepository, LicenseRepository>();
builder.Services.AddScoped<ILicenseService, LicenseService>();

builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();

builder.Services.AddScoped<IEducationRepository, EducationRepository>();
builder.Services.AddScoped<IEducationService, EducationService>();
builder.Services.AddScoped<ISchoolRepository, SchoolRepository>();
builder.Services.AddScoped<ISchoolService, SchoolService>();
builder.Services.AddScoped<ISocialNetworkRepository, SocialNetworkRepository>();
builder.Services.AddScoped<ISocialNetworkService, SocialNetworkService>();






// Security Injection Configuration

builder.Services.AddScoped<IJwtHandler, JwtHandler>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();


//AutoMapper Configuration

builder.Services.AddAutoMapper(
    typeof(ZenDriver.API.Security.Mapping.ModelToResourceProfile),
    typeof(ZenDriver.API.Security.Mapping.ResourceToModelProfile),
    typeof(ZenDriver.API.DriverProfile.Mapping.ModelToResourceProfile),
    typeof(ZenDriver.API.DriverProfile.Mapping.ResourceToModelProfile),
    typeof(ZenDriver.API.SocialNetworking.Mapping.ModelToResourceProfile),
    typeof(ZenDriver.API.SocialNetworking.Mapping.ResourceToModelProfile),
    typeof(ZenDriver.API.Settings.Mapping.ResourceToModelProfile),
    typeof(ZenDriver.API.Settings.Mapping.ModelToResourceProfile),
    typeof(ZenDriver.API.ApplyForJob.Mapping.ModelToResourceProfile),
    typeof(ZenDriver.API.ApplyForJob.Mapping.ResourceToModelProfile),
    typeof(ZenDriver.API.Message.Mapping.ModelToResourceProfile),
    typeof(ZenDriver.API.Message.Mapping.ResourceToModelProfile),
    typeof(ZenDriver.API.Notification.Mapping.ModelToResourceProfile),
    typeof(ZenDriver.API.Notification.Mapping.ResourceToModelProfile)
    
);

var app = builder.Build();

// Validation for ensuring Database Objects are created
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("v1/swagger.json", "v1");
        options.RoutePrefix = "swagger";
        //Added To View the tags in swagger
        options.DisplayOperationId();
    });


// Configure CORS
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);

//Configure Error Handler Middleware
app.UseMiddleware<ErrorHandlerMiddleware>();

//Configure JWT Handling
app.UseMiddleware<JwtMiddleware>();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
