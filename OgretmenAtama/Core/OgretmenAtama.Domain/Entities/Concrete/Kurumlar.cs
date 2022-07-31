using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgretmenAtama.Domain.Entities.Concrete
{
    public class Kurumlar:Base
    {
        public int KurumKodu { get; set; }
        public string KurumAdi { get; set; }
        public byte KurumHizmetAlani { get; set; }
        public byte KurumTipi { get; set; }
        
    }
}
