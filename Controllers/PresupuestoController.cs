using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("[controller]")]
public class PresupuestoController : ControllerBase
{
    PresupuestoRepositorySQL presupuestoSQL = new PresupuestoRepositorySQL();

    [HttpPost("/api/Presupuesto/{nombreDestinatario}")]

    public IActionResult InsertPresupuesto(string nombreDestinatario)
    {
        Presupuesto p = new Presupuesto();
        p.NombreDestinatario = nombreDestinatario;
        p.FechaCreacion = DateOnly.FromDateTime(DateTime.Now);

        presupuestoSQL.InsertPresupuesto(p);

        return Ok();
    }

    [HttpGet("/api/Presupuesto")]
    public IActionResult GetPresupuestos()
    {
        List<Presupuesto> presupuestos = new List<Presupuesto>();
        presupuestos = presupuestoSQL.GetPresupuestos();

        return Ok(presupuestos);
    }

}