using Microsoft.EntityFrameworkCore;
using social_api.Contexts;

var connectionString = "server=localhost;user=root;password=12345678;database=dev_ecommerce";
var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
{
  options.UseMySql(connectionString, serverVersion);
  options.EnableDetailedErrors();
  options.UseSnakeCaseNamingConvention();
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
app.Run();
