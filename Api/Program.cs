using Api.Interfaces;
using Api.Services;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services);

// Add services to the container.
builder.Services.AddCors(options => {
  options.AddDefaultPolicy(
    policy => policy.WithOrigins("http://localhost:5014").AllowAnyMethod().AllowCredentials().AllowAnyHeader());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment()){
  app.UseSwagger();
  app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

void ConfigureServices(IServiceCollection services) {
  services.AddSingleton<IEquationService, EquationService>();
}

app.Run();
