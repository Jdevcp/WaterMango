using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WaterMango.Data;
using System.Runtime.InteropServices;

namespace WaterMango.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class PlantController : ControllerBase
    {
        private readonly PlantDBContext _context;

        public PlantController(PlantDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Plants> Get()
        {
            DateTime currenttime = DateTime.Now;
            var plant = _context.Plants;
            foreach(Plants plants in plant)
            {
                if(currenttime.Subtract(Convert.ToDateTime(plants.TimeLastWatered)).TotalSeconds > 30 && plants.Status == "Watered")
                {
                    plants.Status = "Can be watered!";
                }
                if (currenttime.Subtract(Convert.ToDateTime(plants.TimeLastWatered)).TotalHours > 6)
                {
                    plants.Status = "NEEDS WATER ASAP";
                }


            }
            
            
            return _context.Plants.ToList();
            
        }

    }
}