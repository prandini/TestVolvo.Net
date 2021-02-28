using System;
using System.Collections.Generic;
using System.Text;

namespace App.Volvo.Business.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = new Guid();
        }

        public Guid Id { get; set; }
    }
}
