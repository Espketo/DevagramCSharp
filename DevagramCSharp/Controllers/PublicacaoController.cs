using DevagramCSharp.Dtos;
using DevagramCSharp.Models;
using DevagramCSharp.Repository;
using DevagramCSharp.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevagramCSharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublicacaoController : BaseController
    {
        private readonly ILogger<PublicacaoController> _logger;
        private readonly IPublicacaoRepository _publicacaoRepository;

        public PublicacaoController(ILogger<PublicacaoController> logger,
            IPublicacaoRepository publicacaoRepository,
            IUsuarioRepository usuarioRepository) : base(usuarioRepository)
        {
            _logger = logger;
            _publicacaoRepository = publicacaoRepository;
        }

        [HttpPost]
        public IActionResult Publicar([FromForm] PublicacaorequisicaoDto publicacaodto)
        {
            try
            {
                Usuario usuario = LerToken();
                CosmicService cosmicservice = new CosmicService();
                if(publicacaodto != null)
                {
                    if(String.IsNullOrEmpty(publicacaodto.Descricao) &&
                       String.IsNullOrWhiteSpace(publicacaodto.Descricao))
                    {
                        _logger.LogError("A descrição está inválida");
                        return BadRequest("É obrigatorio a descrição na publicação");
                    }
                    if(publicacaodto.Foto == null)
                    {
                        _logger.LogError("A foto está inválida");
                        return BadRequest("É obrigatorio a foto na publicação");
                    }

                    Publicacao publicacao = new Publicacao()
                    {
                        Descricao = publicacaodto.Descricao,
                        IdUsuario = usuario.Id,
                        Foto = cosmicservice.EnviarImagen(new ImagemDto { Imagem = publicacaodto.Foto, Nome = "publicacao" })
                    };
                    _publicacaoRepository.Publicar(publicacao);
                }
                return Ok("Publicação salva com sucesso!");
            }
            catch(Exception e)
            {
                _logger.LogError("Ocorreu um erro na Publicação: " + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorRespostaDto()
                {
                    Descricao = "Ocorreu um erro na publicação",
                    Status = StatusCodes.Status500InternalServerError
                });
            }
        }
    }
}
