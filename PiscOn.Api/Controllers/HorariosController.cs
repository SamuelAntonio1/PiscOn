using Microsoft.AspNetCore.Mvc;

namespace PiscOn.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HorariosController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<string>> Lista()
        {
            var lista = new List<string>();
            lista.Add("08:00");
            lista.Add("09:00");
            lista.Add("10:00");
            lista.Add("11:00");
            lista.Add("12:00");
            lista.Add("13:00");
            lista.Add("14:00");
            lista.Add("15:00");
            lista.Add("16:00");
            lista.Add("17:00");
            lista.Add("18:00");

            return Ok(lista);
        }
    }
}
