using Microsoft.AspNetCore.Mvc;

namespace CadeteriaControlador
{
    [ApiController]
    [Route("api/[controller]")]

    public class CadeteriaController : ControllerBase
    {
        private AccesoADatosCSV ADCSV;
        private AccesoADatosJSON ADJSON;
        private AccesoADatosPedidos ADPE;
        private Cadeteria cadeteria;

        public CadeteriaController()
        {
            ADCSV = new AccesoADatosCSV();
            ADJSON = new AccesoADatosJSON();
            ADPE = new AccesoADatosPedidos();
            cadeteria = ADCSV.CargarDatos("src/cadeteria.csv")[0];
            cadeteria.ListadoPedidos = ADPE.CargarDatos("src/pedidos.csv");
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
        public IActionResult AgregarPedido(Pedidos pedido)
        {
            cadeteria.DarAltaPedido(
            pedido.Cliente.Nombre,
            pedido.Cliente.Direccion,
            pedido.Cliente.Telefono,
            pedido.Cliente.DatosReferenciaDireccion,
            pedido.Obs
            
        );
            ADPE.GuardarDatos("src/pedidos.csv", cadeteria.ObtenerPedidos());
            return NoContent();
        }
        [HttpPut("asignarPedido")]
        public IActionResult AsignarPedido(int idPedido, int idCadete)
        {
            cadeteria.AsignarPedido(idPedido, idCadete);
            ADPE.GuardarDatos("src/pedidos.csv", cadeteria.ObtenerPedidos());
            return Ok();
        }
        [HttpPut("cambiarEstadoPedido")]
        public IActionResult CambiarEstadoPedido(int idPedido, int NuevoEstado)
        {
            cadeteria.CambiarDeEstadoPedido(idPedido, NuevoEstado);
            ADPE.GuardarDatos("src/pedidos.csv", cadeteria.ObtenerPedidos());
            return Ok();
        }
        [HttpPut("cambiarCadetePedido")]
        public IActionResult CambiarCadetePedido(int idPedido, int idNuevoCadete)
        {
            cadeteria.ReasignarPedido(idPedido, idNuevoCadete);        
            ADPE.GuardarDatos("src/pedidos.csv", cadeteria.ObtenerPedidos());
            return Ok();
        }
    }
}