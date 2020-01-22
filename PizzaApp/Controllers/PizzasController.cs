using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaApp.Models;

namespace PizzaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        private s16491Context _context;
        public PizzasController(s16491Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPizzas()
        {
            return Ok(_context.PizzaCala.ToList());
        }

        [HttpGet("{idPizzaCala:int}")]
        public IActionResult GetPizza(int idPizzaCala)
        {
            var pizza_cala = _context.PizzaCala.FirstOrDefault(p => p.IdPizzaCala == idPizzaCala);

            if(pizza_cala == null)
            {
                return NotFound();
            }

            return Ok(pizza_cala);
        }
    }
}