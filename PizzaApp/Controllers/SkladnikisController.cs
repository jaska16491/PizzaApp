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
    public class SkladnikisController : ControllerBase
    {
        private s16491Context _context;
        public SkladnikisController(s16491Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Getskladnikis()
        {
            return Ok(_context.Skladnik.ToList());
        }

        [HttpGet("{idSkladnik:int}")]
        public IActionResult GetSkladnik(int idSkladnik)
        {
            var skladnik = _context.Skladnik.FirstOrDefault(p => p.IdSkladnik == idSkladnik);

            if (skladnik == null)
            {
                return NotFound();
            }

            return Ok(skladnik);
        }
    }
}
