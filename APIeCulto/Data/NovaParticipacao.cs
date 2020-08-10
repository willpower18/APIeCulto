using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIeCulto.Models;

namespace APIeCulto.Data
{
    public class NovaParticipacao
    {
        public string key { get; set; }
        public Participacao participacao { get; set; }
    }
}
