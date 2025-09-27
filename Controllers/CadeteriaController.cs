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
            var acc = new AccesoADatosCadetes();
            var cadetes = acc.CargarDatos();
            return Ok(cadetes);
        }

        [HttpGet("pedidos")]
        public ActionResult<Pedidos> GetPedidos()
        {
            var acc = new AccesoADatosPedidos();
            var pedidos = acc.CargarDatos();
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
            var acc = new AccesoADatosPedidos();
            var pedidos = acc.CargarDatos();
            pedidos.Add(pedido);
            
            acc.GuardarDato(pedidos);
            return Created();
        }

         [HttpPut("cambiarEstadoPedido")]
         public IActionResult CambiarEstadoPedido(int idPedido, int NuevoEstado)
         {
            var accC = new AccesoADatosCadeteria();
            var accP = new AccesoADatosPedidos();
            Cadeteria cadeteria = accC.CargarDatos()[0];
            var pedidos = accP.CargarDatos();
            cadeteria.ListadoPedidos = pedidos;
            cadeteria.CambiarDeEstadoPedido(idPedido, NuevoEstado);
            
            return NoContent();
         }
              [HttpPut("cambiarCadetePedido")]
              public IActionResult CambiarCadetePedido(int idPedido, int idNuevoCadete)
               {
            var accC = new AccesoADatosCadeteria();
            var accP = new AccesoADatosPedidos();
            var pedidos = accP.CargarDatos();
            var cadeteria = accC.CargarDatos()[0];
            cadeteria.ListadoPedidos = pedidos;
            cadeteria.ReasignarPedido(idPedido, idNuevoCadete);
            return NoContent();
             }
    }
}