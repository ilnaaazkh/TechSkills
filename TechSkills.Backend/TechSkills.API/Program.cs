using Microsoft.EntityFrameworkCore;
using TechSkills.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TechSkillsDbContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(TechSkillsDbContext)));
    });

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(x =>
    {
        x.WithHeaders().AllowAnyHeader();
        x.WithOrigins("http://localhost:3000");
        x.WithMethods().AllowAnyMethod();
    });

app.Run();