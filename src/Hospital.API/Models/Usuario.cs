using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Hospital.API.Models
{
    public abstract class Usuario
    {
        public Guid Id { get; set; }

        public required string Nome { get; set;}
        public required string CPF { get; set;}

        public required string Email { get; set;}

        public required string SenhaHash { get; set;}

        public TipoUsuario Tipo { get; set;}
        public bool PrimeiroAcesso { get; set;} = true;

        public DateTime CriadoEm { get; set;} = DateTime.UtcNow;
        
    }
}