using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Dominio;
using WebApplication2.Repo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroiController : ControllerBase
    {
        public readonly HeroiContext _context;

        public HeroiController(HeroiContext context)
        {
            _context = context;    
        }

        // GET: api/Heroi
        
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(new Heroi());
            }
            catch (System.Exception ex)
            {

                return BadRequest($"erro: {ex}");
            }

        }

        // GET api/Heroi/5
       // [HttpGet("{id}")]
       // public string Get(int id)
       // {
         //   return "value";
       // }

        // POST api/<HeroiController>
        [HttpPost]
        public ActionResult Post(Heroi model)
        {
            try
            {
                _context.Herois.Add(model);
                _context.SaveChanges();
                return Ok("certo");
            }
            catch (System.Exception ex)
            {

                return BadRequest($"erro: {ex}");
            }
        }

        // PUT api/<HeroiController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Heroi model)
        {
            try
            {
                if (_context.Herois
                    .AsNoTracking().FirstOrDefault(h=>h.Id==id) != null)
                { 
                    _context.Herois.Update(model);
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

        // DELETE api/<HeroiController>/5
       /// [HttpDelete("{id}")]
       // public void Delete(int id)
       // {
       // }
    }
}
