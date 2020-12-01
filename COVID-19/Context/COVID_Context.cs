using COVID_19.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVID_19.Context
{
    public class COVID_Context : DbContext
    {
        public COVID_Context() { 
        
        }
        public DbSet<Paciente> pacientes { get; set; }//padronizar plural

        public virtual DbSet<Login> logins { get; set; }
        public COVID_Context(DbContextOptions<COVID_Context> options) : base(options) { 
        
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                          .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                          .AddJsonFile("appsettings.json")
                          .Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("CovidDataBase"));
            }
        }

    }
    

}
