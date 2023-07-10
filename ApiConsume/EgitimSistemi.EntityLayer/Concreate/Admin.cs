using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimSistemi.EntityLayer.Concreate
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        public string Ad { get; set; }
        public string SoyAd { get; set; }
        public string Tc { get; set; }
        public string Adres { get; set; }
        public string TelNo { get; set; }
        public bool Yetki { get; set; }
        public string Sifre { get; set; }
    }
}
