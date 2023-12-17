using İzin_Application.Entity.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace İzin_Application.Entity.Mapping
{
    public class PersonelMap : EntityTypeConfiguration<Personel>
    {
        public PersonelMap()
        {
            this.ToTable("tblPersonel");
            this.Property(p => p.PersonelId).HasColumnType("int");
            this.Property(p => p.PersonelId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.PersonelAdi).HasColumnType("varchar").HasMaxLength(40);
            this.Property(p => p.PersonelSoyadi).HasColumnType("varchar").HasMaxLength(40);
            this.Property(p => p.PersonelEmail).HasColumnType("varchar").HasMaxLength(50);
            this.Property(p => p.PersonelKAdi).HasColumnType("varchar").HasMaxLength(30);
            this.Property(p => p.PersonelParola).HasColumnType("varchar").HasMaxLength(30);
            this.Property(p => p.GirisTarihi).HasColumnType("date");
            this.Property(p => p.Telefon).HasColumnType("varchar").HasMaxLength(15);
            this.Property(x => x.TC).HasColumnType("char").HasMaxLength(11);
            this.Property(x => x.IzinHak).HasColumnType("int");
            this.Property(x => x.Adres).HasColumnType("varchar").HasMaxLength(150);

            this.HasRequired(p => p.yetki).WithMany(p => p.Personels).HasForeignKey(p => p.YetkiId);
            this.HasRequired(p => p.departman).WithMany(p => p.Personel).HasForeignKey(p => p.DepartmanID);


        }
    }
}
