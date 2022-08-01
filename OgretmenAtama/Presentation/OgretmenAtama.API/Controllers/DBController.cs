using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Office.Interop.Excel;
using OgretmenAtama.Domain.Entities.Concrete;
using OgretmenAtama.Persistance.Data.Contexts;
using System.Diagnostics;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace OgretmenAtama.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DBController : ControllerBase
    {
        private readonly OgretmenAtamaDbContext _context;

        public DBController(OgretmenAtamaDbContext context)
        {
            _context = context;
        }

        #region İller Ekleme
        [Route("[action]")]
        [HttpPost]
        public async Task IllerEkle(List<Iller> iller)
        {
           await _context.Iller.AddRangeAsync(iller);
           await _context.SaveChangesAsync();

        }
        #endregion

        #region İlçeler Ekleme
        [Route("[action]")]
        [HttpPost]
        public async Task IlcelerEkle(List<Ilceler> ilceler)
        {
            await _context.Ilceler.AddRangeAsync(ilceler);
            await _context.SaveChangesAsync();

        }
        #endregion

        #region Alanlar Ekleme
        [Route("[action]")]
        [HttpPost]
        public async Task AlanlarEkle(List<Alanlar> alanlar)
        {
            await _context.Alanlar.AddRangeAsync(alanlar);
            await _context.SaveChangesAsync();

        }
        #endregion

        #region Kurumlar Ekleme
        [Route("[action]")]
        [HttpPost]
        public async Task KurumlarEkle(List<Kurumlar> kurumlar)
        {
            await _context.Kurumlar.AddRangeAsync(kurumlar);
            await _context.SaveChangesAsync();

        }
        #endregion

        #region KurumlarAlanlar Ekleme
        [Route("[action]")]
        [HttpPost]
        public async Task KurumlarAlanlarEkle(List<KurumlarAlanlar> kurumlarAlanlar)
        {
            await _context.KurumlarAlanlar.AddRangeAsync(kurumlarAlanlar);
            await _context.SaveChangesAsync();

        }
        #endregion
    }
}
