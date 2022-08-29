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
        private readonly IComentarioRepository _comentarioRepository;
        private readonly ICurtidaRepository _curtidaRepository;

        public PublicacaoController(ILogger<PublicacaoController> logger,
            IPublicacaoRepository publicacaoRepository, IUsuarioRepository usuarioRepository,
            IComentarioRepository comentarioRepository, ICurtidaRepository curtidaRepository) : base(usuarioRepository)
        {
            _logger = logger;
            _publicacaoRepository = publicacaoRepository;
            _comentarioRepository = comentarioRepository;
            _curtidaRepository = curtidaRepository;
        }

        [HttpPost]
        public IActionResult Publicar([FromForm] PublicacaorequisicaoDto publicacaodto)
        {
            try
            {
                Usuario usuario = LerToken();
                CosmicService cosmicservice = new CosmicService();
                if (publicacaodto != null)
                {
                    if (String.IsNullOrEmpty(publicacaodto.Descricao) &&
                        String.IsNullOrWhiteSpace(publicacaodto.Descricao))
                    {
                        _logger.LogError("A descrição está inválida");
                        return BadRequest("É obrigatório a descrição na publicação");
                    }
                    if (publicacaodto.Foto == null)
                    {
                        _logger.LogError("A foto está inválida");
                        return BadRequest("É obrigatório a foto na publicação");
                    }

                    Publicacao publicacao = new Publicacao()
                    {
                        Descricao = publicacaodto.Descricao,
                        IdUsuario = usuario.Id,
                        Foto = cosmicservice.EnviarImagem(new ImagemDto { Imagem = publicacaodto.Foto, Nome = "publicacao" })
                    };
                    _publicacaoRepository.Publicar(publicacao);
                }

                return Ok("Publicação salva com sucesso!");

            }
            catch (Exception e)
            {
                _logger.LogError("Ocorreu um erro na publicação: " + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorRespostaDto()
                {
                    Descricao = "Ocorreu um erro na publicação",
                    Status = StatusCodes.Status500InternalServerError
                });
            }
        }


        [HttpGet]
        [Route("feed")]
        public IActionResult FeedHome()
        {
            try
            {
                List<PublicacaoFeedRespostaDto> feed = _publicacaoRepository.GetPublicacoesFeed(LerToken().Id);

                foreach (PublicacaoFeedRespostaDto feedResposta in feed)
                {
                    Usuario usuario = _usuarioRepository.GetUsuarioPorId(feedResposta.IdUsuario);
                    UsuarioRespostaDto usuarioRespostaDto = new UsuarioRespostaDto()
                    {
                        Nome = usuario.Nome,
                        Avatar = usuario.FotoPerfil,
                        IdUsuario = usuario.Id
                    };
                    feedResposta.Usuario = usuarioRespostaDto;

                    List<Comentario> comentarios = _comentarioRepository.GetCometarioPorPublicacao(feedResposta.IdPublicacao);
                    feedResposta.Comentarios = comentarios;

                    List<Curtida> curtidas = _curtidaRepository.GetCurtidaPorPublicacao(feedResposta.IdPublicacao);
                    feedResposta.Curtidas = curtidas;
                }

                return Ok(feed);
            }
            catch (Exception e)
            {
                _logger.LogError("Ocorreu um erro ao carregar o Feed da Home: " + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorRespostaDto()
                {
                    Descricao = "Ocorreu um erro ao carregar o Feed da Home",
                    Status = StatusCodes.Status500InternalServerError
                });
            }
        }

        [HttpGet]
        [Route("feedusuario")]
        public IActionResult FeedUsuario(int idUsuario)
        {
            try
            {
                List<PublicacaoFeedRespostaDto> feed = _publicacaoRepository.GetPublicacoesFeedUsuario(idUsuario);

                foreach (PublicacaoFeedRespostaDto feedResposta in feed)
                {
                    Usuario usuario = _usuarioRepository.GetUsuarioPorId(feedResposta.IdUsuario);
                    UsuarioRespostaDto usuarioRespostaDto = new UsuarioRespostaDto()
                    {
                        Nome = usuario.Nome,
                        Avatar = usuario.FotoPerfil,
                        IdUsuario = usuario.Id
                    };
                    feedResposta.Usuario = usuarioRespostaDto;

                    List<Comentario> comentarios = _comentarioRepository.GetCometarioPorPublicacao(feedResposta.IdPublicacao);
                    feedResposta.Comentarios = comentarios;

                    List<Curtida> curtidas = _curtidaRepository.GetCurtidaPorPublicacao(feedResposta.IdPublicacao);
                    feedResposta.Curtidas = curtidas;
                }

                return Ok(feed);
            }
            catch (Exception e)
            {
                _logger.LogError("Ocorreu um erro ao carregar o Feed do Usuario: " + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorRespostaDto()
                {
                    Descricao = "Ocorreu um erro ao carregar o Feed do Usuario",
                    Status = StatusCodes.Status500InternalServerError
                });
            }
        }
    }
}