using System.Text.Json;
public class AccesoADatosCadeteria
{
    public List<Cadeteria> CargarDatos()
    {
        string archivoJson = "src/cadeteria.json";
        if (!File.Exists(archivoJson))
            return new List<Cadeteria>();

        string json = File.ReadAllText(archivoJson);
        return JsonSerializer.Deserialize<List<Cadeteria>>(json) ?? new List<Cadeteria>();
    }

    // public void GuardarDatos(string archivoJson, List<Cadeteria> datos)
    // {
    //     string json = JsonSerializer.Serialize(datos, new JsonSerializerOptions { WriteIndented = true });
    //     File.WriteAllText(archivoJson, json);
    // }

    // public void GuardarDato(string archivoJson, Cadeteria dato)
    // {
    //     var listaCadeteria = CargarDatos(archivoJson);
    //     listaCadeteria.Add(dato);
    //     string json = JsonSerializer.Serialize(listaCadeteria, new JsonSerializerOptions { WriteIndented = true });
    //     File.WriteAllText(archivoJson, json);
    // }
}
