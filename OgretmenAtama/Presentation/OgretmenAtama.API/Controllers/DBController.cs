using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Office.Interop.Excel;
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

        #region deneme
        [Route("[action]")]
        [HttpGet]
        public async Task<char> Test(string filepath)
        {
            Microsoft.Office.Interop.Excel.Application excel = new();
            Workbook wb;
            Worksheet ws;

            wb = excel.Workbooks.Open(filepath);
            ws = (Worksheet)wb.Worksheets[1];

            Range cell = ws.Range["A1:A2"];

            foreach (var val in cell.Value.ToString())
            {
                Debug.WriteLine("test: " + val);
                return val;
            }
            return '0';

        }
        #endregion
    }
}
