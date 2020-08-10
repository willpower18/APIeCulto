using System;
using System.Collections.Generic;

namespace APIeCulto.Models
{
    public partial class Igreja
    {
        public Igreja()
        {
            Culto = new HashSet<Culto>();
            Usuario = new HashSet<Usuario>();
        }

        public int IdIgreja { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Responsavel { get; set; }
        public string Tradicao { get; set; }
        public int Capacidade { get; set; }
        public int Ativo { get; set; }

        public virtual ICollection<Culto> Culto { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
