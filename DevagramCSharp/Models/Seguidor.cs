﻿using System.ComponentModel.DataAnnotations.Schema;

namespace DevagramCSharp.Models
{
    public class Seguidor
    {
        public int Id { get; set; }
        public int? IdUsuarioSeguidor { get; set; }
        public int? IdUsuarioSeguido { get; set; }
        
        [ForeignKey("IdUsuarioSeguidor")]
        public virtual Usuario UsuarioSeguidor { get; private set; }

        [ForeignKey("IdUsuarioSeguido")]
        public virtual Usuario UsuarioSeguido { get; private set; }
    }
}
