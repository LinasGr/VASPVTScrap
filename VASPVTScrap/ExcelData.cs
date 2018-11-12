using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VASPVTScrap.Models;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Xml;

namespace VASPVTScrap
{
  class ExcelData
  {
    public List<ExcelLicencija> Data { get; set; }
    public string path { get; }
    private Excel.Application xlApp;

    public List<ExcelLicencija> NeedToBeUpdated { get; set; }

    public ExcelData()
    {
      xlApp =  new Excel.Application();
      xlApp.DisplayAlerts = false;
      Data = new List<ExcelLicencija>();
      path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VASPVTScrap\\";
      if (!Directory.Exists(path)) Directory.CreateDirectory(path);
      NeedToBeUpdated = new List<ExcelLicencija>();
    }

    ~ExcelData()
    {
      xlApp.Application.Quit();
      xlApp.Quit();
      xlApp = null;
    }

    public int Distinct()
    {
      var dublicates = Data.Count;
      Data = Data.GroupBy(x => x.Spaudo_Nr).Select(z => z.First()).ToList();
      dublicates -= Data.Count;
      return dublicates;
    }

    public void CreateExcelFile(BackgroundWorker bw, string FileName = "VASPVScrap.xls")
    {
      bw.ReportProgress(10);

      //Data preparing
      object[,] values = new object[Data.Count + 1, 11];

      values[0, 0] = "Spaudo Nr.";
      values[0, 1] = "Spaudo tipas";
      values[0, 2] = "Vardas";
      values[0, 3] = "Pavardė";
      values[0, 4] = "Licencijos Nr.";
      values[0, 5] = "Profesinė kvalifikacija";
      values[0, 6] = "Licencijos išdavimo data";
      values[0, 7] = "Licencijos būsena";
      values[0, 8] = "Įsakymo data ir Nr.";
      values[0, 9] = "Priežiūros data";
      values[0, 10] = "Priežiūros įsakymo Nr.";

      for (int i = 0; i < Data.Count; i++)
      {
        values[i+1, 0] = Data[i].Spaudo_Nr;
        values[i+1, 1] = Data[i].Spaudo_tipas;
        values[i+1, 2] = Data[i].Vardas;
        values[i+1, 3] = Data[i].Pavardė;
        values[i+1, 4] = Data[i].Licencijos_Nr;
        values[i+1, 5] = Data[i].Profesinė_kvalifikacija;
        values[i+1, 6] = Data[i].Licencijos_išdavimo_data;
        values[i+1, 7] = Data[i].Licencijos_būsena;
        values[i+1, 8] = Data[i].Įsakymo_data_ir_Nr;
        values[i+1, 9] = Data[i].Priežiūros_data;
        values[i+1, 10] = Data[i].Priežiūros_įsakymo_Nr;
      }
      bw.ReportProgress(20);

      //Opening file
      var xlWb = xlApp.Workbooks.Add();
      var xlSheet = xlApp.ActiveSheet as Excel.Worksheet;
      bw.ReportProgress(45);
      
      //Uploading data to file
      Excel.Range range = xlSheet.get_Range("A1", "K" +( Data.Count+1));
      range.Value2 = values;
      bw.ReportProgress(70);

      //Formating
      range = xlSheet.get_Range("G2", "G" + Data.Count);
      range.NumberFormat = "DD/MM/YYYY";
      range = xlSheet.get_Range("J2", "J" + Data.Count);
      range.NumberFormat = "DD/MM/YYYY";
      xlSheet.Range["A1", "K1"].WrapText = true;
      xlSheet.Range["A1", "K" + (Data.Count + 1)].AutoFormat(Format:
        Excel.XlRangeAutoFormat.xlRangeAutoFormatColor2);
      bw.ReportProgress(80);

      //Save file
      xlWb.SaveAs(path + FileName, Excel.XlFileFormat.xlAddIn8, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing,
        Type.Missing, Type.Missing);
      bw.ReportProgress(90);

      //Close file
      xlWb.Close();
      //xlApp.Application.Quit();
      bw.ReportProgress(98);

    }

    public void BackUpFile(string FileName = "VASPVScrap.xls")
    {
      if (File.Exists(path + FileName))
      {
        if (!Directory.Exists(path + "BackupData")) Directory.CreateDirectory(path + "BackupData");
        File.Copy(path + FileName, path+ "BackupData\\" + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss_") + FileName, true);
      }
    }

    public void ReadExcelFile(BackgroundWorker bw, string FileName = "VASPVScrap.xls")
    {
      if (!File.Exists(path + FileName)) return;
      if (Data.Count > 0) Data = new List<ExcelLicencija>();
      bw.ReportProgress(10);

      //Open file
      var xlWb = xlApp.Workbooks.Open(path + FileName);
      var xlSheet = xlApp.ActiveSheet as Excel.Worksheet;
      bw.ReportProgress(40);

      //Finding last row
      Excel.Range last = xlSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);

      //reading values
      Excel.Range range = xlSheet.get_Range("A2", "K"+last.Row+1);
      object[,] values = (object[,])range.Value2;
      int lastRow = last.Row;
      bw.ReportProgress(60);

      //Closing excel
      xlWb.Close();
      //xlApp.Application.Quit();
      bw.ReportProgress(80);

      //Filling data
      for (int i = 1; i < lastRow; i++)
      {
        var licencija = new ExcelLicencija();
        licencija.Spaudo_Nr = Convert.ToString(values[i, 1]);
        licencija.Spaudo_tipas = Convert.ToString(values[i, 2]);
        licencija.Vardas = Convert.ToString(values[i, 3]);
        licencija.Pavardė = Convert.ToString(values[i, 4]);
        licencija.Licencijos_Nr = Convert.ToString(values[i, 5]);
        licencija.Profesinė_kvalifikacija = Convert.ToString(values[i, 6]);
        licencija.Licencijos_išdavimo_data = DateTime.FromOADate(Convert.ToDouble(values[i, 7]));
        licencija.Licencijos_būsena = Convert.ToString(values[i, 8]);
        licencija.Įsakymo_data_ir_Nr = Convert.ToString(values[i, 9]);
        licencija.Priežiūros_data = DateTime.FromOADate(Convert.ToDouble(values[i, 10]));
        licencija.Priežiūros_įsakymo_Nr = Convert.ToString(values[i, 11]);
        if (licencija.Spaudo_Nr != "")
          Data.Add(licencija);
      }
      bw.ReportProgress(90);
    }

    public void UpdateData(ExcelData newData, BackgroundWorker bw)
    {
      NeedToBeUpdated = new List<ExcelLicencija>();
      bw.ReportProgress(10);
      //Update changed records
      for (int i = 0; i < Data.Count; i++)
      {
        var newLicencija = newData.Data.Find(x => x.Spaudo_Nr == Data[i].Spaudo_Nr);
        if (newLicencija != null)
        {
          if (!newLicencija.Equals(Data[i]))
            Data[i] = newLicencija;
        }
        else NeedToBeUpdated.Add(Data[i]);
      }
      bw.ReportProgress(40);

      //Add new records
      newData.Data.ForEach(x =>
      {
        if (!Data.Contains(x)) Data.Add(x);
      });

      bw.ReportProgress(60);
      //Update NeedToBeUpdated
      for (int i = 0; i < NeedToBeUpdated.Count; i++)
      {
        var scrap = new Scrap();
        var newLicencija = new ExcelLicencija(scrap.RequestRecord(NeedToBeUpdated[i].Spaudo_Nr.Trim()));
        if (newLicencija != null)
        {
          Data[Data.IndexOf(NeedToBeUpdated[i])] = newLicencija;
        }
        bw.ReportProgress(i * 40 / NeedToBeUpdated.Count + 60);
      }
      NeedToBeUpdated = new List<ExcelLicencija>();
      
      //Negaliojančių licencijų panaikinimas
      Data = Data.FindAll(x => x.Licencijos_būsena == "Aktyvi").ToList();

      bw.ReportProgress(100);
    }
  }
}
