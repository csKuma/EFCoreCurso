using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApplication2.Dominio;
using WebApplication2.Repo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatalhaController : ControllerBase
    {
        private HeroiContext _context;

        public BatalhaController( HeroiContext context)
        {
            _context = context;
        }                

        // GET: api/<BatalhaController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(new Batalha());
            }
            catch (System.Exception ex)
            {

                return BadRequest($"erro: {ex}");
            }

        }

        // GET api/<BatalhaController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                return Ok(new Batalha());
            }
            catch (System.Exception ex)
            {

                return BadRequest($"erro: {ex}");
            }

        }

        // POST api/<BatalhaController>
        [HttpPost]
        public ActionResult Post( Batalha model)
        {
            try
            {
                _context.Batalhas.Add(model);
                _context.SaveChanges();
                return Ok("certo");
            }
            catch (System.Exception ex)
            {

                return BadRequest($"erro: {ex}");
            }
        }

        // PUT api/<BatalhaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Batalha model)
        {
            try
            {
                if (_context.Batalhas
                    .AsNoTracking().FirstOrDefault(h => h.Id == id) != null)
                {
                    _context.Batalhas.Update(model);
                    _context.SaveChanges();
                    return Ok("certo 12");
                }
                return Ok("Não Encontrado!");

            }
            catch (System.Exception ex)
            {

                return BadRequest($"erro: {ex}");
            }
        }

        // DELETE api/<BatalhaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
