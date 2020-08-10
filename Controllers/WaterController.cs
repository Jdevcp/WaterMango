using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WaterMango.Data;
using System.Net;
using System.Web.Http;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace WaterMango.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WaterController : ControllerBase
    {
        private readonly PlantDBContext _context;

        public WaterController(PlantDBContext context)
        {
            _context = context;
        }


        [HttpPut("{id}")]
        public IActionResult WaterPlant(int? id)
        {
            DateTime currenttime = DateTime.Now;
            if (id != null)
            {

                var plant = _context.Plants.SingleOrDefault(p => p.ID == id);
               
                double seconds = currenttime.Subtract(Convert.ToDateTime(plant.TimeLastWatered)).TotalSeconds;
                if (seconds > 30)
                { 
                    plant.Status = "Watered";
                    plant.TimeLastWatered = currenttime.ToString();
                }
                else
                {
                    throw new ArgumentException("You need to wait atleast 30 seconds before you can water that plant again");
                }
                _context.SaveChanges();
            }
            return Ok(_context.Plants.ToList());
        }
    }
}
