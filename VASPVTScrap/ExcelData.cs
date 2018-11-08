using System;
using System.Collections.Generic;
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
    private string path;

    public List<ExcelLicencija> NeedToBeUpdated { get; set; }

    public ExcelData()
    {
      Data = new List<ExcelLicencija>();
      path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\";
      NeedToBeUpdated = new List<ExcelLicencija>();
    }

    public void CreateExcelFile(string FileName = "VASPVScrap.xls")
    {
      var xlApp = new Excel.Application();
      var xlWb = xlApp.Workbooks.Add();
      var xlSheet = xlApp.ActiveSheet as Excel.Worksheet;

      //xlApp.Visible = true;
      //Header
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


      //Data
      for (int i = 0; i < Data.Count; i++)
      {
        xlSheet.Cells[i + 2, 1] = Data[i].Spaudo_Nr;
        xlSheet.Cells[i + 2, 2] = Data[i].Spaudo_tipas;
        xlSheet.Cells[i + 2, 3] = Data[i].Vardas;
        xlSheet.Cells[i + 2, 4] = Data[i].Pavardė;
        xlSheet.Cells[i + 2, 5] = Data[i].Licencijos_Nr;
        xlSheet.Cells[i + 2, 6] = Data[i].Profesinė_kvalifikacija;
        xlSheet.Cells[i + 2, 7] = Data[i].Licencijos_išdavimo_data;
        xlSheet.Cells[i + 2, 8] = Data[i].Licencijos_būsena;
        xlSheet.Cells[i + 2, 9] = Data[i].Įsakymo_data_ir_Nr;
        xlSheet.Cells[i + 2, 10] = Data[i].Priežiūros_data;
        xlSheet.Cells[i + 2, 11] = Data[i].Priežiūros_įsakymo_Nr;
      }

      //Formating
      xlSheet.Range["A1", "K1"].WrapText = true;
      xlSheet.Range["A1", "K" + (Data.Count + 1)].AutoFormat(Format:
        Excel.XlRangeAutoFormat.xlRangeAutoFormatColor2);

      //Save file
      xlApp.DisplayAlerts = false;
      xlWb.SaveAs(path + FileName, Excel.XlFileFormat.xlAddIn8, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing,
        Type.Missing, Type.Missing);
      xlWb.Close();
      xlApp.Application.Quit();
    }

    public void BackUpFile(string FileName = "VASPVScrap.xls")
    {
      if (File.Exists(path + FileName))
      {
        File.Copy(path + FileName, path + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss_") + FileName, true);
      }
    }

    public void ReadExcelFile(string FileName = "VASPVScrap.xls")
    {
      if (!File.Exists(path + FileName)) return;
      if (Data.Count > 0) Data = new List<ExcelLicencija>();

      var xlApp = new Excel.Application();
      //xlApp.Visible = true;
      var xlWb = xlApp.Workbooks.Open(path + FileName);
      var xlSheet = xlApp.ActiveSheet as Excel.Worksheet;

      //Data
      var licencija = new ExcelLicencija();
      int i = 2;
      while ((xlSheet.Cells[i, 1] as Excel.Range).Value2 != null)
      {
        licencija.Spaudo_Nr = (xlSheet.Cells[i, 1] as Excel.Range).Value2.ToString();
        if ((xlSheet.Cells[i, 2] as Excel.Range).Value2 != null)
          licencija.Spaudo_tipas = (xlSheet.Cells[i, 2] as Excel.Range).Value2.ToString();
        if ((xlSheet.Cells[i, 3] as Excel.Range).Value2 != null)
          licencija.Vardas = (xlSheet.Cells[i, 3] as Excel.Range).Value2.ToString();
        if ((xlSheet.Cells[i, 4] as Excel.Range).Value2 != null)
          licencija.Pavardė = (xlSheet.Cells[i, 4] as Excel.Range).Value2.ToString();
        if ((xlSheet.Cells[i, 5] as Excel.Range).Value2 != null)
          licencija.Licencijos_Nr = (xlSheet.Cells[i, 5] as Excel.Range).Value2.ToString();
        if ((xlSheet.Cells[i, 6] as Excel.Range).Value2 != null)
          licencija.Profesinė_kvalifikacija = (xlSheet.Cells[i, 6] as Excel.Range).Value2.ToString();
        if ((xlSheet.Cells[i, 7] as Excel.Range).Value2 != null)
          licencija.Licencijos_išdavimo_data = (DateTime)(xlSheet.Cells[i, 7] as Excel.Range).Value;
        if ((xlSheet.Cells[i, 8] as Excel.Range).Value2 != null)
          licencija.Licencijos_būsena = (xlSheet.Cells[i, 8] as Excel.Range).Value2.ToString();
        if ((xlSheet.Cells[i, 9] as Excel.Range).Value2 != null)
          licencija.Įsakymo_data_ir_Nr = (xlSheet.Cells[i, 9] as Excel.Range).Value2.ToString();
        if ((xlSheet.Cells[i, 10] as Excel.Range).Value2 != null)
          licencija.Priežiūros_data = (DateTime)(xlSheet.Cells[i, 10] as Excel.Range).Value;
        if ((xlSheet.Cells[i, 11] as Excel.Range).Value2 != null)
          licencija.Priežiūros_įsakymo_Nr = (xlSheet.Cells[i, 11] as Excel.Range).Value2.ToString();
        Data.Add(licencija);
        i++;
      };
      xlWb.Close();
      xlApp.Application.Quit();
    }

    public void UpdateData(ExcelData newData)
    {
      NeedToBeUpdated = new List<ExcelLicencija>();
      for (int i = 0; i < Data.Count; i++)
      {
        var newLicencija = newData.Data.Find(x => x.Spaudo_Nr==Data[i].Spaudo_Nr);
        if (newLicencija != null)
        {
          if (!newLicencija.Equals(Data[i]))
            Data[i] = newLicencija;
        }
        else NeedToBeUpdated.Add(Data[i]);
      }
      if (newData.Data.Count>Data.Count) 
        newData.Data.ForEach(x =>
        {
          if (!Data.Contains(x)) Data.Add(x);
        });
      if (Data.Count> newData.Data.Count)
        newData.Data.ForEach(x=>
        {
          var newLicencija=newData.Data.Find(z=>Data.Contains(z));
          if (newLicencija!=null)Data.Add(newLicencija);
        });
    }
  }
}
