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
    private int klaidos { get; set; }

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
      //backgroundWorker_Read_Excel.RunWorkerAsync();
      source.DataSource = ExcelDataFromServer.Data;
      dataGridView1.DataSource = source;
      dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
      dataGridView1.BorderStyle = BorderStyle.Fixed3D;
      dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
    }

    private void button_Scrap_Click(object sender, EventArgs e)
    {
      if (backgroundWorker_Scrap.IsBusy)
      {
        MessageBox.Show("Siuntimas jau vyksta.");
        return;
      }
      progressBar1.Value = 1;
      PagesOnServer = 0;
      PagesDownloaded = 0;
      backgroundWorker_Scrap.RunWorkerAsync();
    }

    private void backgroundWorker_Scrap_DoWork(object sender, DoWorkEventArgs e)
    {
      klaidos = 0;
      var stopWatch = new Stopwatch();
      stopWatch.Start();
    
      var recordsPerPage = 500;
      response = request.RequestRecords(1, recordsPerPage);
      var recordsOnServer = response.Total;
      var pagesTotal = recordsOnServer / recordsPerPage
                       + (recordsOnServer % recordsPerPage == 0 ? 0 : 1);
 
      response.Data.ForEach(x => {
        if (x.StampNo != null)
          ExcelDataFromServer.Data.Add(new ExcelLicencija(x));
        else
          klaidos++;
      });

      PagesDownloaded++;
      PagesOnServer = pagesTotal;
      //pagesTotal = 1;//Laikinas limitas
      backgroundWorker_Scrap.ReportProgress(100 / pagesTotal);

      for (int i = 2; i <= pagesTotal; i++)
      {
        Thread.Sleep(5000);
        response = request.RequestRecords(i, recordsPerPage);

        response.Data.ForEach(x =>
        {
          if (x.StampNo!=null)
            ExcelDataFromServer.Data.Add(new ExcelLicencija(x));
          else
            klaidos++;
        });

        PagesDownloaded++;
        backgroundWorker_Scrap.ReportProgress(i * 100 / pagesTotal);
      }

      ExcelDataFromServer.Data=ExcelDataFromServer.Data.Distinct().ToList();
      stopWatch.Stop();
      TookTimeSpan = stopWatch.Elapsed;
      MessageBox.Show($"Duomenys parsiūsti per - {TookTimeSpan.TotalMinutes.ToString("##.##")} min.");
    }

    private void backgroundWorker_Scrap_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      progressBar1.Value = e.ProgressPercentage;
      label_Klaidos.Text = klaidos.ToString();
      if (label_Count_Server.Text != response.Total.ToString())
        label_Count_Server.Text = response.Total.ToString();
      label_Count_Parsiusta.Text = ExcelDataFromServer.Data.Count.ToString();
      label_Puslapiu_Parsiusta.Text = PagesDownloaded.ToString();
      label_Puslapiu_Serveryje.Text = PagesOnServer.ToString();
      source.ResetBindings(false);
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
      if (ExcelDataFromFile.Data.Count == 0)
      {
        if (ExcelDataFromServer.Data.Count == 0)
        {
          MessageBox.Show("Nėra įrašų.");
          return;
        }
        ExcelDataFromFile.Data = ExcelDataFromServer.Data;
      }
      if (backgroundWorker_Save_Excel.IsBusy)
      {
        MessageBox.Show("Įrašymas jau vyksta.");
        return;
      }
      progressBar_Excel_Save.Value = 0;
      backgroundWorker_Save_Excel.RunWorkerAsync();
    }

    private void backgroundWorker_Read_Excel_DoWork(object sender, DoWorkEventArgs e)
    {
      backgroundWorker_Read_Excel.ReportProgress(0);
      ExcelDataFromFile.ReadExcelFile(sender as BackgroundWorker);
      backgroundWorker_Read_Excel.ReportProgress(100);
    }

    private void backgroundWorker_Save_Excel_DoWork(object sender, DoWorkEventArgs e)
    {
      backgroundWorker_Save_Excel.ReportProgress(5);
      if (ExcelDataFromFile.Data.Count == 0)
        ExcelDataFromFile.Data = ExcelDataFromServer.Data;
      backgroundWorker_Save_Excel.ReportProgress(10);
      ExcelDataFromFile.BackUpFile();
      backgroundWorker_Save_Excel.ReportProgress(40);
      ExcelDataFromFile.CreateExcelFile(sender as BackgroundWorker);
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
      if (backgroundWorker_Compare.IsBusy)
      {
        MessageBox.Show("Lyginimas jau vyksta.");
        return;
      }
      if (ExcelDataFromFile.Data.Count == 0 || ExcelDataFromServer.Data.Count == 0)
      {
        MessageBox.Show("Trūksta duomenų palyginimui.");
        return;
      }
      progressBar_Compare.Value = 0;
      backgroundWorker_Compare.RunWorkerAsync();
    }

    private void backgroundWorker_Compare_DoWork(object sender, DoWorkEventArgs e)
    {
      ExcelDataFromFile.UpdateData(ExcelDataFromServer, sender as BackgroundWorker);
    }

    private void backgroundWorker_Compare_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      progressBar_Compare.Value = e.ProgressPercentage;
    }

    private void button_Compare_Stop_Click(object sender, EventArgs e)
    {
      if (backgroundWorker_Compare.IsBusy)backgroundWorker_Compare.CancelAsync();
      progressBar_Compare.Value = 0;
    }

    private void backgroundWorker_Scrap_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      label_Count_Parsiusta.Text = ExcelDataFromServer.Data.Count.ToString();
    }
  }
}
