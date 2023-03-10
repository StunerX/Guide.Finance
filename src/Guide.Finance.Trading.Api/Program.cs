using Guide.Finance.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddConnectionProvider(builder.Configuration);
// Add services to the container.
builder.Services.AddRepositories();
builder.Services.AddIntegrators();
builder.Services.AddUseCases();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program {}