using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimSistemi.EntityLayer.Concreate
{
    public class Dersler
    {
        [Key]
        public int DersID { get; set; }
        public string DersAdi { get; set; }
        public string DersBolum { get; set; }
        public string BolumVideo { get; set; }
    }
}
