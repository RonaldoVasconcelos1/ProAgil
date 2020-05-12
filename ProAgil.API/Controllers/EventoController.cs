using System.Net.Http.Headers;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Domain;
using ProAgil.Repository;
using AutoMapper;
using ProAgil.API.Dtos;

namespace ProAgil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IProAgilRepository _repo;
        private readonly IMapper _mapper;
        public EventoController(IProAgilRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            try
            {
                var eventos = await _repo.GetAllEventoAsync(true);

                var results = _mapper.Map<IEnumerable<EventoDto>>(eventos);

                return Ok(results);

            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro no Banco");
            }


        }

        // [HttpPost("upload")]
        // public async Task<ActionResult> Upload()
        // {
        //     try
        //     {
        //         var file = Request.Form.Files[0];
        //         var folderName = Path.Combine("Resources", "Images");
        //         var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

        //         if (file.Length > 0)
        //         {
        //             var filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName;
        //             var fullPath = Path.Combine(pathToSave, filename.Replace("\"", " ").Trim());

        //             using (var stream = new FileStream(fullPath, FileMode.Create))
        //             {
        //                 file.CopyTo(stream);
        //             }
        //         }

                
        //          return Ok();
        //     }
        //     catch (System.Exception ex)
        //     {
        //         return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
        //     }

        //     return BadRequest("Erro ao tentar realizar upload");
        // }


        [HttpGet("{EventoId}")]
        public async Task<ActionResult> Get(int EventoId)
        {

            try
            {
                var evento  = await _repo.GetEventosAsyncById(EventoId, true);

                var results = _mapper.Map<EventoDto>(evento);

                return Ok(results);

            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro no Banco");
            }
        }
        [HttpGet("getByTema/{Tema}")]
        public async Task<ActionResult> Get(string Tema)
        {

            try
            {
                var eventos = await _repo.GetAllEventoAsyncByTema(Tema, true);

                var results = _mapper.Map<IEnumerable<EventoDto>>(eventos);


                return Ok(results);

            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro no Banco");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(EventoDto model)
        {
            

            try
            {
                var evento = _mapper.Map<Evento>(model);

                _repo.Add(evento);

                if (await _repo.SaveChangesAsync())
                {

                    return Created($"/api/evento/{model.Id}", _mapper.Map<Evento>(evento));
                }


            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro no Banco {ex.Message}");
            }
            return BadRequest();

        }

        [HttpPut("{EventoId}")]
        public async Task<IActionResult> Put(int EventoId, EventoDto model)
        {

            try
            {
                
                var evento = await _repo.GetEventosAsyncById(EventoId, false);
                if (evento == null) return NotFound();
            

                 _mapper.Map(model, evento);

                _repo.Update(evento);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/evento/{model.Id}", _mapper.Map<EventoDto>(evento));

                }
            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro no Banco {ex.Message}");
            }
            return BadRequest();

        }

        [HttpDelete("{EventoId}")]
        public async Task<ActionResult> Delete(int EventoId)
        {

            try
            {
                var eventos = await _repo.GetEventosAsyncById(EventoId, false);
                if (eventos == null) return NotFound();
                _repo.Delete(eventos);

                if (await _repo.SaveChangesAsync())
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