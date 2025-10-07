public class Pedidos
{
    private int nro;
    private string? obs;
    private Clientes cliente;
    private Estado estado;
    private int idCadeteACargo = -9999;
    public Clientes Cliente { get => cliente; set => cliente = value; }
    public int Nro { get => nro; set => nro = value; }
    public Estado Estado1 { get => estado; set => estado = value; }
    public int IdCadeteACargo { get => idCadeteACargo; set => idCadeteACargo = value; }
    public string? Obs { get => obs; set => obs = value; }

    public Pedidos()
    {
        Estado1 = Estado.pendiente;
    }

    public Pedidos(int nro, string? obs, string nombreC, string direccionC, string telefonoC, string? datosRefDirecC)
        : this()
    {
        Nro = nro;
        Obs = obs;
        Cliente = new Clientes(nombreC, direccionC, telefonoC, datosRefDirecC);
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