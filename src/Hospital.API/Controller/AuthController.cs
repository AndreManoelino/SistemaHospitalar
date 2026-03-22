using Hospital.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hospital.API.DTOs;
using Hospital.API.Services;

namespace Hospital.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly PasswordService _passwordService;
        private readonly TokenService _tokenService;

        public AuthController(
            AppDbContext context, 
            PasswordService passwordService, 
            TokenService tokenService)
        {
            _context = context;
            _passwordService = passwordService;
            _tokenService = tokenService;
        }

        // 🔐 LOGIN
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.CPF == request.CPF);

            if (usuario == null)
                return Unauthorized("Usuário não encontrado");

            // 🚨 Senha antiga (não criptografada)
            if (!usuario.SenhaHash.StartsWith("$2"))
            {
                return Unauthorized("Senha ainda não configurada. Solicite redefinição.");
            }

            // 🔐 Verificação de senha
            if (!_passwordService.VerifyPassword(request.Senha, usuario.SenhaHash))
                return Unauthorized("Senha inválida");

            // 🔁 Primeiro acesso
            if (usuario.PrimeiroAcesso)
            {
                return Ok(new
                {
                    primeiroAcesso = true,
                    mensagem = "Necessário alterar senha"
                });
            }

            // 🔐 Gerar token
            var token = _tokenService.GenerateToken(usuario);

            return Ok(new
            {
                token,
                usuario.Id,
                usuario.Nome,
                usuario.Email,
                usuario.Tipo
            });
        }

        // 🔄 ALTERAR SENHA
        [HttpPost("alterar-senha")]
        public async Task<IActionResult> AlterarSenha([FromBody] AlterarSenhaRequest request)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.CPF == request.CPF);

            if (usuario == null)
                return NotFound("Usuário não encontrado");

            // 🔐 Criptografa nova senha
            usuario.SenhaHash = _passwordService.HashPassword(request.NovaSenha);

            // ✔ Remove flag de primeiro acesso
            usuario.PrimeiroAcesso = false;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                mensagem = "Senha alterada com sucesso"
            });
        }
    }
}