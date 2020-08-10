using System;
using System.Collections.Generic;

namespace APIeCulto.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public int IdTipoUsuario { get; set; }
        public int? IdIgreja { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public sbyte Ativo { get; set; }

        public virtual Igreja IdIgrejaNavigation { get; set; }
        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
    }
}
