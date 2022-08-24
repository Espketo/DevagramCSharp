using System.ComponentModel.DataAnnotations.Schema;

namespace DevagramCSharp.Models
{
    public class Publicacao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public virtual Usuario Usuario { get; private set; }
    }
}
