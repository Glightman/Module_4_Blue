using CarShopAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShopAPI.Data
{
    public class CarShopContext : IdentityDbContext
    {
        public CarShopContext(DbContextOptions<CarShopContext> options) : base(options) { }
        public DbSet<Carro> Carro { get; set; }
    }
}
