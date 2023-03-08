using Aplicacion.Feautres.Libros.Comandos.CrearLibro;
using Aplicacion.Feautres.Libros.Comandos.EliminarLibro;
using Aplicacion.Feautres.Libros.Comandos.ModificarLibro;
using Aplicacion.Feautres.Libros.Consultas.ObtenerLibroPorId;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiWeb.Controllers.v1
{
    [ApiVersion("1.0")]
    public class LibroController : BaseApiController
    {
        //Post 
        [HttpPost]
       public async Task<IActionResult> Post(CrearLibro comando)
        {
            return Ok(await Mediator.Send(comando));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ModificarLibro comando)
        {
            if (id != comando.id)
                return BadRequest();
            return Ok(await Mediator.Send(comando));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
          
            return Ok(await Mediator.Send(new EliminarLibro { id = id}));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await Mediator.Send(new ObtenerlibroId { Id = id }));
        }


    }
}
