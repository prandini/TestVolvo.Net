using System;

namespace App.Volvo.Business.Models
{
    public class Caminhao : Entity
    {
        public short AnoFabricacao { get; set; }
        public short AnoModelo { get; set; }
        public string Chassi { get; set; }
        public Modelo Modelo { get; set; }
        public Guid ModeloId { get; set; }
        
    }
}
