using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Domain;
using ProAgil.Repository;

namespace ProAgil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PalestranteController : ControllerBase
    {
        private readonly IProAgilRepository _repo;
        public PalestranteController(IProAgilRepository repo)
        {
            _repo = repo;
        }
        [HttpGet("{PalestrantreId}")]

        public async Task<ActionResult> Get(int PalestranteId)
        {
            try
            {
                var results = await _repo.GetAllPalestranteAsync(PalestranteId,true);
                return Ok(results);
            }
            catch
            {
               return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro no Banco");
            }
        }
        [HttpGet("{Nome}")]
        public async Task<ActionResult> Get(string Nome)
        {
            try
            {
                var results = await _repo.GetAllPalestranteAsyncByNome(Nome, true);
                return Ok(results);
            }
            catch
            {
               return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro no Banco");

            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Palestrante model)
        {
            try
            {
                _repo.Add(model);
                if(await _repo.SaveChangesAsync())
                {
                    return Created($"api/palestrante/{model.Id}", model);
                }

            }
            catch (System.Exception)
            {
                
               return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro no Banco");
            }
        
                return BadRequest();
        }


         [HttpPut]
         public async Task<ActionResult> Put(int PalestranteId,Palestrante model)
        {
            try
            {
               var palestrante = await _repo.GetAllEventosAsyncById(PalestranteId, false);
               if(palestrante == null) return NotFound();
                _repo.Update(model);    

                if(await _repo.SaveChangesAsync())
                {
                    return Created($"api/palestrante/{model.Id}", model);
                }
               
            }
            catch (System.Exception)
            {
                
               return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro no Banco");
            }
        
                return BadRequest();
        }
        
        [HttpDelete]
         public async Task<ActionResult> Delete(int PalestranteId)
        {
            try
            {
               var palestrante = await _repo.GetAllEventosAsyncById(PalestranteId, false);
               if(palestrante == null) return NotFound();
                _repo.Delete(palestrante);    

                if(await _repo.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (System.Exception)
            {
                
               return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro no Banco");
            }
        
                return BadRequest();
        }

    }
}