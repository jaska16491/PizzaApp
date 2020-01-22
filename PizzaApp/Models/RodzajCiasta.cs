using System;
using System.Collections.Generic;

namespace PizzaApp.Models
{
    public partial class RodzajCiasta
    {
        public RodzajCiasta()
        {
            PizzaCala = new HashSet<PizzaCala>();
        }

        public int IdRodzajCiasta { get; set; }
        public string Rodzaj { get; set; }
        public decimal Cena { get; set; }

        public virtual ICollection<PizzaCala> PizzaCala { get; set; }
    }
}
