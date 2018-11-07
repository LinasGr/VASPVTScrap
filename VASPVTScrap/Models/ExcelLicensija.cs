using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VASPVTScrap.Models
{
  class ExcelLicensija
  {
    public string Spaudo_Nr { get; set; }
    public string Spaudo_tipas { get; set; }
    public string Vardas { get; set; }
    public string Pavardė { get; set; }
    public string Licencijos_Nr { get; set; }
    public string Profesinė_kvalifikacija { get; set; }
    public DateTime? Licencijos_išdavimo_data  { get; set; }
    public string Licencijos_būsena { get; set; }
    public string Įsakymo_data_ir_Nr { get; set; }
    public DateTime? Priežiūros_data { get; set; }
    public string Priežiūros_įsakymo_Nr { get; set; }

    public ExcelLicensija(Licencija data)
    {
      Spaudo_Nr = data.StampNo;
      Spaudo_tipas = data.StampType;
      Vardas = data.FirstName;
      Pavardė = data.LastName;
      Licencijos_Nr = data.LicenseNo;
      Profesinė_kvalifikacija = data.ProfessionalQualification;
      Licencijos_išdavimo_data = data.IssueDate;
      Licencijos_būsena = data.State==1?"Aktyvi":data.State==2?"Panaikinta":data.State==3?"Sustabdyta":"";
      Įsakymo_data_ir_Nr = data.IssueDate.HasValue?
        data.IssueDate.Value.ToString("dd/MM/yyyy")+", "+data.OrderNo 
        :data.OrderNo;
      Priežiūros_data = data.MaintenanceDate;
      Priežiūros_įsakymo_Nr = data.OrderNo;
    }
  }
}
