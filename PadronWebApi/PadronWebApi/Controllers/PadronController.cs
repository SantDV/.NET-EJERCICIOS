using Microsoft.AspNetCore.Mvc;
using PadronWebApi.Modelo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PadronWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PadronController : ControllerBase
    {
        // GET: api/<PadronController>
        [HttpGet]
        public ActionResult<List<Persona>> Get()
        {
            Connection conn = new Connection();
            var personas = conn.GetAll();

            return Ok(personas);
        }

        // GET api/<PadronController>/5
        [HttpGet("dni/{id}")]
        public ActionResult<List<Persona>> GetDni(string id)
        {
            Connection conn = new Connection();
            var personas = conn.GetByName(id, 0);

            return Ok(personas);
        }

        [HttpGet("apellido/{id}")]
        public ActionResult<List<Persona>> GetApellido(string id)
        {
            Connection conn = new Connection();
            var personas = conn.GetByName(id, 1);

            return Ok(personas);
        }


        [HttpGet("nombre/{id}")]
        public ActionResult<List<Persona>> GetNombre(string id)
        {
            Connection conn = new Connection();
            var personas = conn.GetByName(id, 2);

            return Ok(personas);
        }
        

        // POST api/<PadronController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PadronController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PadronController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
