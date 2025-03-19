namespace Api.Messages.Records
{
    public class CrudUsuario
    {   public record UsuarioDuplicado(string nome, string status, string causa);
        public record Sucesso(string nome, string status, string causa);
    }
}
