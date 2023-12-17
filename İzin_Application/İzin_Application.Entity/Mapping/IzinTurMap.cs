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
    public class IzinTurMap : EntityTypeConfiguration<IzinTur>
    {
        public IzinTurMap()
        {
            this.ToTable("Tbl_IzinTur");
            this.Property(x => x.IzinTurId).HasColumnType("int");
            this.Property(x => x.IzinTurId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.IzinTuru).HasColumnType("varchar").HasMaxLength(25);
            this.Property(x => x.IzinSure).HasColumnType("varchar").HasMaxLength(10);
            this.Property(x => x.Aciklama).HasColumnType("varchar").HasMaxLength(100);

        }
    }
}