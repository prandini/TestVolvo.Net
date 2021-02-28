using System;
using System.Collections.Generic;
using System.Text;

namespace App.Volvo.Business.Models
{
    public class Modelo : Entity
    {
        public string Nome { get; set; }
        public IEnumerable<Caminhao> Caminhoes { get; set; }
        public bool IsPermitidoCadastro { get; set; }
    }
}
