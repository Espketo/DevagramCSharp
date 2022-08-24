using DevagramCSharp.Dtos;
using DevagramCSharp.Models;
using DevagramCSharp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DevagramCSharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeguidorController : BaseController
    {
        private readonly ILogger<SeguidorController> _logger;
        private readonly ISeguidorRepository _seguidorRepository;

        public SeguidorController (ILogger<SeguidorController> logger, ISeguidorRepository seguidorRepository,
            IUsuarioRepository usuarioRepository) : base(usuarioRepository)
        {
            _logger = logger;
            _seguidorRepository = seguidorRepository;
        }

        [HttpPut]
        public IActionResult Seguir(int idSeguido)
        {
            try
            {
                Usuario usuarioSeguido = _usuarioRepository.GetUsuarioPorId(idSeguido);
                Usuario usuarioseguidor = LerToken();

                if (usuarioseguidor != null)
                {
                    Seguidor seguidor = _seguidorRepository.GetSeguidor(usuarioseguidor.Id, usuarioSeguido.Id);
                    if (seguidor != null)
                    {
                        _seguidorRepository.Desseguir(seguidor);
                        return Ok("Seguir ou desseguir realizado com sucesso!");
                    }
                    else
                    {
                        Seguidor seguidornovo = new Seguidor()
                        {
                            IdUsuarioSeguido = usuarioSeguido.Id,
                            IdUsuarioSeguidor = usuarioseguidor.Id

                        };
                        _seguidorRepository.Seguir(seguidornovo);
                        return Ok("Seguir ou desseguir realizado com sucesso!");
                    }
                }
                else
                {
                    return BadRequest("Ocorreu um erro ao Seguir/Desseguir");
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Ocorreu um erro no login: " + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorRespostaDto()
                {
                    Descricao = "Ocorreu um erro ao fazer o login",
                    Status = StatusCodes.Status500InternalServerError
                });
            }
        }
    }
}
