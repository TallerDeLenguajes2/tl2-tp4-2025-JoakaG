public class AccesoADatosCSV : IAccesoADatos<Cadeteria>
{
    public List<Cadeteria> CargarDatos(string archivoCsv)
    {
        List<Cadeteria> cadeterias = new List<Cadeteria>();
        if (!File.Exists(archivoCsv)) return cadeterias;

        var lineas = File.ReadAllLines(archivoCsv);
        if (lineas.Length < 2) return cadeterias;

        foreach (var linea in lineas.Skip(1))
        {
            var partes = linea.Split(',');
            if (partes.Length < 5) continue;

            string nombreCadeteria = partes[0];
            string telefonoCadeteria = partes[1];

            string nombreCadete = partes[2];
            string telefonoCadete = partes[3];
            string direccionCadete = partes[4];

            var cadeteria = cadeterias.FirstOrDefault(c => c.Nombre == nombreCadeteria);
            if (cadeteria == null)
            {
                cadeteria = new Cadeteria(nombreCadeteria, telefonoCadeteria);
                cadeterias.Add(cadeteria);
            }
            cadeteria.ListadoCadetes.Add(new Cadetes(nombreCadete , direccionCadete, telefonoCadete));
        }
        return cadeterias;
    }

    public void GuardarDatos(string archivoCsv, List<Cadeteria> datos)
    {
        using (var sw = new StreamWriter(archivoCsv))
        {
             sw.WriteLine("NombreCadeteria,TelefonoCadeteria,NombreCadete,TelefonoCadete,DireccionCadete");

            foreach (var cadeteria in datos)
            {
                sw.WriteLine($"{cadeteria.Nombre},{cadeteria.Telefono}");


                foreach (var cadete in cadeteria.ListadoCadetes)
                {
                    sw.WriteLine($"{cadete.Nombre},{cadete.Telefono},{cadete.Direccion}");
                }
            }
        }
    }
}