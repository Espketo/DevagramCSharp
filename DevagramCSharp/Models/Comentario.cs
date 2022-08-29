﻿using System.ComponentModel.DataAnnotations.Schema;

namespace DevagramCSharp.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int IdUsuario { get; set; }
        public int IdPublicacao { get; set; }

        [ForeignKey("IdUsuario")]
        public virtual Usuario Usuario { get; private set; }

        [ForeignKey("IdPublicacao")]
        public virtual Publicacao Publicacao { get; private set; }

    }
}