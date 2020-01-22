using System;
using System.Collections.Generic;

namespace PizzaApp.Models
{
    public partial class PizzaCustom
    {
        public int IdPizzaCala { get; set; }
        public int SosIdSos { get; set; }
        public int SkladnikIdSkladnik { get; set; }

        public virtual PizzaCala IdPizzaCalaNavigation { get; set; }
        public virtual Skladnik SkladnikIdSkladnikNavigation { get; set; }
        public virtual Sos SosIdSosNavigation { get; set; }
    }
}
