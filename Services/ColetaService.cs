using gestao_residuos.Models;

namespace gestao_residuos.Services
{
    public class ColetaService : IColetaService
    {
        private readonly IColetaRepository _repository;
        public ColetaService(IColetaRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ColetaModel>ListarColetas() => _repository.GetAll();
        public IEnumerable<ColetaModel> ListarColetas(int pagina = 1, int tamanho = 10) 
        {
            return _repository.GetAll(pagina,tamanho);
        }
        public IEnumerable<ColetaModel> ListarColetasUltimaReferencia(int ultimoId = 0, int tamanho = 10)
        {
            return _repository.GetAll(ultimoId, tamanho);
        }
        public ColetaModel ObterColetaPorId(int id) => _repository.GetById(id);
        public void CriarColeta(ColetaModel coleta) => _repository.Add(coleta);
        public void AtualizarColeta(ColetaModel coleta) => _repository.Update(coleta);
        public void DeletarColeta(int id)
        {
            var coleta = _repository.GetById(id);
            
            if (coleta != null)
            {
                _repository.Delete(coleta);
            }
        }
    }
}
