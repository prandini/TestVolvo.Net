using System;

namespace App.Volvo.Business.Models
{
    public class Caminhao : Entity
    {
        public Modelo Modelo { get; set; }
        public Guid ModeloId { get; set; }
        public short AnoFabricacao { get; set; }
        public short AnoModelo { get; set; }
    }
}
