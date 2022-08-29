using DevagramCSharp.Models;

namespace DevagramCSharp.Repository
{
    public interface ICurtidaRepository
    {
        public void Curtir(Curtida curtida);
        public void Descurtir(Curtida curtida);
        public Curtida GetCurtida(int idPublicacao, int idUsuario);
        List<Curtida> GetCurtidaPorPublicacao(int idPublicacao);
    }
}