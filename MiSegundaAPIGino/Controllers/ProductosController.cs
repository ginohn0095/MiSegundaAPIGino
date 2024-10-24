using Microsoft.AspNetCore.Mvc;
using MiSegundaAPIGino.Model;

namespace MiSegundaAPIGino.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductosController : Controller
    {

        // Lista temporal para almacenar los productos
        private static List<Producto> productos = new List<Producto>
        {
        new Producto { ID = 1, Nombre = "Laptop", Precio = 1500 },
        new Producto { ID = 2, Nombre = "Mouse", Precio = 25 }
        };

        // GET: api/Productos
        [HttpGet]
        public ActionResult<IEnumerable<Producto>> GetProductos()
        {
            return Ok(productos);
        }
        //Get: api/Productos/1
        [HttpGet("{ID}")]
        public ActionResult<Producto> GetProducto(int id)
        {
            var producto = productos.FirstOrDefault(p => p.ID == id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }
        //POST: api/Productos
        [HttpPost]
        public ActionResult<Producto> CrearProducto(Producto nuevoproducto)
        {
            nuevoproducto.ID = productos.Max(p => p.ID) + 1;
            productos.Add(nuevoproducto);
            return CreatedAtAction(nameof(GetProducto), new { id = nuevoproducto });
        }

        //PUT api/Productos/1
        [HttpPut("{ID}")]
        public IActionResult ActualizarProducto(int ID, Producto productoactualizar)
        {
            var producto = productos.FirstOrDefault(p => p.ID == ID);
            if (producto == null)
            {
                return NotFound();

            }
            producto.Nombre = productoactualizar.Nombre;
            producto.Precio = productoactualizar.Precio;
            return NoContent();
        }
        //DELETE: api/Productos/1
        [HttpDelete("{ID}")]
        public IActionResult ELiminarProducto(int id) 
        {
            var producto = productos.FirstOrDefault(p => p.ID == id);
            if (producto==null)
            {
                return NotFound();
            }
            productos.Remove(producto);
            return NoContent();
        }



    }
}
