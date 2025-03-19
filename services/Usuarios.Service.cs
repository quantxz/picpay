using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Api.Auth.TranferAuth;
using Api.Context.Database;
using Api.Messages.Records;
using Api.Transferences.Records;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Transference.Model;
using Usuarios.Model;
namespace Usuarios.Service
{
    public class UsuariosCrudService
    {
        private readonly DatabaseContext _database;

        // Construtor para injeção de dependência do DatabaseContext.
        public UsuariosCrudService(DatabaseContext database)
        {
            _database = database;
        }

        public async Task<JsonObject> RegistrarUsuario(UsuariosModel usuario)
        {

            var taskEmail = _database.Usuarios.FirstOrDefaultAsync(u => u.Email == usuario.Email);
            var taskCpf = _database.Usuarios.FirstOrDefaultAsync(u => u.Cpf == usuario.Cpf);

            await Task.WhenAny(taskEmail, taskCpf);

            if (taskEmail.Result != null || taskCpf.Result != null)
            {
                string mensagemErro;
                if (taskEmail.Result != null)
                {
                    mensagemErro = "Este email já foi cadastrado";
                }
                else
                {
                    mensagemErro = "Este CPF já foi cadastrado";
                }

                var erro = new CrudUsuario.UsuarioDuplicado(usuario.Name, "erro", mensagemErro);

                var jsonErro = JsonSerializer.Deserialize<JsonObject>(JsonSerializer.Serialize(erro));
                return jsonErro!;
            }

            _database.Usuarios.Add(usuario);
            await _database.SaveChangesAsync();

            var sucesso = new CrudUsuario.Sucesso(
                usuario.Name,
                "sucesso",
                "Meus parabéns, você foi cadastrado, já pode começar a utilizar nosso sistema"
            );

            var jsonSucesso = JsonSerializer.Deserialize<JsonObject>(JsonSerializer.Serialize(sucesso));
            return jsonSucesso!;
        }
    }
    public class UsuariosBankService
    {
        private readonly DatabaseContext _database;
        private readonly TransferAuthorizantion TransferAtuh;

        public UsuariosBankService(TransferAuthorizantion TransferAuthorizantionSys, DatabaseContext database)
        {
            TransferAtuh = TransferAuthorizantionSys;
            _database = database;
        }

        public async Task<JsonResult> TransferencesSystem(TransferenceModel usuarios)
        {

            var authorization = await TransferAtuh.AutorizarTransferenciaAsync();
            if (!authorization)
            {
                
                return new JsonResult(new TransferUnauthorizedMessage(usuarios.Cedente, "Desculpe, nao podemos permitir essa transacao"));
            }
            _database.Transferences.Add(usuarios);
            await _database.SaveChangesAsync();
            return new JsonResult(new TransferUnauthorizedMessage("sucesso", "Transferência autorizada e concluída com sucesso"));
        }
    }
}
