using Microsoft.AspNetCore.Mvc;
using ClienteAPI.Data;  // Tu namespace de datos/modelos

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly BdClientesContext _context;

    public ClientesController(BdClientesContext context)
    {
        _context = context;
    }

    // GET: api/clientes
    [HttpGet]
    public IActionResult GetClientes()
    {
        try
        {
            var clientes = _context.Clientes.ToList();
            return Ok(clientes);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error al obtener clientes: {ex.Message}");
        }
    }


    // GET: api/clientes/5
    [HttpGet("{id}")]
    public IActionResult GetCliente(int id)
    {
        var cliente = _context.Clientes.Find(id);
        if (cliente == null)
            return NotFound();
        return Ok(cliente);
    }

    // DELETE: api/clientes/5
    [HttpDelete("{id}")]
    public IActionResult EliminarCliente(int id)
    {
        var cliente = _context.Clientes.Find(id);
        if (cliente == null)
            return NotFound();

        _context.Clientes.Remove(cliente);
        _context.SaveChanges();
        return NoContent();
    }
}
