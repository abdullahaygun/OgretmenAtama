using Microsoft.EntityFrameworkCore;
using OgretmenAtama.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgretmenAtama.Persistance.Data.Contexts
{
    public class OgretmenAtamaDbContext : DbContext
    {
        public OgretmenAtamaDbContext(DbContextOptions<OgretmenAtamaDbContext> options) : base(options)
        { }

        public DbSet<Alanlar> Alanlar { get; set; }
        public DbSet<Ilceler> Ilceler { get; set; }
        public DbSet<Iller> Iller { get; set; }
        public DbSet<Kurumlar> Kurumlar { get; set; }
        public DbSet<KurumlarAlanlar> KurumlarAlanlar { get; set; }
    }
}
