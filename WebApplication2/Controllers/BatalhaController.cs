using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Repo;
using WebApplication2.Dominio;
using WebApplication2.Repo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatalhaController : ControllerBase
    {
        public readonly IEFcoreRepository _repo;

        public BatalhaController(IEFcoreRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<BatalhaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var herois = await _repo.GetAllBatalhas(true);
                return Ok(herois);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"erro: {ex}");
            }

        }

        // GET api/<BatalhaController>/5
        [HttpGet("{id}",Name="getBatalha")]
         public async Task<IActionResult> Get(int id)
          {
            try
            {
                var herois = await _repo.GetBatalhaById(id, true);
                return Ok(herois);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"erro: {ex}");
            }

        }

        // POST api/<BatalhaController>
        [HttpPost]
        public async Task<IActionResult> Post(Batalha model)
        {
            try
            {
                _repo.Add(model);
                if (await _repo.SaveCHangeAsync())
                {
                    return Ok("certo");
                }
            }
            catch (System.Exception ex)
            {

                return BadRequest($"erro: {ex}");
            }
            return BadRequest("não Salvou");
        }

        // PUT api/<BatalhaController>/5
       [HttpPut("{id}")]
         public async Task< IActionResult> Put(int id, Batalha model)
            {
            try
            {
                var batalha = await _repo.GetBatalhaById(id);
                if (batalha != null)
                {
                    _repo.Update(model);

                    if (await _repo.SaveCHangeAsync())
                        return Ok("certo 12");
                }

            }
            catch (System.Exception ex)
            {

                return BadRequest($"erro: {ex}");
            }
            return BadRequest("Não Atualizado");
        }

            // DELETE api/<BatalhaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var batalha = await _repo.GetBatalhaById(id);
                if (batalha != null)
                {
                    _repo.Delete(batalha);

                    if (await _repo.SaveCHangeAsync())
                        return Ok("certo 12");
                }

            }
            catch (System.Exception ex)
            {

                return BadRequest($"erro: {ex}");
            }
            return BadRequest("eNão Deletado");
        }

    }
}
    

