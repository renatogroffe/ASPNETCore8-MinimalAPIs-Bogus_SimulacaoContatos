using APIContatos.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ContatosRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapGet("/contatos", (ContatosRepository repository) =>
{
    var data = repository.GetAll();
    app.Logger.LogInformation($"No. de registros encontrados: {data.Count()}");
    return data;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();