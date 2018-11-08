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
    private ExcelData ExcelDataFromServer { get; set; }
    private ExcelData ExcelDataFromFile { get; set; }
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
      ExcelDataFromServer = new ExcelData();
      ExcelDataFromFile = new ExcelData();
      backgroundWorker_Read_Excel.RunWorkerAsync();
      source.DataSource = ExcelDataFromServer.Data;
      dataGridView1.DataSource = source;
      dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
      dataGridView1.BorderStyle = BorderStyle.Fixed3D;
      dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
    }


    private void FillData(Response responcePackage)
    {
      responcePackage.Data.ForEach(x => ExcelDataFromServer.Data.Add(new ExcelLicencija(x)));
      if (label_Count_Server.Text != responcePackage.Total.ToString())
        label_Count_Server.Text = responcePackage.Total.ToString();

      if (responcePackage.Errors != null)
      {
        label_Klaidos.Text = responcePackage.Errors.ToString();
      }

      label_Count_Parsiusta.Text = ExcelDataFromServer.Data.Count.ToString();
      source.ResetBindings(false);
    }



    private void button_Scrap_Click(object sender, EventArgs e)
    {
      if (backgroundWorker_Scrap.IsBusy)
      {
        MessageBox.Show("Siuntimas jau vyksta.");
        return;
      }
      progressBar1.Value = 0;
      PagesOnServer = 0;
      PagesDownloaded = 0;
      backgroundWorker_Scrap.RunWorkerAsync();
    }

    private void backgroundWorker_Scrap_DoWork(object sender, DoWorkEventArgs e)
    {
      var stopWatch = new Stopwatch();
      stopWatch.Start();
      var recordsPerPage = 50;
      response = request.requestL(1, recordsPerPage);
      var recordsOnServer = response.Total;
      var pagesTotal = recordsOnServer / recordsPerPage
                       + (recordsOnServer % recordsPerPage == 0 ? 0 : 1);
      response.Data.ForEach(x => ExcelDataFromServer.Data.Add(new ExcelLicencija(x)));
      PagesDownloaded++;
      PagesOnServer = pagesTotal;
      pagesTotal = 1;//Laikinas limitas
      backgroundWorker_Scrap.ReportProgress(100 / pagesTotal);
      for (int i = 2; i <= pagesTotal; i++)
      {
        Thread.Sleep(5000);
        response = request.requestL(i, recordsPerPage);
        response.Data.ForEach(x => ExcelDataFromServer.Data.Add(new ExcelLicencija(x)));
        PagesDownloaded++;
        backgroundWorker_Scrap.ReportProgress(i * 100 / pagesTotal);
      }
      stopWatch.Stop();
      TookTimeSpan = stopWatch.Elapsed;
      MessageBox.Show($"Duomenys parsiūsti per - {TookTimeSpan.TotalMinutes.ToString("##.##")} min.");
    }

    private void backgroundWorker_Scrap_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      progressBar1.Value = e.ProgressPercentage;
      if (label_Count_Server.Text != response.Total.ToString())
        label_Count_Server.Text = response.Total.ToString();

      if (response.Errors != null)
      {
        label_Klaidos.Text = response.Errors.ToString();
      }
      label_Count_Parsiusta.Text = ExcelDataFromServer.Data.Count.ToString();
      label_Puslapiu_Parsiusta.Text = PagesDownloaded.ToString();
      label_Puslapiu_Serveryje.Text = PagesOnServer.ToString();
      source.ResetBindings(false);
      // this.Refresh();
    }

    private void button_Scrap_Stop_Click(object sender, EventArgs e)
    {
      if (backgroundWorker_Scrap.IsBusy)
      {
        backgroundWorker_Scrap.CancelAsync();
        progressBar1.Visible = false;
      }
    }

    private void button_Create_Excel_Click(object sender, EventArgs e)
    {
      if (backgroundWorker_Read_Excel.IsBusy)
      {
        MessageBox.Show("Vyksta Excel failo skaitymas.");
        return;
      }
      if (ExcelDataFromServer.Data.Count == 0)
      {
        MessageBox.Show("Nėra įrašų.");
        return;
      }
      if (backgroundWorker_Save_Excel.IsBusy)
      {
        MessageBox.Show("Įrašymas jau vyksta.");
        return;
      }
      backgroundWorker_Save_Excel.RunWorkerAsync();
    }

    private void backgroundWorker_Read_Excel_DoWork(object sender, DoWorkEventArgs e)
    {
      backgroundWorker_Read_Excel.ReportProgress(40);
      ExcelDataFromFile.ReadExcelFile();
      backgroundWorker_Read_Excel.ReportProgress(80);
      ExcelDataFromFile.BackUpFile();
      backgroundWorker_Read_Excel.ReportProgress(100);
    }

    private void backgroundWorker_Save_Excel_DoWork(object sender, DoWorkEventArgs e)
    {
      backgroundWorker_Save_Excel.ReportProgress(40);
      ExcelDataFromServer.CreateExcelFile();
      backgroundWorker_Save_Excel.ReportProgress(100);
    }

    private void backgroundWorker_Save_Excel_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      progressBar_Excel_Save.Value = e.ProgressPercentage;
    }

    private void button_Read_Excel_Click(object sender, EventArgs e)
    {
      if (backgroundWorker_Read_Excel.IsBusy)
      {
        MessageBox.Show("Vyksta Excel failo skaitymas.");
        return;
      }
      if (backgroundWorker_Save_Excel.IsBusy)
      {
        MessageBox.Show("Įrašymas jau vyksta.");
        return;
      }
      progressBar_Excel_Read.Value = 0;
      backgroundWorker_Read_Excel.RunWorkerAsync();
    }

    private void backgroundWorker_Read_Excel_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      progressBar_Excel_Read.Value = e.ProgressPercentage;
    }

    private void backgroundWorker_Read_Excel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {

    }

    private void backgroundWorker_Save_Excel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      //MessageBox.Show("Duomenys išsaugoti į Excel failą.");
    }

    private void button_Lyginti_Įrašus_Click(object sender, EventArgs e)
    {
      ExcelDataFromFile.UpdateData(ExcelDataFromServer);
    }
  }
}
