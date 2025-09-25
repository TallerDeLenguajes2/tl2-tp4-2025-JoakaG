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
            List<Cadetes> cadetes = new();
            return Ok(cadetes);
        }

        [HttpGet("pedidos")]
        public ActionResult<Pedidos> GetPedidos()
        {
            List<Pedidos> pedidos = new();
            return Ok(pedidos);
        }
        [HttpGet("informe")]
        public ActionResult<string> GetInforme()
        {
            string informe = "Hola";
            return Ok(informe);
        }

        [HttpPost("agregarPedido")]
        public ActionResult<Pedidos> AgregarPedido(Pedidos pedido)
        {
            return Ok(pedido);
        }
        [HttpPut("asignarPedido")]
        public ActionResult<bool> AsignarPedido(int idPedido, int idCadete)
        {
            return Ok(true);
        }
        [HttpPut("cambiarEstadoPedido")]
        public ActionResult CambiarEstadoPedido(int idPedido, int NuevoEstado)
        {
            
            return Ok(true);
        }
        [HttpPut("cambiarCadetePedido")]
        public ActionResult<bool> CambiarCadetePedido(int idPedido, int idNuevoCadete)
        {
            return Ok(true);
        }


    }
}