using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VASPVTScrap.Models;
using Excel = Microsoft.Office.Interop.Excel;

namespace VASPVTScrap
{
  public partial class Form1 : Form
  {
    private BindingSource source { get; set; }
    private Response response { get; set; }
    private List<ExcelLicensija> ExcelData { get; set; }
    private Scrap request { get; set; }
    private int PagesOnServer { get; set; }
    private int PagesDownloaded { get; set; }
    private System.TimeSpan TookTimeSpan { get; set; }

    public Form1()
    {
      InitializeComponent();
      request = new Scrap();
      source = new BindingSource();
      response = new Response();
      PagesOnServer = 0;
      PagesDownloaded = 0;
      ExcelData = new List<ExcelLicensija>();
      source.DataSource = ExcelData;
      dataGridView1.DataSource = source;
      dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
      dataGridView1.BorderStyle = BorderStyle.Fixed3D;
      dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
      progressBar1.Visible = false;
    }


    private void FillData(Response responcePackage)
    {
      responcePackage.Data.ForEach(x => ExcelData.Add(new ExcelLicensija(x)));
      if (label_Count_Server.Text != responcePackage.Total.ToString())
        label_Count_Server.Text = responcePackage.Total.ToString();

      if (responcePackage.Errors != null)
      {
        label_Klaidos.Text = responcePackage.Errors.ToString();
      }

      label_Count_Parsiusta.Text = ExcelData.Count.ToString();
      source.ResetBindings(false);
    }



    private void button_Scrap_Click(object sender, EventArgs e)
    {
      if (backgroundWorker1.IsBusy)
      {
        MessageBox.Show("Siuntimas jau vyksta.");
        return;
      }
      progressBar1.Visible = true;
      progressBar1.Value = 0;
      progressBar1.Maximum = 100;
      progressBar1.Minimum = 0;
      PagesOnServer = 0;
      PagesDownloaded = 0;
      backgroundWorker1.RunWorkerAsync();
    }

    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
      var stopWatch = new Stopwatch();
      stopWatch.Start();
      var recordsPerPage = 500;
      response = request.requestL(1, recordsPerPage);
      var recordsOnServer = response.Total;
      var pagesTotal = recordsOnServer / recordsPerPage
                       + (recordsOnServer % recordsPerPage == 0 ? 0 : 1);
      response.Data.ForEach(x => ExcelData.Add(new ExcelLicensija(x)));
      PagesDownloaded++;
      PagesOnServer = pagesTotal;
      backgroundWorker1.ReportProgress(100 / pagesTotal);
      for (int i = 2; i <= pagesTotal; i++)
      {
        Thread.Sleep(5000);
        response = request.requestL(i, recordsPerPage);
        response.Data.ForEach(x => ExcelData.Add(new ExcelLicensija(x)));
        PagesDownloaded++;
        backgroundWorker1.ReportProgress(i * 100 / pagesTotal);
      }
      stopWatch.Stop();
      TookTimeSpan = stopWatch.Elapsed;
      MessageBox.Show($"Duomenys parsiūsti per - {TookTimeSpan.TotalMinutes.ToString("##.##")} min.");
    }

    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      progressBar1.Value = e.ProgressPercentage;
      source.DataSource = ExcelData;
      dataGridView1.DataSource = source;
      if (label_Count_Server.Text != response.Total.ToString())
        label_Count_Server.Text = response.Total.ToString();

      if (response.Errors != null)
      {
        label_Klaidos.Text = response.Errors.ToString();
      }
      label_Count_Parsiusta.Text = ExcelData.Count.ToString();
      label_Puslapiu_Parsiusta.Text = PagesDownloaded.ToString();
      label_Puslapiu_Serveryje.Text = PagesOnServer.ToString();
      source.ResetBindings(false);
     // this.Refresh();
    }

    private void button_Scrap_Stop_Click(object sender, EventArgs e)
    {
      if (backgroundWorker1.IsBusy)
      {
        backgroundWorker1.CancelAsync();
        progressBar1.Visible = false;
      }
    }

    private void CreateExcelFile()
    {
      if (ExcelData.Count == 0)
      {
        MessageBox.Show("Nėra įrašų.");
        return;
      }
      var xlApp = new Excel.Application();
      xlApp.Workbooks.Add();
      var xlSheet = xlApp.ActiveSheet as Excel.Worksheet;
      xlApp.Visible = true;
      xlSheet.Cells[1, 1] = "Spaudo Nr.";
      xlSheet.Cells[1, 2] = "Spaudo tipas";
      xlSheet.Cells[1, 3] = "Vardas";
      xlSheet.Cells[1, 4] = "Pavardė";
      xlSheet.Cells[1, 5] = "Licencijos Nr.";
      xlSheet.Cells[1, 6] = "Profesinė kvalifikacija";
      xlSheet.Cells[1, 7] = "Licencijos išdavimo data";
      xlSheet.Cells[1, 8] = "Licencijos būsena";
      xlSheet.Cells[1, 9] = "Įsakymo data ir Nr.";
      xlSheet.Cells[1, 10] = "Priežiūros data";
      xlSheet.Cells[1, 11] = "Priežiūros įsakymo Nr.";
      xlSheet.Range["A1", "K1"].WrapText = true;

      for (int i = 0; i < ExcelData.Count; i++)
      {
        xlSheet.Cells[i + 2, 1] = ExcelData[i].Spaudo_Nr;
        xlSheet.Cells[i + 2, 2] = ExcelData[i].Spaudo_tipas;
        xlSheet.Cells[i + 2, 3] = ExcelData[i].Vardas;
        xlSheet.Cells[i + 2, 4] = ExcelData[i].Pavardė;
        xlSheet.Cells[i + 2, 5] = ExcelData[i].Licencijos_Nr;
        xlSheet.Cells[i + 2, 6] = ExcelData[i].Profesinė_kvalifikacija;
        xlSheet.Cells[i + 2, 7] = ExcelData[i].Licencijos_išdavimo_data;
        xlSheet.Cells[i + 2, 8] = ExcelData[i].Licencijos_būsena;
        xlSheet.Cells[i + 2, 9] = ExcelData[i].Įsakymo_data_ir_Nr;
        xlSheet.Cells[i + 2, 10] = ExcelData[i].Priežiūros_data;
        xlSheet.Cells[i + 2, 11] = ExcelData[i].Priežiūros_įsakymo_Nr;
      }

      xlSheet.Range["A1", "K" + (ExcelData.Count + 1)].AutoFormat(Format:
        Excel.XlRangeAutoFormat.xlRangeAutoFormatColor2);
    }

    private void button_Create_Excel_Click(object sender, EventArgs e)
    {
      CreateExcelFile();
    }
  }
}
