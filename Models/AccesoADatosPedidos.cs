using System.Text.Json;
public class AccesoADatosPedidos : IAccesoADatos<Pedidos>
{

    public List<Pedidos> CargarDatos(string archivoJson)
    {
         if (!File.Exists(archivoJson))
            return new List<Pedidos>();

        string json = File.ReadAllText(archivoJson);
        return JsonSerializer.Deserialize<List<Pedidos>>(json) ?? new List<Pedidos>();
    }
    public void GuardarDatos(string archivoJson, List<Pedidos> datos)
    {
        var pedido = CargarDatos("src/pedidos.json");
        var newid = pedido.Max(a => a.Nro) + 1;
        string json = JsonSerializer.Serialize(datos, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(archivoJson, json);
    }
}