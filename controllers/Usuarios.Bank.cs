using Microsoft.AspNetCore.Mvc;
using Usuarios.Model;
using Usuarios.Service;

namespace Usuarios.Controller.Bank;

[Route("api/usuarios")]
[ApiController]
public class UsuariosCrudController : ControllerBase {
    private readonly UsuariosBankService UsuarioService;

    public UsuariosCrudController(UsuariosBankService UsuarioService)
    {
        this.UsuarioService = UsuarioService;
    }

}