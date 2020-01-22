using System;
using System.Collections.Generic;

namespace PizzaApp.Models
{
    public partial class Skladnik
    {
        public Skladnik()
        {
            PizzaCustom = new HashSet<PizzaCustom>();
            PizzaMenu = new HashSet<PizzaMenu>();
        }

        public int IdSkladnik { get; set; }
        public string Skladnik1 { get; set; }
        public decimal Cena { get; set; }

        public virtual ICollection<PizzaCustom> PizzaCustom { get; set; }
        public virtual ICollection<PizzaMenu> PizzaMenu { get; set; }
    }
}
