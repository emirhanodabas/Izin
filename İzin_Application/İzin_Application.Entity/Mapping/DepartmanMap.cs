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
    public class DepartmanMap : EntityTypeConfiguration<Departman>
    {
        public DepartmanMap()
        {
            this.ToTable("Tbl_Departman");
            this.Property(x => x.ID).HasColumnType("int");
            this.Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.Departman_Adi).HasColumnType("varchar").HasMaxLength(30);
            this.Property(x => x.Aciklama).HasColumnType("varchar").HasMaxLength(300);

        }
    }
}
