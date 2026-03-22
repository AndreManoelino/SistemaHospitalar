namespace Hospital.API.Models
{
    public class Especialidade
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }

        public List<Medico> Medicos { get; set; } = new();
    }
}