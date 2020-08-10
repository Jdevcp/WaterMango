using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterMango.Data
{
    public static class DbInitializer
    {
        public static void Initialize(PlantDBContext context)
        {
            context.Database.EnsureCreated();

            if (context.Plants.Any())
            {
                return;   // DB has been seeded
            }

            var plants = new Plants[]
            {
                new Plants  {PlantName="Ficus",Status="Needs Water",TimeLastWatered=DateTime.Now.ToString()},
                new Plants {PlantName = "Daisy", Status = "Needs Water", TimeLastWatered =DateTime.Now.ToString() },
                new Plants {PlantName = "Sunflower", Status = "Needs Water", TimeLastWatered = DateTime.Now.ToString()},
                new Plants {PlantName = "Succulent", Status = "Needs Water", TimeLastWatered = DateTime.Now.ToString()},
                new Plants  {PlantName="Fern",Status="Needs Water",TimeLastWatered=DateTime.Now.ToString()}
            };
            foreach (Plants p in plants)
            {
                context.Plants.Add(p);
            }
            context.SaveChanges();
        }
    }
}