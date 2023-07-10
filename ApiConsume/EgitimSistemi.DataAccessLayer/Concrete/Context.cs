using EgitimSistemi.EntityLayer.Concreate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimSistemi.DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-HNL7PLQ;initial catalog=EgitimSistemiApiDb; integrated security=true; TrustServerCertificate=True;");

        }
        public DbSet<Ogrenci> Ogrencis { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Dersler> Derslers { get; set; }
       
    }
}
