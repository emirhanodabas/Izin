using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace İzin_Application.Entity.Model
{
    public class Personel
    {
        public int PersonelId { get; set; }
        public string PersonelAdi { get; set; }
        public string PersonelSoyadi { get; set; }
        public string PersonelEmail { get; set; }
        public int DepartmanID { get; set; }
        public virtual Departman departman { get; set; }
        public string PersonelKAdi { get; set; }
        public string PersonelParola { get; set; }
        public DateTime GirisTarihi { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public string TC { get; set; }
        public virtual int IzinHak { get; set; }
        public virtual int AnnelikIzinHak { get; set; }
        public virtual int EvlilikIzinHak { get; set; }
        public virtual int OlumIzinHak { get; set; }
        public virtual int DogumIzinHak { get; set; }
        public virtual int CenazeIzinHak { get; set; }
        public virtual int UcretsizIzinHak { get; set; }
        public bool Durumu { get; set; }
        public int YetkiId { get; set; }
        
        public virtual Yetki yetki { get; set; }
        public ICollection<Izin> izins { get; set; }
    }
}
