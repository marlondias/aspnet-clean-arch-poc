using CleanArchPOC.Adapters.Services;
using CleanArchPOC.Database.Contexts;
using CleanArchPOC.Domain.Contracts.Repository;
using CleanArchPOC.Domain.Contracts.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlite<MainContext>("Data Source=MainDatabase.db");
builder.Services.AddScoped<IUserCommandsRepository, UserRepository>();
builder.Services.AddScoped<IUserQueriesRepository, UserRepository>();

builder.Services.AddSingleton<IStringHashingService, StringHashingService>();

builder.Services.AddControllers();
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
