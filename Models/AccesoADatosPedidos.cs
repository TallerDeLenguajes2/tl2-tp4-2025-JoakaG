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

    public void GuardarDato( Pedidos datos)
    {
        string archivoJson = "src/pedidos.json";
        var pedidos = CargarDatos();
        var newid = 1;
        if (pedidos.Count > 0)
        {
            newid = pedidos.Max(a => a.Nro) + 1;
        }
        datos.Nro = newid;
        pedidos.Add(datos);
        string json = JsonSerializer.Serialize(pedidos, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(archivoJson, json);
    }

}