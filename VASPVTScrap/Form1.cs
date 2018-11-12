using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
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
    private Response response { get; set; }
    private Scrap request { get; set; }
    private ExcelData ExcelDataFromServer { get; set; }
    private ExcelData ExcelDataFromFile { get; set; }
    private LogData ScrapLog { get; set; }
    private LogData FileReadLog { get; set; }
    private LogData FileSaveLog { get; set; }
    private LogData CompareLog { get; set; }
    private bool Auto { get; set; }

    public Form1(bool auto)
    {
      InitializeComponent();
      ScrapLog = new LogData();
      FileReadLog = new LogData();
      FileSaveLog = new LogData();
      CompareLog = new LogData();
      request = new Scrap();
      response = new Response();
      //PagesOnServer = 0;
      //PagesDownloaded = 0;
      ExcelDataFromServer = new ExcelData();
      ExcelDataFromFile = new ExcelData();
      ReadLog();
      richTextBox_Log.SelectionStart = richTextBox_Log.Text.Length;
      richTextBox_Log.ScrollToCaret();
      richTextBox_Log.AppendText($"[{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}] - " +
                                 "Programos paleidimas - [");
      richTextBox_Log.AppendText("Atlikta", Color.Green);
      richTextBox_Log.AppendText("]\n");
      if (auto)
      {
        checkBox_Auto.Checked = true;
        Auto = auto;
      }
    }

    private void SaveLog()
    {
      richTextBox_Log.SaveFile(ExcelDataFromFile.path + "LogFile.rtf");
    }

    private void ReadLog()
    {
      if (File.Exists(ExcelDataFromFile.path + "LogFile.rtf"))
        richTextBox_Log.LoadFile(ExcelDataFromFile.path + "LogFile.rtf");
    }

    private void button_Scrap_Click(object sender, EventArgs e)
    {
      if (backgroundWorker_Scrap.IsBusy)
      {
        MessageBox.Show("Siuntimas jau vyksta.");
        return;
      }
      progressBar_Scrap.Value = 1;
      backgroundWorker_Scrap.RunWorkerAsync();
    }

    private void backgroundWorker_Scrap_DoWork(object sender, DoWorkEventArgs e)
    {
      var stopWatch = new Stopwatch();
      stopWatch.Start();
      backgroundWorker_Scrap.ReportProgress(5);
      ScrapLog.errors = 0;
      ScrapLog.dublicates = 0;
      var recordsPerPage = 500;
      response = request.RequestRecords(1, recordsPerPage);
      var recordsOnServer = response.Total;
      var pagesTotal = recordsOnServer / recordsPerPage
                       + (recordsOnServer % recordsPerPage == 0 ? 0 : 1);

      response.Data.ForEach(x =>
      {
        if (x.StampNo != null)
          ExcelDataFromServer.Data.Add(new ExcelLicencija(x));
        else
          ScrapLog.errors++;
      });

      ScrapLog.remotePages = pagesTotal;
      ScrapLog.localPages++;
      backgroundWorker_Scrap.ReportProgress(100 / pagesTotal);

      for (int i = 2; i <= pagesTotal; i++)
      {
        Thread.Sleep(5000);
        response = request.RequestRecords(i, recordsPerPage);

        response.Data.ForEach(x =>
        {
          if (x.StampNo != null && x.StampNo != "")
            ExcelDataFromServer.Data.Add(new ExcelLicencija(x));
          else
            ScrapLog.errors++;
        });

        ScrapLog.localPages++;
        backgroundWorker_Scrap.ReportProgress(i * 100 / pagesTotal);
      }

      ScrapLog.dublicates = ExcelDataFromServer.Distinct();
      stopWatch.Stop();
      ScrapLog.timeSpan = stopWatch.Elapsed;
    }

    private void backgroundWorker_Scrap_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      progressBar_Scrap.Value = e.ProgressPercentage;
      label_Klaidos.Text = ScrapLog.errors.ToString();
      if (label_Count_Server.Text != response.Total.ToString())
        label_Count_Server.Text = response.Total.ToString();
      label_Count_Parsiusta.Text = ExcelDataFromServer.Data.Count.ToString();
      label_Puslapiu_Parsiusta.Text = ScrapLog.localPages.ToString();
      label_Puslapiu_Serveryje.Text = ScrapLog.remotePages.ToString();
    }

    private void button_Scrap_Stop_Click(object sender, EventArgs e)
    {
      if (backgroundWorker_Scrap.IsBusy)
      {
        backgroundWorker_Scrap.CancelAsync();
        progressBar_Scrap.Value = 0;
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
      var stopWatch = new Stopwatch();
      stopWatch.Start();
      backgroundWorker_Read_Excel.ReportProgress(1);
      FileReadLog.dublicates = 0;
      FileReadLog.processed = 0;
      ExcelDataFromFile.ReadExcelFile(sender as BackgroundWorker);
      FileReadLog.dublicates = ExcelDataFromFile.Distinct();
      backgroundWorker_Read_Excel.ReportProgress(100);
      stopWatch.Stop();
      FileReadLog.timeSpan = stopWatch.Elapsed;
    }

    private void backgroundWorker_Save_Excel_DoWork(object sender, DoWorkEventArgs e)
    {
      var stopWatch = new Stopwatch();
      stopWatch.Start();
      FileSaveLog.errors = 0;
      FileSaveLog.processed = 0;
      backgroundWorker_Save_Excel.ReportProgress(5);
      if (ExcelDataFromFile.Data.Count == 0)
        ExcelDataFromFile.Data = ExcelDataFromServer.Data;
      backgroundWorker_Save_Excel.ReportProgress(10);
      ExcelDataFromFile.BackUpFile();
      backgroundWorker_Save_Excel.ReportProgress(40);
      ExcelDataFromFile.CreateExcelFile(sender as BackgroundWorker);
      backgroundWorker_Save_Excel.ReportProgress(100);
      stopWatch.Stop();
      FileSaveLog.timeSpan = stopWatch.Elapsed;
      playSimpleSound();
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
      richTextBox_Log.AppendText($"[{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}] - " +
                                 $"Nuskaityta įrašų({ExcelDataFromFile.Data.Count}). " +
                                 "Ištrinta dublikatų(");
      richTextBox_Log.AppendText(FileReadLog.dublicates.ToString(), ScrapLog.dublicates > 0 ? Color.Red : Color.Green);
      richTextBox_Log.AppendText($"). Užtruko sekundžių({FileReadLog.timeSpan.TotalSeconds}) - [");
      richTextBox_Log.AppendText("Atlikta", FileReadLog.dublicates == 0 ? Color.Green : Color.Red);
      richTextBox_Log.AppendText("]\n");
      playSimpleSound();
      SaveLog();
      if (checkBox_Auto.Checked)
      {
        //tesiamas automatinis uzduoties vykdymas
        if (progressBar_Scrap.Value == 100)
          backgroundWorker_Compare.RunWorkerAsync();
        else
        {
          if (!backgroundWorker_Scrap.IsBusy)
            backgroundWorker_Scrap.RunWorkerAsync();
        }
      }
    }

    private void backgroundWorker_Save_Excel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      richTextBox_Log.AppendText($"[{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}] - " +
                                 $"Išsaugota įrašų({ExcelDataFromFile.Data.Count}). " +
                                 $"Užtruko sekundžių({FileSaveLog.timeSpan.TotalSeconds}) - [");
      richTextBox_Log.AppendText("Atlikta", Color.Green);
      richTextBox_Log.AppendText("]\n");
      SaveLog();
      if (checkBox_Auto.Checked)
      {
        Close();
      }
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
      var stopWatch = new Stopwatch();
      stopWatch.Start();
      backgroundWorker_Compare.ReportProgress(0);
      ExcelDataFromFile.UpdateData(ExcelDataFromServer, sender as BackgroundWorker);
      stopWatch.Stop();
      CompareLog.timeSpan = stopWatch.Elapsed;
      playSimpleSound();
    }

    private void backgroundWorker_Compare_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      progressBar_Compare.Value = e.ProgressPercentage;
    }

    private void button_Compare_Stop_Click(object sender, EventArgs e)
    {
      if (backgroundWorker_Compare.IsBusy) backgroundWorker_Compare.CancelAsync();
      progressBar_Compare.Value = 0;
    }

    private void backgroundWorker_Scrap_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      label_Count_Parsiusta.Text = ExcelDataFromServer.Data.Count.ToString();
      label_Dublikatai.Text = ScrapLog.dublicates.ToString();
      richTextBox_Log.AppendText($"[{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}] - " +
                                 $"Serveryje įrašų({label_Count_Server.Text}). " +
                                 $"Įrašų parsiųsta({label_Count_Parsiusta.Text}). " +
                                 $"Puslapių serveryje({label_Puslapiu_Serveryje.Text}). " +
                                 $"Puslapių parsiūsta({label_Puslapiu_Parsiusta.Text}). Klaidos(");
      richTextBox_Log.AppendText(ScrapLog.errors.ToString(), ScrapLog.errors == 0 ? ForeColor : Color.Red);
      richTextBox_Log.AppendText("), Dublikatų ištrinta(");
      richTextBox_Log.AppendText(ScrapLog.dublicates.ToString(), ScrapLog.dublicates > 0 ? Color.Red : Color.Green);
      richTextBox_Log.AppendText($"), Užtruko minučiu({ScrapLog.timeSpan.Minutes}) - [");
      if (ScrapLog.errors == 0 && ScrapLog.dublicates == 0) richTextBox_Log.AppendText("Atlikta", Color.Green);
      else richTextBox_Log.AppendText("Atlikta", Color.Red);
      richTextBox_Log.AppendText("]\n");
      SaveLog();
      playSimpleSound();
      if (checkBox_Auto.Checked)
      {
        //tesiamas automatinis uzduoties vykdymas
        if (progressBar_Excel_Read.Value == 100)
        {
          backgroundWorker_Compare.RunWorkerAsync();
        }
        else
        {
          if (!backgroundWorker_Read_Excel.IsBusy)
            backgroundWorker_Read_Excel.RunWorkerAsync();
        }
      }
    }

    private void backgroundWorker_Compare_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      richTextBox_Log.AppendText($"[{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}] - " +
                                 $"Palyginta įrašų({ExcelDataFromFile.Data.Count}). " +
                                 $"Užtruko sekundžių({CompareLog.timeSpan.TotalSeconds}) - [");
      richTextBox_Log.AppendText("Atlikta", Color.Green);
      richTextBox_Log.AppendText("]\n");
      SaveLog();
      if (checkBox_Auto.Checked)
      {
        //tesiamas automatinis uzduoties vykdymas
        while (backgroundWorker_Save_Excel.IsBusy)
        {
          Thread.Sleep(500);
        }
        backgroundWorker_Save_Excel.RunWorkerAsync();
      }
    }
    private void playSimpleSound()
    {
      SoundPlayer simpleSound = new SoundPlayer("Beep Ping-SoundBible.com-217088958.wav");
      simpleSound.Play();
    }

    private void bindingSource1_CurrentChanged(object sender, EventArgs e)
    {

    }

    private void button_Open_Dir_Click(object sender, EventArgs e)
    {
      Process.Start(ExcelDataFromFile.path);
    }

    private void checkBox_Auto_CheckedChanged(object sender, EventArgs e)
    {
      if (checkBox_Auto.Checked)
      {
        if (!backgroundWorker_Scrap.IsBusy)
          backgroundWorker_Scrap.RunWorkerAsync();
        if (!backgroundWorker_Read_Excel.IsBusy)
          backgroundWorker_Read_Excel.RunWorkerAsync();
      }
    }

    private void richTextBox_Log_TextChanged(object sender, EventArgs e)
    {
      richTextBox_Log.SelectionStart = richTextBox_Log.Text.Length;
      richTextBox_Log.ScrollToCaret();
    }

    private void Form1_Resize(object sender, EventArgs e)
    {
      if (WindowState == FormWindowState.Minimized)
      {
        Hide();
      }
    }

    private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      Auto = false;
      Show();
      WindowState = FormWindowState.Normal;
    }

    private void Form1_Shown(object sender, EventArgs e)
    {
      if (Auto) WindowState = FormWindowState.Minimized;
    }
  }
}