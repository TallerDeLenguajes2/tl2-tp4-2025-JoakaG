
public class Cadetes
{

    private static int contador = 0;
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;

    public int Id { get => id; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }


    public Cadetes(string nombre, string direccion, string telefono)
    {
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        this.id = contador++;
    }

}

