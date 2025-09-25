public class Pedidos
{
    private static int contador = 0;
    private int nro = 0;
    private string? obs;
    private Clientes cliente;
    private Estado estado;
    private int idCadeteACargo = -9999;
    public Clientes Cliente { get => cliente; set => cliente = value; }
    public int Nro { get => nro; set => nro = value; }
    public Estado Estado1 { get => estado; set => estado = value; }
    public int IdCadeteACargo { get => idCadeteACargo; set => idCadeteACargo = value; }

    public Pedidos(string? obs, string nombreC, string direccionC, string telefonoC, string ?datosRefDirecC)
    {
        contador++;
        this.Nro = contador;
        this.obs = obs;
        this.cliente = new Clientes(nombreC, direccionC, telefonoC, datosRefDirecC);
        this.estado = Estado.pendiente;
    }
    public enum Estado
    {
        pendiente = 0,
        entregado = 1,
        cancelado = 2
    }

    public string DireccionCliente()
    {
        return Cliente.Direccion;
    }

    public Clientes DatosCliente()
    {
        return Cliente;
    }
}