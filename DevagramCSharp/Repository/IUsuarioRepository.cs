using DevagramCSharp.Models;

namespace DevagramCSharp.Repository
{
    public interface IUsuarioRepository
    {
        public void Salvar(Usuario usuario);

        public bool VerificarEmail(string email);
    }
}
