using İzin_Application.Entity.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace İzin_Application.Entity.Model
{
    public class IzinContext : DbContext
    {
        public IzinContext() : base("name=DbIzin")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DepartmanMap());
            modelBuilder.Configurations.Add(new IzinMap());
            modelBuilder.Configurations.Add(new IzinTurMap());
            modelBuilder.Configurations.Add(new PersonelMap());
            modelBuilder.Configurations.Add(new YetkiMap());

        }
        public DbSet<Departman> Departman { get; set; }
        public DbSet<Izin> Izin { get; set; }
        public DbSet<IzinTur> IzinTur { get; set; }
        public DbSet<Personel> Personel { get; set; }
        public DbSet<Yetki> Yetki { get; set; }



    }
}

