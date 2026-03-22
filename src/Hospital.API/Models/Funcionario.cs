namespace Hospital.API.Models
{
    public class Funcionario : Usuario
    {
        public NivelPermissao Nivel { get; set; } 
        public Guid CargoId { get; set;}
        public Cargo? Cargo { get; set; }       
    }
}