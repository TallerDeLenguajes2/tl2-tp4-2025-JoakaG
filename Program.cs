var builder = WebApplication.CreateBuilder(args);

var accesoDatosCsv = new AccesoADatosCSV();
var cadeteria = accesoDatosCsv.CargarDatos("src/cadeteria.csv"); 

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.MapControllers();
app.Run();
