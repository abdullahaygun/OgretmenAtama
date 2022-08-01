using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using OgretmenAtama.Client.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgretmenAtama.Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public List<Iller> GetDataIller(string path)
        {
            List<string> ilHizmetBolgesi = new List<string>();
            List<string> ilKodu = new List<string>();
            List<string> ilAdi = new List<string>();
            List<Iller> iller = new List<Iller>();

            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb;
            Worksheet ws;
            wb = excel.Workbooks.Open(path);
            ws = (Worksheet)wb.Worksheets[1];
            Range cell1 = ws.Range["A7:A56199"];
            Range cell2 = ws.Range["B7:B56199"];
            Range cell3 = ws.Range["C7:C56199"];

            try
            {
                foreach (var val in cell1.Value)
                {
                    ilHizmetBolgesi.Add(val.ToString());
                }

                foreach (var val in cell2.Value)
                {
                    ilKodu.Add(val.ToString());
                }

                foreach (var val in cell3.Value)
                {
                    ilAdi.Add(val.ToString());
                }
                iller.Add(new Iller
                {
                    IlHizmetBolgesi = ilHizmetBolgesi[0],
                    IlKodu = ilKodu[0],
                    IlAdi = ilAdi[0],
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.UtcNow,
                    IsActive = true,
                });

                for (int i = 0; i < ilHizmetBolgesi.Count; i++)
                {
                    if (!iller.Any(x => x.IlKodu == ilKodu[i]))
                    {
                        iller.Add(new Iller { IlHizmetBolgesi = ilHizmetBolgesi[i], IlKodu = ilKodu[i], IlAdi = ilAdi[i] });
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                wb.Close();
            }
            return iller;
        }

        public List<Ilceler> GetDataIlceler(string path)
        {
            List<string> ilKodu = new List<string>();
            List<string> ilceAdi = new List<string>();
            List<Ilceler> ilceler = new List<Ilceler>();

            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb;
            Worksheet ws;
            wb = excel.Workbooks.Open(path);
            ws = (Worksheet)wb.Worksheets[1];
            Range cell1 = ws.Range["A7:A56199"];
            Range cell2 = ws.Range["D7:D56199"];

            try
            {
                foreach (var val in cell1.Value)
                {
                    ilKodu.Add(val.ToString());
                }

                foreach (var val in cell2.Value)
                {
                    ilceAdi.Add(val.ToString());
                }
                ilceler.Add(new Ilceler
                {
                    IlceAdi = ilceAdi[0],
                    IlKodu = ilKodu[0],
                    IlceKodu = "0",
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.UtcNow,
                    IsActive = true,
                });

                for (int i = 0; i < ilceAdi.Count; i++)
                {
                    if (!ilceler.Any(x => x.IlceAdi == ilceAdi[i]))
                    {
                        ilceler.Add(new Ilceler { IlceAdi = ilceAdi[i], IlKodu = ilKodu[i], IlceKodu = (i + 1).ToString() });
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                wb.Close();
            }
            return ilceler;
        }

        public List<Alanlar> GetDataAlanlar(string path)
        {
            List<string> alanKodu = new List<string>();
            List<string> alanAdi = new List<string>();
            List<Alanlar> alanlar = new List<Alanlar>();

            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb;
            Worksheet ws;
            wb = excel.Workbooks.Open(path);
            ws = (Worksheet)wb.Worksheets[1];
            Range cell1 = ws.Range["G7:G56199"];
            Range cell2 = ws.Range["H7:H56199"];

            try
            {
                foreach (var val in cell1.Value)
                {
                    alanKodu.Add(val.ToString());
                }

                foreach (var val in cell2.Value)
                {
                    alanAdi.Add(val.ToString());
                }

                alanlar.Add(new Alanlar
                {
                    AlanAdi = alanAdi[0],
                    AlanKodu = alanKodu[0],
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.UtcNow,
                    IsActive = true,
                });

                for (int i = 0; i < alanKodu.Count; i++)
                {
                    if (!alanlar.Any(x => x.AlanKodu == alanKodu[i]))
                    {
                        alanlar.Add(new Alanlar { AlanAdi = alanAdi[i], AlanKodu = alanKodu[i] });
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                wb.Close();
            }
            return alanlar;
        }

        public List<Kurumlar> GetDataKurumlar(string path)
        {
            List<string> kurumKodu = new List<string>();
            List<string> kurumAdi = new List<string>();
            List<string> kurumHizmetAlani = new List<string>();
            List<string> kurumTipi = new List<string>();
            List<string> ilceAdi = new List<string>();
            List<string> ilKodu = new List<string>();
            List<Kurumlar> kurumlar = new List<Kurumlar>();

            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb;
            Worksheet ws;
            wb = excel.Workbooks.Open(path);
            ws = (Worksheet)wb.Worksheets[1];
            Range cell1 = ws.Range["E7:E56199"];
            Range cell2 = ws.Range["F7:F56199"];
            Range cell3 = ws.Range["I7:I56199"];
            Range cell4 = ws.Range["K7:K56199"];
            Range cell5 = ws.Range["D7:D56199"];
            Range cell6 = ws.Range["B7:B56199"];

            try
            {
                foreach (var val in cell1.Value)
                {
                    kurumKodu.Add(val.ToString());
                }

                foreach (var val in cell2.Value)
                {
                    kurumAdi.Add(val.ToString());
                }

                foreach (var val in cell3.Value)
                {
                    kurumHizmetAlani.Add(val.ToString());
                }

                foreach (var val in cell4.Value)
                {
                    kurumTipi.Add(val.ToString());
                }

                foreach (var val in cell5.Value)
                {
                    ilceAdi.Add(val.ToString());
                }

                foreach (var val in cell6.Value)
                {
                    ilKodu.Add(val.ToString());
                }

                kurumlar.Add(new Kurumlar
                {
                    KurumKodu = kurumKodu[0],
                    KurumAdi = kurumAdi[0],
                    KurumHizmetAlani = kurumHizmetAlani[0],
                    KurumTipi = kurumTipi[0],
                    IlceAdi = ilceAdi[0],
                    IlKodu = ilKodu[0],
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.UtcNow,
                    IsActive = true,
                });

                for (int i = 1; i < kurumKodu.Count; i++)
                {
                    kurumlar.Add(new Kurumlar
                    {
                        KurumAdi = kurumAdi[i],
                        KurumHizmetAlani = kurumHizmetAlani[i],
                        KurumKodu = kurumKodu[i],
                        KurumTipi = kurumTipi[i],
                        IlceAdi = ilceAdi[i],
                        IlKodu = ilKodu[i]
                    });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                wb.Close();
            }
            return kurumlar;
        }

        public List<KurumlarAlanlar> GetDataKurumlarAlanlar(string path)
        {
            List<string> kurumKodu = new List<string>();
            List<string> alanKodu = new List<string>();
            List<string> bosKontenjan = new List<string>();
            List<KurumlarAlanlar> kurumlarAlanlar = new List<KurumlarAlanlar>();

            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb;
            Worksheet ws;
            wb = excel.Workbooks.Open(path);
            ws = (Worksheet)wb.Worksheets[1];
            Range cell1 = ws.Range["E7:E56199"];
            Range cell2 = ws.Range["G7:G56199"];
            Range cell3 = ws.Range["J7:J56199"];

            try
            {
                foreach (var val in cell1.Value)
                {
                    kurumKodu.Add(val.ToString());
                }

                foreach (var val in cell2.Value)
                {
                    alanKodu.Add(val.ToString());
                }

                foreach (var val in cell3.Value)
                {
                    bosKontenjan.Add(val.ToString());
                }

                kurumlarAlanlar.Add(new KurumlarAlanlar
                {
                    AlanKodu = alanKodu[0],
                    BosKontenjan = bosKontenjan[0],
                    KurumKodu = kurumKodu[0],
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.UtcNow,
                    IsActive = true,
                });

                for (int i = 1; i < alanKodu.Count; i++)
                {
                    kurumlarAlanlar.Add(new KurumlarAlanlar { AlanKodu = alanKodu[i], KurumKodu = kurumKodu[i], BosKontenjan = bosKontenjan[i] });

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                wb.Close();
            }
            return kurumlarAlanlar;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();

            string path = "";

            if (choofdlog.ShowDialog() == DialogResult.OK)

            {
                path = choofdlog.FileName;

                //iller tamamlandı.
                List<Iller> iller = new List<Iller>();
                iller = GetDataIller(path);

                //ilçeler tamamlandı.
                List<Ilceler> ilceler = new List<Ilceler>();
                ilceler = GetDataIlceler(path);

                //alanlar tamamlandı.
                List<Alanlar> alanlar = new List<Alanlar>();
                alanlar = GetDataAlanlar(path);

                //kurumlar tamamlandı.
                List<Kurumlar> kurumlar = new List<Kurumlar>();
                kurumlar = GetDataKurumlar(path);

                //kurumlarAlanlar tamamlandı.
                List<KurumlarAlanlar> kurumlarAlanlar = new List<KurumlarAlanlar>();
                kurumlarAlanlar = GetDataKurumlarAlanlar(path);

                t(iller, "api/DB/IllerEkle");
                
            }
        }

        public async Task t(object o,string apiPath)
        {
            // APİ ye verileri gönderme

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://ogretmenatamarobotu.herokuapp.com/");

            var content = JsonConvert.SerializeObject(o);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await client.PostAsync(apiPath, byteContent);
        }
    }
}
