using Microsoft.AspNetCore.Mvc;

namespace CadeteriaControlador
{
    [ApiController]
    [Route("api/[controller]")]

    public class CadeteriaController : ControllerBase
    {

        private AccesoADatosCadeteria accCadeteria;
        private AccesoADatosCadetes accCadetes;
        private AccesoADatosPedidos accPedidos;
        private Cadeteria cadeteria;

        public CadeteriaController()
        {

            accCadeteria = new AccesoADatosCadeteria();
            accCadetes = new AccesoADatosCadetes();
            accPedidos = new AccesoADatosPedidos();
            cadeteria = accCadeteria.CargarDatos()[0];
            cadeteria.ListadoCadetes = accCadetes.CargarDatos();
            cadeteria.ListadoPedidos = accPedidos.CargarDatos();
        }


        [HttpGet("cadetes")]
        public IActionResult GetCadetes()
        {

            return Ok(cadeteria.ObtenerCadetes());
        }

        [HttpGet("pedidos")]
        public ActionResult<Pedidos> GetPedidos()
        {

            return Ok(cadeteria.ObtenerPedidos());
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
            cadeteria.DarAltaPedido(
                pedido.Cliente.Nombre, pedido.Cliente.Direccion, pedido.Cliente.Telefono, pedido.Cliente.DatosReferenciaDireccion, pedido.Obs
            );
            accPedidos.GuardarDatos(cadeteria.ObtenerPedidos());
            return Created();
        }

        [HttpPut("cambiarEstadoPedido")]
        public IActionResult CambiarEstadoPedido(int idPedido, int NuevoEstado)
        {
            cadeteria.CambiarDeEstadoPedido(idPedido, NuevoEstado);
            accPedidos.GuardarDatos(cadeteria.ObtenerPedidos());
            return NoContent();
        }
        [HttpPut("cambiarCadetePedido")]
        public IActionResult CambiarCadetePedido(int idPedido, int idNuevoCadete)
        {
            cadeteria.ReasignarPedido(idPedido, idNuevoCadete);
            accPedidos.GuardarDatos(cadeteria.ObtenerPedidos());
            return NoContent();
        }
    }
}