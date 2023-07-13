using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EgitimSistemi.BusinessLayer.Abstract;
using EgitimSistemi.BusinessLayer.Concrete;
using EgitimSistemi.DataAccessLayer.Abstract;
using EgitimSistemi.DataAccessLayer.Concrete;
using EgitimSistemi.DataAccessLayer.EntityFramework;
using EgitimSistemi.DataAccessLayer.Repositories;
using EgitimSistemi.BusinessLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<IOgrenciDal, EfOgrenciDal>();
builder.Services.AddScoped<IOgrenciService, OgrenciMenager>();
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

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "YourProject v1"));
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("EgitimApiCors");

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
