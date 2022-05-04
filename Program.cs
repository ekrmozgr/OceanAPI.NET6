using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OceanAPI.NET6.Data;
using OceanAPI.NET6.Repositories;
using OceanAPI.NET6.Services;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options=>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});

// authentication - authorization

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options=>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
builder.Services.AddAuthorization();

// database configuration
builder.Services.AddDbContext<DatabaseContext>(
                opt => opt.UseSqlServer(
                    builder.Configuration.GetConnectionString("DatabaseConnection")
                    )
                );

// repository
builder.Services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
builder.Services.AddScoped(typeof(IBasketRepository), typeof(BasketRepository));
builder.Services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
builder.Services.AddScoped(typeof(IFaqRepository), typeof(FaqRepository));
builder.Services.AddScoped(typeof(ICompanyContactRepository), typeof(CompanyContactRepository));
builder.Services.AddScoped(typeof(IEnumRepository<>), typeof(EnumRepository<>));
builder.Services.AddScoped(typeof(ICommentsRepository), typeof(CommentsRepository));
builder.Services.AddScoped(typeof(IFavouritesRepository),typeof(FavouritesRepository));

// services
builder.Services.AddScoped<ILoginService,LoginManager>();
builder.Services.AddScoped<IBasketService, BasketManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IBasketTransactionService, BasketTransactionManager>();
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IInfoService, InfoManager>();
builder.Services.AddScoped<IEnumService, EnumManager>();
builder.Services.AddScoped<ICommentsService, CommentsManager>();
builder.Services.AddScoped<IFavouritesService, FavouritesManager>();

// automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// ignore json cycles

builder.Services.AddControllersWithViews().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// modelstate valid control

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = false;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
