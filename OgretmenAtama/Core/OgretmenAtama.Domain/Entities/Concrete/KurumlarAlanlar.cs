using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgretmenAtama.Domain.Entities.Concrete
{
    public class KurumlarAlanlar:Base
    {
        public int KurumKodu { get; set; }
        public int AlanKodu { get; set; }
    }
}
