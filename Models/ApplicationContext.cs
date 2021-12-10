using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WithoutDependencyCrud.Models
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext>options):base(options)
        {

        }
       public DbSet<Product> products { get; set; }

        //internal new  void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=localhost\\MSSQLSERVER01;Initial Catalog=CoreDb;Integrated Security=True")
        //}
    }
}
