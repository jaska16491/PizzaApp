using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpPost]
        public IActionResult Create(PizzaCala newPizzaCala)
        {
            _context.PizzaCala.Add(newPizzaCala);
            _context.SaveChanges();

            return StatusCode(201, newPizzaCala);

        }

        [HttpPut]
        public IActionResult Update(PizzaCala updatedPizzaCala)
        {
           

            if (_context.PizzaCala.Count(p=> p.IdPizzaCala == updatedPizzaCala.IdPizzaCala)==0)
            {
                return NotFound();
            }

            _context.PizzaCala.Attach(updatedPizzaCala);
            _context.Entry(updatedPizzaCala).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(updatedPizzaCala);

        }

        [HttpDelete("{idPizzaCala:int}")]
        public IActionResult Delete(int IdPizzaCala)
        {
            var pizzaC = _context.PizzaCala.FirstOrDefault(p => p.IdPizzaCala == IdPizzaCala);

            if(pizzaC == null)
            {
                return NotFound();

            }
            _context.PizzaCala.Remove(pizzaC);
            _context.SaveChanges();
            return Ok(pizzaC);

        }
        
       
    }
}