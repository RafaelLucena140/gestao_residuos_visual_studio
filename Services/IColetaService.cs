using gestao_residuos.Models;

namespace gestao_residuos.Services
{
    public interface IColetaService
    {
        IEnumerable<ColetaModel> ListarColetas();
        IEnumerable<ColetaModel> ListarClientes(int pagina = 0, int tamanho = 10);
        IEnumerable<ColetaModel> ListarColetasUltimaReferencia(int ultimoId = 0, int tamanho = 10);
        ColetaModel ObterColetaPorId(int id);
        void CriarColeta(ColetaModel coleta);
        void AtualizarColeta(ColetaModel coleta);
        void DeletarColeta(int id);

    }
}
