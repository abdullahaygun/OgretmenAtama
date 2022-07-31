using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgretmenAtama.Domain.Entities.Concrete
{
    public class Iller:Base
    {
        public byte IlKodu { get; set; }
        public string IlAdi { get; set; }
        public byte IlHizmetBolgesi { get; set; }
    }
}
