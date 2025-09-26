using Microsoft.AspNetCore.Mvc;

namespace CadeteriaControlador
{
    [ApiController]
    [Route("api/[controller]")]

    public class CadeteriaController : ControllerBase
    {
        private AccesoADatosCSV ADCSV;
        private AccesoADatosJSON ADJSON;
        private Cadeteria cadeteria;

        public CadeteriaController()
        {
            ADCSV = new AccesoADatosCSV();
            ADJSON = new AccesoADatosJSON();
            cadeteria = ADCSV.CargarDatos("src/cadeteria.csv")[0];
            
        }

        [HttpGet("cadetes")]
        public ActionResult<Cadetes> GetCadetes()
        {
            return Ok(cadeteria.ObtenerCadetes());
        }

        [HttpGet("pedidos")]
        public ActionResult<Pedidos> GetPedidos()
        {
            return Ok(cadeteria.ObtenerPedidos());
        }
        [HttpGet("informe")]
        public ActionResult<string> GetInforme()
        {
            return Ok(cadeteria.GenerarInforme());
        }

        [HttpPost("agregarPedido")]
        public ActionResult<Pedidos> AgregarPedido(Pedidos pedido)
        {
            var nuevoPedido = cadeteria.DarAltaPedido(
            pedido.Cliente.Nombre,
            pedido.Cliente.Direccion,
            pedido.Cliente.Telefono,
            pedido.Cliente.DatosReferenciaDireccion,
            pedido.Obs
        );
            return Ok(nuevoPedido);
        }
        [HttpPut("asignarPedido")]
        public ActionResult<bool> AsignarPedido(int idPedido, int idCadete)
        {
            return Ok(cadeteria.AsignarPedido(idPedido, idCadete));
        }
        [HttpPut("cambiarEstadoPedido")]
        public IActionResult CambiarEstadoPedido(int idPedido, int NuevoEstado)
        {

            return Ok(cadeteria.CambiarDeEstadoPedido(idPedido, NuevoEstado));
        }
        [HttpPut("cambiarCadetePedido")]
        public IActionResult CambiarCadetePedido(int idPedido, int idNuevoCadete)
        {
            return Ok(true);
        }


    }
}