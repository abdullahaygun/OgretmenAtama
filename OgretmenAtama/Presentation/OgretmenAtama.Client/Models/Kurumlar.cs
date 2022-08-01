using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgretmenAtama.Client.Models
{
    public class Kurumlar:Base
    {
        public string IlKodu { get; set; }
        public string IlceAdi { get; set; }
        public string KurumKodu { get; set; }
        public string KurumAdi { get; set; }
        public string KurumHizmetAlani { get; set; }
        public string KurumTipi { get; set; }
        
    }
}
