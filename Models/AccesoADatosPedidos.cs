using System.Text.Json;
public class AccesoADatosPedidos
{

    public List<Pedidos> CargarDatos()
    {
        string archivoJson = "src/pedidos.json";
        if (!File.Exists(archivoJson))
            return new List<Pedidos>();
        string json = File.ReadAllText(archivoJson);
        return JsonSerializer.Deserialize<List<Pedidos>>(json) ?? new List<Pedidos>();
    }

    public void GuardarDato(List<Pedidos> pedidos)
    {
        string archivoJson = "src/pedidos.json";
        string json = JsonSerializer.Serialize(pedidos, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(archivoJson, json);
    }

}