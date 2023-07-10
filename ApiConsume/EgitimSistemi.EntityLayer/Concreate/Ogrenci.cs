using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimSistemi.EntityLayer.Concreate
{
    public class Ogrenci
    {
        [Key]
        public int OgrenciID { get; set; }
        public string OgrenciAd { get; set; }
        public string OgrenciSoyAd { get; set; }
        public string TC { get; set; }
        public string Adres { get; set; }
        public string Email { get; set; }
        public string Okul { get; set; }
        public string Sifre { get; set; }
        public DateTime KayıtTarihi { get; set; }


    }
}
