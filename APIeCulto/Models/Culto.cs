using System;
using System.Collections.Generic;

namespace APIeCulto.Models
{
    public partial class Culto
    {
        public Culto()
        {
            Participacao = new HashSet<Participacao>();
        }

        public int IdCulto { get; set; }
        public int IdIgreja { get; set; }
        public string Nome { get; set; }
        public DateTime DataHora { get; set; }
        public string Preletor { get; set; }

        public virtual Igreja IdIgrejaNavigation { get; set; }
        public virtual ICollection<Participacao> Participacao { get; set; }
    }
}
