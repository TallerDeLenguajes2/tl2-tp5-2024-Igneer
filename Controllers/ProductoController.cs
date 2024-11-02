using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ProductoController : ControllerBase
{
    ProductosRepositorySQL prSQL = new ProductosRepositorySQL();
    
    [HttpGet("/api/Producto")]
    public IActionResult GetProductos()
    {
        List<Producto> productos = prSQL.GetProductos();
    
        return Ok(productos);
    }
    
    [HttpPost("/api/Producto/{descripcion}/{precio}")]
    
    public IActionResult InsertProducto(string descripcion, int precio)
    {
        prSQL.InsertProducto(descripcion, precio);

        return Ok();
    } 

    [HttpPut("/api/Producto/{id}/{descripcion}/{precio}")]

    public IActionResult UpdateProducto(int id, string descripcion, int precio)
    {
        prSQL.UpdateProducto(id, descripcion, precio);

        return Ok();
    }

    [HttpDelete("/api/Producto/{id}/")]

    public IActionResult DeleteProducto(int id)
    {
        prSQL.DeleteProducto(id);

        return Ok();
    }


}