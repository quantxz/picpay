using Microsoft.AspNetCore.Mvc;
using Usuarios.Model;
using Usuarios.Service;

namespace Usuarios.Controller.Crud;

[Route("api/usuarios")]
[ApiController]
public class UsuariosCrudController : ControllerBase
{

    private readonly UsuariosCrudService UsuarioService;

    public UsuariosCrudController(UsuariosCrudService UsuarioService)
    {
        this.UsuarioService = UsuarioService;
    }

    [HttpPost("registrar")]
    public async Task<ActionResult<UsuariosModel>> RegistrarUsuario(UsuariosModel usuarios)
    {
        var result = await UsuarioService.RegistrarUsuario(usuarios);

        if (result["status"]?.ToString().Contains("erro") == true)
        {
            return BadRequest(result);
        }


        return Ok(result);
    }
}