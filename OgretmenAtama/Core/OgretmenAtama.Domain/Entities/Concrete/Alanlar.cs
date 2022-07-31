using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgretmenAtama.Domain.Entities.Concrete
{
    public class Alanlar:Base
    {
        public int AlanKodu { get; set; }
        public string AlanAdi { get; set; }
    }
}
