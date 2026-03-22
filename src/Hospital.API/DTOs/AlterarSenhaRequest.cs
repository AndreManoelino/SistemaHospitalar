namespace Hospital.API.DTOs;

public class AlterarSenhaRequest
{
    public required string CPF { get; set; }
    public  required string NovaSenha { get; set; }
}