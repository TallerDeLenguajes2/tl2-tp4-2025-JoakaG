using System.Text.Json;

public class AccesoADatosCadetes
{
    public List<Cadetes> CargarDatos()
    {
        string archivoJson = "src/cadetes.json";
        if (!File.Exists(archivoJson))
            return new List<Cadetes>();
        string json = File.ReadAllText(archivoJson);
        return JsonSerializer.Deserialize<List<Cadetes>>(json) ?? new List<Cadetes>();
    }

    public void GuardarDatos(List<Cadetes> datos)
    {
        string archivoJson = "src/cadetes.json";
        string json = JsonSerializer.Serialize(datos, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(archivoJson, json);
    }

}