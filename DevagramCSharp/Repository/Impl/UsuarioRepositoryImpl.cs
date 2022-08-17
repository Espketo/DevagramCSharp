using DevagramCSharp.Models;

namespace DevagramCSharp.Repository.Impl
{
    public class UsuarioRepositoryImpl : IUsuarioRepository
    {

        private readonly DevagramContext _context;

        public UsuarioRepositoryImpl (DevagramContext context)
        {
            _context = context;
        }

        public void Salvar(Usuario usuario)
        {
            _context.Add(usuario);
            _context.SaveChanges();
        }
    }
}
