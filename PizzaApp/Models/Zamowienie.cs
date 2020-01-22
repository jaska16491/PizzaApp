using System;
using System.Collections.Generic;

namespace PizzaApp.Models
{
    public partial class Zamowienie
    {
        public int IdZamowienie { get; set; }
        public decimal KosztCalkowity { get; set; }
        public int PizzaCalaIdPizzaCala { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Email { get; set; }
        public int NrTelefonu { get; set; }
        public DateTime DataZamowienia { get; set; }
        public DateTime CzasDostawy { get; set; }

        public virtual PizzaCala PizzaCalaIdPizzaCalaNavigation { get; set; }
    }
}
