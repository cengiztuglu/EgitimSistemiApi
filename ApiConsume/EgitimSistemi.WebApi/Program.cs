using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using EgitimSistemi.BusinessLayer.Abstract;
using EgitimSistemi.BusinessLayer.Concrete;
using EgitimSistemi.DataAccessLayer.Abstract;
using EgitimSistemi.DataAccessLayer.Concrete;
using EgitimSistemi.DataAccessLayer.EntityFramework;
using EgitimSistemi.DataAccessLayer.Repositories;
using Microsoft.OpenApi.Models;
using System.Text;
using  Microsoft.IdentityModel.Tokens;


using EgitimSistemi.BusinessLayer;

var builder = WebApplication.CreateBuilder(args);

// Hizmetleri yap�land�r�n
builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<IOgrenciDal, EfOgrenciDal>();
builder.Services.AddScoped<IOgrenciService, OgrenciMenager>();
builder.Services.AddScoped<IAdminDal, EfAdminDal>();
builder.Services.AddScoped<IAdminService, AdminMenager>();
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<AdminLoginService>();
builder.Services.AddScoped<OgrenciLoginRepository>();
builder.Services.AddScoped<AdminLoginRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("EgitimApiCors", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

    // Yetkilendirme bilgilerini SwaggerUI'a ekleme
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new List<string>()
        }
    });
});

// JWT kimlik do�rulama ayarlar�n� yap�n
var jwtKey = Encoding.ASCII.GetBytes("super-admin-key-123");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(jwtKey)
        };
    });

var app = builder.Build();

// Ortam� yap�land�r�n
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// HTTPS y�nlendirmesini etkinle�tirin
app.UseHttpsRedirection();

// Routing'i yap�land�r�n
app.UseRouting();

// CORS politikalar�n� uygulay�n
app.UseCors("EgitimApiCors");

// Yetkilendirmeyi etkinle�tirin
app.UseAuthentication();
app.UseAuthorization();

// Endpoint'leri haritalay�n
app.MapControllers();

// SwaggerUI'y� etkinle�tirin
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API v1");
});

app.Run();
