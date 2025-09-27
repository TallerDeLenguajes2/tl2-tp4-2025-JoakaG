
public class Cadetes
{
    private static int contador1 = 0;
    private int id = 0;
    private string nombre;
    private string direccion;
    private string telefono;

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }

    public Cadetes()
    {
        contador1++;
        Id = contador1;
    }

    public Cadetes(string nombre, string direccion, string telefono)
    {
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
    }

}

