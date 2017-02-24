using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }
    }
}
