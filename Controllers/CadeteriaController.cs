using Microsoft.AspNetCore.Mvc;

namespace CadeteriaControlador
{
    [ApiController]
    [Route("api/[controller]")]

    public class CadeteriaController : ControllerBase
    {


        [HttpGet("cadetes")]
        public ActionResult<Cadetes> GetCadetes()
        {
            var ACCDCad = new AccesoADatosCadetes();
            var cadetes = ACCDCad.CargarDatos();
            return Ok(cadetes);
        }

        [HttpGet("pedidos")]
        public ActionResult<Pedidos> GetPedidos()
        {
            var ACCDCad = new AccesoADatosPedidos();
            var pedidos = ACCDCad.CargarDatos();
            return Ok(pedidos);
        }
        // [HttpGet("informe")]
        // public IActionResult GetInforme()
        // {
        //     var ACCDCadeteria = new AccesoADatosCadeteria();
        //     Cadeteria cadeteria = ACCDCadeteria.CargarDatos()[0];
        //     return Ok(cadeteria.GenerarInforme());
        // }

        [HttpPost("agregarPedido")]
        public IActionResult AgregarPedido(Pedidos pedido)
        {
            var ACCDP = new AccesoADatosPedidos();
            ACCDP.GuardarDato(pedido);
            return Created();
        }

        // [HttpPut("cambiarEstadoPedido")]
        // public IActionResult CambiarEstadoPedido(int idPedido, int NuevoEstado)
        // {
        //     var ACCDP = AccesoADatosPedidos();
        //     CambiarDeEstadoPedido(idPedido, NuevoEstado);
        //     return NoContent();
        // }
        //     [HttpPut("cambiarCadetePedido")]
        //     public IActionResult CambiarCadetePedido(int idPedido, int idNuevoCadete)
        //     {
        //         cadeteria.ReasignarPedido(idPedido, idNuevoCadete);        
        //         ADPE.GuardarDatos("src/pedidos.csv", cadeteria.ObtenerPedidos());
        //         return NoContent();
        //     }
    }
}