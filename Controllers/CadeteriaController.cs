using Microsoft.AspNetCore.Mvc;

namespace CadeteriaControlador
{
    [ApiController]
    [Route("api/[controller]")]

    public class CadeteriaController : ControllerBase
    {
        [HttpGet("test")]
        public ActionResult<string> Test()
        {
            return Ok("OK");
        }


        [HttpGet("cadetes")]
        public ActionResult GetCadetes()
        {
            List<Cadetes> cadetes = new();
            return Ok(cadetes);
        }

        [HttpGet("pedidos")]
        public ActionResult GetPedidos()
        {
            List<Pedidos> pedidos = new();
            return Ok(pedidos);
        }
        [HttpGet("informe")]
        public ActionResult GetInforme()
        {
            string informe = "Hola";
            return Ok(informe);
        }

        [HttpPost("agregarPedido")]
        public ActionResult AgregarPedido(Pedidos pedido)
        {
            return Ok(pedido);
        }
        [HttpPut("asignarPedido")]
        public ActionResult AsignarPedido(int idPedido, int idCadete)
        {
            return Ok(true);
        }
        [HttpPut("cambiarEstadoPedido")]
        public ActionResult CambiarEstadoPedido(int idPedido, int NuevoEstado)
        {

            return Ok(true);
        }
        [HttpPut("cambiarCadetePedido")]
        public ActionResult CambiarCadetePedido(int idPedido, int idNuevoCadete)
        {
            return Ok(true);
        }


    }
}