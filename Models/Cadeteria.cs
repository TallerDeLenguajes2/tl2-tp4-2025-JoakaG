
public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadetes>? listadoCadetes;
    private List<Pedidos> listadoPedidos;

    public Cadeteria(string nombre, string telefono)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        this.ListadoCadetes = new List<Cadetes>();
        this.ListadoPedidos = new List<Pedidos>();
    }

    public List<Cadetes>? ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Pedidos> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

    public bool AsignarPedido(int idCadete, int idPedido)
    {
        if (ListadoCadetes != null)
        {
            Cadetes? cadete = ListadoCadetes.FirstOrDefault(c => c.Id == idCadete);
            Pedidos? pedido = listadoPedidos.FirstOrDefault(p => p.Nro == idPedido);
            if (cadete != null && pedido != null)
            {
                pedido.IdCadeteACargo = idCadete;
                System.Console.WriteLine($"Pedido nro {pedido.Nro}, asignado a '{cadete.Nombre}'- ID {cadete.Id}");
                return true;
            }
            else
            {
                System.Console.WriteLine("ERROR, vuelvelo a intentar más tarde");
            }
        }
        return false;
    }

    public Cadetes? BuscarCadetePorPedido(int idPedido)
    {
        Pedidos? pedido;
        if (listadoCadetes != null)
        {
            pedido = listadoPedidos.FirstOrDefault(p => p.Nro == idPedido);
            if (pedido != null)
            {
                return listadoCadetes.FirstOrDefault(c => c.Id == pedido.IdCadeteACargo);
            }
        }
        return null;
    }

    public Pedidos? BuscarPedido(int idPedido)
    {
        Pedidos? pedido = null;
        if (listadoCadetes != null)
        {
            pedido = listadoPedidos.FirstOrDefault(p => p.Nro == idPedido);
        }
        return pedido;
    }
    public List<Cadetes> ?ObtenerCadetes()
    {
        return listadoCadetes;
    }
    public List<string> GenerarInforme()
    {
        var TotalEntregado = 0;
        List<string> DatosGeneradosDecADETES = new List<string>();
        if (listadoCadetes != null)
        {
            int cantidadEntregados;
            foreach (var cadete in listadoCadetes)
            {
                cantidadEntregados = 0;
                cantidadEntregados = listadoPedidos.Count(p => p.Estado1 == Pedidos.Estado.entregado && p.IdCadeteACargo == cadete.Id);
                DatosGeneradosDecADETES.Add($"cadete:{cadete.Nombre} id: {cadete.Id} - Total de Pedidos Entregados: {cantidadEntregados} - Jornal a Cobrar: {JornalACobrar(cadete.Id)}");
            }
            
            DatosGeneradosDecADETES.Add($"Total de Envíos realizados: {TotalEntregado}");
        }
        return DatosGeneradosDecADETES;
    }

    public double JornalACobrar(int idCadete)
    {
        int montoTotal = 0;
        montoTotal = this.listadoPedidos.Count(p => p.IdCadeteACargo == idCadete && p.Estado1 == Pedidos.Estado.entregado) * 500;
        return montoTotal;
    }
}
