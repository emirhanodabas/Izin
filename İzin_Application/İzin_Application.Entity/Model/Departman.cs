using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace İzin_Application.Entity.Model
{
    public class Departman
    {
        public int ID { get; set; }
        public string Departman_Adi { get; set; }
        public string Aciklama { get; set; }
        public bool Durumu { get; set; }

        public virtual ICollection<Personel> Personel { get; set; }
    }
}
