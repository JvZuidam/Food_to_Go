using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Food_to_go.Models;

namespace Food_to_go.Data
{
    public class Food_to_goContext : DbContext
    {
        public Food_to_goContext (DbContextOptions<Food_to_goContext> options)
            : base(options)
        {
        }

        public DbSet<Cafeteria> Cafeteria { get; set; } = default!;

        public DbSet<CafeteriaWorker>? CafeteriaWorker { get; set; }

        public DbSet<Food_to_go.Models.MealPackage>? MealPackage { get; set; }

        public DbSet<Food_to_go.Models.Product>? Product { get; set; }

        public DbSet<Food_to_go.Models.Student>? Student { get; set; }
    }
}
