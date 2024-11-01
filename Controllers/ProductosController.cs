using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ProductoController : ControllerBase
{
    ProductosRepository pr = new ProductosRepository();
    
    [HttpGet("/api/Producto")]
    public IActionResult listarProductosExistentes()
    {
        List<Producto> productos = pr.listarProductosExistentes();
    
        return Ok(productos);
    }
    



}