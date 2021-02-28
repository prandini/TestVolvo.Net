using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App.Volvo.Site.ViewModels
{
    public class ModeloViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Modelo")]
        [Required(ErrorMessage ="O campo Nome é Obrigatório")]
        public string Nome { get; set; }

        [DisplayName("Permitido Cadastro")]
        public bool IsPermitidoCadastro { get; set; }

        public IEnumerable<CaminhaoViewModel> Caminhoes { get; set; }
    }
}
