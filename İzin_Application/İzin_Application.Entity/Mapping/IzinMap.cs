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
    public class IzinMap : EntityTypeConfiguration<Izin>
    {
        public IzinMap()
        {
            this.ToTable("Tbl_Izin");
            this.Property(x => x.ID).HasColumnType("int");
            this.Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.IzinBaslangic).HasColumnType("date");
            this.Property(x => x.IzinBitis).HasColumnType("date");
            this.Property(x => x.Aciklama).HasColumnType("varchar").HasMaxLength(200);
            this.Property(x => x.tarih).HasColumnType("date");

            this.HasRequired(x => x.Personel).WithMany(x => x.izins).HasForeignKey(x => x.PersonelID);
            this.HasRequired(x => x.IzinTur).WithMany(x => x.izins).HasForeignKey(x => x.IzinTurId);

        }
    }
}
