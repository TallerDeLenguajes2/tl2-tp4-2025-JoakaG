
public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadetes> listadoCadetes;
    private List<Pedidos> listadoPedidos;

    public Cadeteria(string nombre, string telefono)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        this.ListadoCadetes = new List<Cadetes>();
        this.ListadoPedidos = new List<Pedidos>();
    }

    public List<Cadetes> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
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

        pedido = listadoPedidos.FirstOrDefault(p => p.Nro == idPedido);
        if (pedido != null)
        {
            return listadoCadetes.FirstOrDefault(c => c.Id == pedido.IdCadeteACargo);
        }
        return null;
    }

    public Pedidos? BuscarPedido(int idPedido)
    {
        Pedidos? pedido = null;
        pedido = listadoPedidos.FirstOrDefault(p => p.Nro == idPedido);
        return pedido;
    }
    public List<Cadetes> ObtenerCadetes()
    {
        return listadoCadetes;
    }

    public List<Pedidos> ObtenerPedidos()
    {
        return listadoPedidos;
    }
    public List<string> GenerarInforme()
    {
        var TotalEntregado = 0;
        List<string> DatosGeneradosDecADETES = new List<string>();

            int cantidadEntregados;
            foreach (var cadete in listadoCadetes)
            {
                cantidadEntregados = 0;
                cantidadEntregados = listadoPedidos.Count(p => p.Estado1 == Pedidos.Estado.entregado && p.IdCadeteACargo == cadete.Id);
                DatosGeneradosDecADETES.Add($"cadete:{cadete.Nombre} id: {cadete.Id} - Total de Pedidos Entregados: {cantidadEntregados} - Jornal a Cobrar: {JornalACobrar(cadete.Id)}");
            }

            DatosGeneradosDecADETES.Add($"Total de Envíos realizados: {TotalEntregado}");
        return DatosGeneradosDecADETES;
    }

    public double JornalACobrar(int idCadete)
    {
        int montoTotal = 0;
        montoTotal = this.listadoPedidos.Count(p => p.IdCadeteACargo == idCadete && p.Estado1 == Pedidos.Estado.entregado) * 500;
        return montoTotal;
    }

    public bool AsignarCadete(int idPedido, int idCadete)
    {
        var pedido = listadoPedidos.FirstOrDefault(p => p.Nro == idPedido);
        var cadete = listadoCadetes.FirstOrDefault(c => c.Id == idCadete);

        if (pedido != null && cadete != null && pedido.IdCadeteACargo == -9999)
        {
            pedido.IdCadeteACargo = idCadete;

            return true;
        }

        return false;
    }

    public bool CambiarDeEstadoPedido(int idPedido, int nuevoEstado)
    {
        var cadete = BuscarCadetePorPedido(idPedido);
        var pedido = BuscarPedido(idPedido);

        if (cadete == null || pedido == null)
        {
            return false;
        }
        if (pedido.Estado1 == Pedidos.Estado.entregado || pedido.Estado1 == Pedidos.Estado.cancelado)
        {
            return false;
        }

        switch (nuevoEstado)
        {
            case 0:
                pedido.Estado1 = Pedidos.Estado.pendiente;
                break;
            case 1:
                pedido.Estado1 = Pedidos.Estado.entregado;
                break;
            case 2:
                pedido.Estado1 = Pedidos.Estado.cancelado;
                break;
            default:

                return false;
        }

        return true;
    }

    public bool ReasignarPedido(int idPedido, int idCadete)
    {
        var pedido = BuscarPedido(idPedido);
        var cadete = ListadoCadetes.FirstOrDefault(c => c.Id == idCadete);

        // Verificaciones
        if (pedido == null || cadete == null)
            return false;

        if (pedido.Estado1 == Pedidos.Estado.entregado || pedido.Estado1 == Pedidos.Estado.cancelado)
            return false;

        pedido.IdCadeteACargo = cadete.Id;
        return true;
    }

    public Pedidos? DarAltaPedido(string nombre, string direccion, string telefono, string? datosRefDirecc = null, string? observaciones = null)
    {
        if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(direccion) || string.IsNullOrWhiteSpace(telefono))
            return null;

        var pedido = new Pedidos(observaciones, nombre, direccion, telefono, datosRefDirecc);

        listadoPedidos.Add(pedido);
        return pedido;
    }
}


