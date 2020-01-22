using System;
using System.Collections.Generic;

namespace PizzaApp.Models
{
    public partial class PizzaCala
    {
        public PizzaCala()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        
        public int IdPizzaCala { get; set; }
        public int IdPizza { get; set; }
        public decimal Cena { get; set; }
        public int IdRodzajCiasta { get; set; }
        public int IdRozmiar { get; set; }

        public virtual Pizza IdPizzaNavigation { get; set; }
        public virtual RodzajCiasta IdRodzajCiastaNavigation { get; set; }
        public virtual Rozmiar IdRozmiarNavigation { get; set; }
        public virtual PizzaCustom PizzaCustom { get; set; }
        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
