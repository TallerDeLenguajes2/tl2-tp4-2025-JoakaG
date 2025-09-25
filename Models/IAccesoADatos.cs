public interface IAccesoADatos<T>
{
    List<T> CargarDatos(string ruta);
    void GuardarDatos(string ruta, List<T> datos);
}