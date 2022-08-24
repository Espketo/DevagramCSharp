using DevagramCSharp.Models;

namespace DevagramCSharp.Repository
{
    public class ISeguidorRepository
    {
        public bool Seguir(Seguidor seguidor);
        public bool Desseguir(Seguidor seguidor);
        public Seguidor GetSeguidor(int idseguidor, int idseguido);
    }
}
