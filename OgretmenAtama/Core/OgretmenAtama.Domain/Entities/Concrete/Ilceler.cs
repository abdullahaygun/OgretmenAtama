﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgretmenAtama.Domain.Entities.Concrete
{
    public class Ilceler:Base
    {
        public string IlKodu { get; set; }
        public string IlceKodu { get; set; }
        public string IlceAdi { get; set; }
    }
}
