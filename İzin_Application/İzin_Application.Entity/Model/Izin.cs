using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace İzin_Application.Entity.Model
{
    public class Izin
    {
        public int ID { get; set; }
        public int PersonelID { get; set; }
        public virtual Personel Personel { get; set; }
        public int IzinTurId { get; set; }
        public virtual IzinTur IzinTur { get; set; }
        public DateTime IzinBaslangic { get; set; }
        public DateTime IzinBitis { get; set; }
        public string Aciklama { get; set; }
        public DateTime tarih { get; set; }
        public bool Durumu { get; set; }
    }
}
