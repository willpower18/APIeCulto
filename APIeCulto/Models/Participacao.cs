using System;
using System.Collections.Generic;

namespace APIeCulto.Models
{
    public partial class Participacao
    {
        public int IdParticipacao { get; set; }
        public int IdCulto { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string ChaveApp { get; set; }

        public virtual Culto IdCultoNavigation { get; set; }
    }
}
