using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace İzin_Application.Entity.Model
{
    public class Yetki
    {
        public int YetkiId { get; set; }
        public string YetkiAdi { get; set; }
        public string YetkiAciklama { get; set; }
        public bool YetkiDurumu { get; set; }

        public virtual ICollection<Personel> Personels { get; set; }
    }
}
