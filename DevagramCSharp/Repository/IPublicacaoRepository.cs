using DevagramCSharp.Dtos;
using DevagramCSharp.Models;

namespace DevagramCSharp.Repository
{
    public interface IPublicacaoRepository
    {
        public void Publicar(Publicacao publicacao);
        List<PublicacaoFeedRespostaDto> GetPublicacoesFeed(int idUsuario);
        List<PublicacaoFeedRespostaDto> GetPublicacoesFeedUsuario(int idUsuario);
        int GetQtdePublicacoes(int idUsuario);
    }
}