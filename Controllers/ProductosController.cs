using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ProductoController : ControllerBase
{
    ProductosRepositorySQL prSQL = new ProductosRepositorySQL();
    
    static int autonumerico;
    ProductoController()
    {
        autonumerico = prSQL.GetProductos().Max(p => p.IdProducto);
    }    

    [HttpGet("/api/Producto")]
    public IActionResult GetProductos()
    {
        List<Producto> productos = prSQL.GetProductos();
    
        return Ok(productos);
    }
    
    //[HttpPut("")]



}