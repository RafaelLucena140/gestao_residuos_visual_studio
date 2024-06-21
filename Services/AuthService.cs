using gestao_residuos.Models;

namespace gestao_residuos.Services
{
    public class AuthService : IAuthService
    {
        private List<UsuarioModel> _users = new List<UsuarioModel>
        {
            new UsuarioModel { Id = 1, Nome = "operador01", Senha = "pass123", Role = "operador"},
            new UsuarioModel { Id = 2, Nome = "analista01", Senha = "pass123", Role = "analista"},
            new UsuarioModel { Id = 3, Nome = "gerente01", Senha = "pass123", Role = "gerente"},
            new UsuarioModel { Id = 4, Nome = "operador02", Senha = "pass123", Role = "operador"},
            new UsuarioModel { Id = 5, Nome = "analista02", Senha = "pass123", Role = "analista"},
            new UsuarioModel { Id = 6, Nome = "gerente02", Senha = "pass123", Role = "gerente"},
            new UsuarioModel { Id = 7, Nome = "operador03", Senha = "pass123", Role = "operador"},
        };
        public UsuarioModel Authenticate(string nome, string senha)
        {
            return _users.FirstOrDefault(u => u.Nome == nome && u.Senha = senha);
        }
    }
}
