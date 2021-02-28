using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App.Volvo.Site.ViewModels
{
    public class CaminhaoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Modelo")]
        //[Required(ErrorMessage = "O campo Modelo é Obrigatório")]
        public ModeloViewModel Modelo { get; set; }

        [HiddenInput]
        public Guid ModeloId { get; set; }

        [DisplayName("Ano Fabricação")]
        [Required(ErrorMessage = "O campo Ano Fabricação é Obrigatório")]
        public short AnoFabricacao { get; set; }

        [DisplayName("Ano Modelo")]
        [Required(ErrorMessage = "O campo Ano M odelo é Obrigatório")]
        public short AnoModelo { get; set; }
        public IEnumerable<ModeloViewModel> Modelos { get; internal set; }
    }
}
