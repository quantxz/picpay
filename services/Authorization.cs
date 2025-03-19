namespace Api.Auth.TranferAuth;

public class TransferAuthorizantion
{
    private readonly HttpClient _httpClient;

    // Injeção de dependência do HttpClient
    public TransferAuthorizantion(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> AutorizarTransferenciaAsync()
    {
        // URL do serviço autorizador
        string url = "https://util.devi.tools/api/v2/authorize";

        // Fazendo a requisição GET para o serviço externo
        var response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            // Se a resposta for bem-sucedida, pode processar os dados retornados
            var responseData = await response.Content.ReadAsStringAsync();

            // Aqui, você pode verificar se a resposta é válida para continuar com a transferência
            // Exemplo: se a resposta contiver "authorized": true
            if (responseData.Contains("\"authorized\": true"))
            {
                // Se autorizado, retornar true
                return true;
            }
            else
            {
                // Se não autorizado, retornar false
                return false;
            }
        }
        else
        {
            // Se não foi bem-sucedido, lançar ou retornar false
            return false;
        }
    }
}