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
    public class ZamowieniasController : ControllerBase
    {
        private s16491Context _context;
        public ZamowieniasController(s16491Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetZamowienias()
        {
            return Ok(_context.Zamowienie.ToList());
        }

        [HttpGet("{idZamowienie:int}")]
        public IActionResult GetZamowienie(int idZamowienie)
        {
            var zamowienie = _context.Zamowienie.FirstOrDefault(p => p.IdZamowienie == idZamowienie);

            if (zamowienie == null)
            {
                return NotFound();
            }

            return Ok(zamowienie);
        }
    }
}
