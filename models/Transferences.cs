namespace Api.Transferences.Records
{
    public record TransferSucessMessage(int value, int payer, int payee);
    public record TransferUnauthorizedMessage(string name, string message)  ;
}