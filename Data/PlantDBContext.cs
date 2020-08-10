using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WaterMango;

namespace WaterMango.Data
{
    public class PlantDBContext: DbContext
    {
        public PlantDBContext(DbContextOptions<PlantDBContext> options) : base(options)
        {

        }

        public DbSet<Plants> Plants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plants>().ToTable("Plants").Property(a=> a.ID).ValueGeneratedOnAdd(); 
           
        }
    }
}
