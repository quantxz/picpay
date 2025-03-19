using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Usuarios.Enum;

namespace Usuarios.Model;


[Index(nameof(Email), IsUnique = true)]
[Index(nameof(Cpf), IsUnique = true)]
public class UsuariosModel
{
    [Key]
    public int Id { get; set; }
    public string Email { get; set; } = String.Empty;
    public string Name { get; set; } = String.Empty;
    public string Cpf { get; set; } = String.Empty;
    public string Senha { get; set; } = String.Empty;

    public int saldo { get; set; }
    public TipoUsuario TipoUsuairio { get; set; }
}