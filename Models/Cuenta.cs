using System.ComponentModel.DataAnnotations.Schema;

namespace BancoPC2_CAMPOS.Models
{
    [Table("t_cuenta")]
    public class Cuenta
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public long Id { get; set;} 
       public string? NombreT { get; set;} 
       public string? TipoC { get; set;} 
       public string? SaldoI { get; set;} 
       public string? Email { get; set;} 
    }
}