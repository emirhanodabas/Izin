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
    public class YetkiMap : EntityTypeConfiguration<Yetki>
    {
        public YetkiMap()
        {
            this.ToTable("Tbl_Yetki");
            this.Property(p => p.YetkiId).HasColumnType("int");
            this.Property(p => p.YetkiId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.YetkiAdi).HasColumnType("varchar").HasMaxLength(15);

        }
    }
}
