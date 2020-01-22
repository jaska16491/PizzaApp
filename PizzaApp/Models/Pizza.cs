using System;
using System.Collections.Generic;

namespace PizzaApp.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            PizzaCala = new HashSet<PizzaCala>();
        }

        public int IdPizza { get; set; }
        public string Nazwa { get; set; }
        public int IdSos { get; set; }

        public virtual Sos IdSosNavigation { get; set; }
        public virtual PizzaMenu PizzaMenu { get; set; }
        public virtual ICollection<PizzaCala> PizzaCala { get; set; }
    }
}
