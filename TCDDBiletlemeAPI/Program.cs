using TCDDBiletlemeAPI.Models;
using TCDDBiletlemeAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// mongodb settings 
builder.Services.Configure<MongoDBSetting>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton<MongoDBServices>();


// Add services to the container.

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
