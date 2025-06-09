using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        //LAPTOP-AR4409OM 
   
 

    private static IConfiguration _configuration; // Statik alan

        static Context()
        {
            // Statik yapılandırıcı içinde yapılandırma oluştur
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }


         string connectionString = _configuration.GetConnectionString("MyDatabaseConnection");

       

        //static readonly string connectionString = "server=45.84.189.34\\localhost; database=bilgegul_netcorelaw; user=bilgegul_er; password=Gara4ever*";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {   
            optionsBuilder.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString));
        }
        public DbSet<Category> categories { get; set; }
        public DbSet<Makale> makales { get; set; }
        public DbSet<Dava> davas { get; set; }
        public DbSet<Admin> admins { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<SubScribe> subScribes { get; set; }
    }
}
