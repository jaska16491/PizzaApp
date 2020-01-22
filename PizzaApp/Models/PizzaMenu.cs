using System;
using System.Collections.Generic;

namespace PizzaApp.Models
{
    public partial class PizzaMenu
    {
        public int PizzaIdPizza { get; set; }
        public int SkladnikIdSkladnik { get; set; }

        public virtual Pizza PizzaIdPizzaNavigation { get; set; }
        public virtual Skladnik SkladnikIdSkladnikNavigation { get; set; }
    }
}
