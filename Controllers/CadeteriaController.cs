using Microsoft.AspNetCore.Mvc;

namespace CadeteriaControlador
{
    [ApiController]
    [Route("api/[controller]")]
    public class CadeteriaController : ControllerBase
    {
        [HttpGet]
        public GetCadetes()
        {
            List<Cadetes> cadetes = cadeteria
        }
}
}