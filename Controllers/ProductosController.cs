using Microsoft.AspNetCore.Mvc;
using TiendaAPI.Modelo;
using TiendaAPI.Servicios;

namespace TiendaAPI.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<MProductos>>> get()
        {
            var funcion = new DProductos();
            var lista = await funcion.mostrarProductos();
            return lista;
        }

        [HttpPost]
        public async Task post([FromBody] MProductos parametros)
        {
            var funcion = new DProductos();
            await funcion.insertarProductos(parametros);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> put(int id, [FromBody] MProductos parametros)
        {
            var funcion = new DProductos();
            parametros.id = id;
            await funcion.editarProductos(parametros);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> delete(int id)
        {
            var funcion = new DProductos();
            var parametros = new MProductos();
            parametros.id = id;
            await funcion.eliminarProductos(parametros);
            return NoContent();

        }
    }
}
