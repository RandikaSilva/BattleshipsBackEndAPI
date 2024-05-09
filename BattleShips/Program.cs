using BattleShips.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddMemoryCache();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register BoardService as a scoped service
builder.Services.AddScoped<BoardService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy =>
{
    policy.WithOrigins("http://localhost:3000")
          .AllowAnyMethod()
          .AllowAnyHeader()
          .AllowCredentials();
});

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
