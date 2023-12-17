using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace İzin_Application.Entity.Model
{
    public class IzinTur
    {
        public int IzinTurId { get; set; }
        public string IzinTuru { get; set; }
        public string IzinSure { get; set; }
        public string Aciklama { get; set; }
        public bool Durumu { get; set; }
        public ICollection<Izin> izins { get; set; }
    }
}
