using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication.Repo;
using WebApplication2.Dominio;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroiController : ControllerBase
    {
        private readonly IEFcoreRepository _repo;

        public HeroiController(IEFcoreRepository repo)
        {
            _repo = repo;
        }



        // GET: api/<HeroiController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var herois = await _repo.GetAllHerois(true);
                return Ok(herois);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"erro: {ex}");
            }
        }

        // GET api/<HeroiController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var herois = await _repo.GetHeroiById(id);
                return Ok(herois);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"erro: {ex}");
            }
        }

        // POST api/<HeroiController>
        [HttpPost]
        public async Task<IActionResult> Post(Heroi model)
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

        // PUT api/<HeroiController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Heroi model)
        {
            try
            {
                var heroi = await _repo.GetHeroiById(id);
                if (heroi != null)
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

        // DELETE api/<HeroiController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var heroi= await _repo.GetHeroiById(id);
                if (heroi != null)
                {
                    _repo.Delete(heroi);

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
