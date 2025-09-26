public class Clientes{
    private string nombre;
    private string direccion;
    private string telefono;
    private string? datosReferenciaDireccion;

    public string Direccion { get => direccion; set => direccion = value; }
    public string? DatosReferenciaDireccion { get => datosReferenciaDireccion; set => datosReferenciaDireccion = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }

    public Clientes() { }
    public Clientes(string nombre, string direccion, string telefono, string? datosRef = null)
    {
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        DatosReferenciaDireccion = datosRef;
    }

}