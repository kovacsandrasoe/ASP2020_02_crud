using ASP_202002_CarCrud.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_202002_CarCrud.Data
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions opt)
            :base(opt)
        {

        }

        public DbSet<Car> Cars { get; set; }
    }
}
