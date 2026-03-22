using BCrypt.Net;

namespace Hospital.API.Services
{
    public class PasswordService
    {
        public string HashPassword(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public bool VerifyPassword(string senha, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(senha, hash);
        }
    }
}