using System;
using System.Text;
using SuperTraders.Core.Mapper;
using SuperTraders.Data.Repositories;
using SuperTraders.Data.Repositories.Infrastructure;
using SuperTraders.Services;
using SuperTraders.Services.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SuperTraders.Data;
using SuperTraders.Presentation.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo {Title = "SuperTraders", Version = "v1", Description = "Lorem Ipsum Dolor Sit Amet :D"});
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "It's just Swagger AQ!",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            Array.Empty<string>()
        }
    });
});
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder => {
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}));
var configMapper = new AutoMapper.MapperConfiguration(cfg => {
    cfg.AddProfile(new MapperAuto());
});

var mapper = configMapper.CreateMapper();
builder.Services.AddSingleton(mapper);

// Dependency Injections
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IShareRepository, ShareRepository>();
builder.Services.AddTransient<ISellOrderRepository, SellOrderRepository>();
builder.Services.AddTransient<IBuyOrderRepository, BuyOrderRepository>();
builder.Services.AddTransient<ITransactionRepository, TransactionRepository>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IShareService, ShareService>();
builder.Services.AddTransient<IOrderService, OrderService>();

builder.Services.AddDbContextPool<ApplicationContext>(options =>
{
    options.UseNpgsql("User ID=eva;Password=12345678;Server=localhost;Port=5432;Database=super_traders;Integrated Security=true;Pooling=true;");
});

byte[] _tokenKey = Encoding.ASCII.GetBytes("adshjbsdkjbhfkjashfkjnjasklfjlas");
builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(_tokenKey),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
builder.Services.AddMvc().AddJsonOptions(options => {
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseCors("MyPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<AuthenticationMiddleware>();

app.MapControllers();

app.Run();