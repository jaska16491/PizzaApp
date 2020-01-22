using System;
using System.Collections.Generic;

namespace PizzaApp.Models
{
    public partial class Admin
    {
        public int IdAdmin { get; set; }
        public string Login { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
    }
}
