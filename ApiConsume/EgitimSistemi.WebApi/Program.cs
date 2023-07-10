using EgitimSistemi.BusinessLayer.Abstract;
using EgitimSistemi.BusinessLayer.Concrete;
using EgitimSistemi.DataAccessLayer.Abstract;
using EgitimSistemi.DataAccessLayer.Concrete;
using EgitimSistemi.DataAccessLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<IOgrenciDal, EfOgrenciDal>();
builder.Services.AddScoped<IOgrenciService, OgrenciMenager>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
