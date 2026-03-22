namespace Hospital.API.Models
{
    public class Paciente : Usuario
    {
        public string? NumeroSus { get; set;}
        public string? Convenio { get; set; }
        public string? Telefone { get; set;}
        public string? Endereco { get; set;}
        
    }
}