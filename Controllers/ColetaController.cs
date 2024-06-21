using gestao_residuos.Models;
using gestao_residuos.Services;
using Microsoft.AspNetCore.Mvc;

namespace gestao_residuos.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class ColetaController : ControllerBase
    {

        private readonly IColetaService _coletaService;
        private readonly IMapper _mapper;

        public ColetaController(IColetaService coletaService, IMapper mapper)
        {
            _coletaService = coletaService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ColetaModel>> Get()
        {
            var coletas = _coletaService.ListarColetas();
            var viewModelList = _mapper.Map<IEnumerable<ColetaViewModel>>(coletas);
            return Ok(viewModelList);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ColetaPaginacaoViewModel>> Get([FromQuery] int pagina = 1, [FromQuery] int tamanho = 10)
        {
            var clientes = _coletaService.ListarClientes(pagina, tamanho);
            var viewModelList = _mapper.Map<IEnumerable<ClienteViewModel>>(clientes);

            var viewModel = new ClientePaginacaoViewModel
            {
                Clientes = viewModelList,
                CurrentPage = pagina,
                PageSize = tamanho
            };

            return Ok(viewModel);
        }


        [HttpGet("{id}")]
        public ActionResult<ColetaModel> Get(int id)
        {
            var coleta = _coletaService.ObterColetaPorId(id);

            if (coleta == null)
                return NotFound();

            var viewModel = _mapper.Map<ColetaModel>(coleta);
            return Ok(viewModel);
        }

        [HttpPost]
        public ActionResult Post([FromBody] ColetaCreateViewModel viewModel)
        {
            var coleta = _mapper.Map<ColetaModel>(viewModel);
            _coletaService.CriarColeta(coleta);
            return CreatedAtAction(nameof(Get), new { id = coleta.Id }, coleta);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ClienteUpdateViewModel viewModel)
        {
            var clienteExistente = _coletaService.ObterColetaPorId(id);
            if (clienteExistente == null)
                return NotFound();

            _mapper.Map(viewModel, clienteExistente);
            _coletaService.AtualizarColeta(clienteExistente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id) {
            _coletaService.DeletarColeta(id);
            return NoContent();
        }
    }
}
