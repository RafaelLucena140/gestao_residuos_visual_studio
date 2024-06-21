using gestao_residuos.Models;

namespace gestao_residuos.Services
{
    public interface IAuthService
    {
        UsuarioModel Authenticate(string nome, string senha);

    }
}
