using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Usuarios.Enum;

namespace Transference.Model;

public class TransferenceModel {
    [Key]
    public Guid TransferId { get; set; }

    public string Cedente { get; set; } = String.Empty;
    public string CpfCedente { get; set; } = String.Empty;


    public string Beneficiario { get; set; } = String.Empty;
    public string CpfBeneficiario { get; set; } = String.Empty;


    public int valor { get; set; }
    
    public DateTime dataDaTranferencia = DateTime.Now;
}