namespace Hospital.API.Models
{
    public class Medico : Funcionario
    {
        public List<Especialidade> Especialidades { get; set;} = new();
        
    }
}