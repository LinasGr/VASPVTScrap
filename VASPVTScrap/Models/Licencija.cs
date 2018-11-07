using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VASPVTScrap.Models
{
  class Licencija
  {
    public int Id { get; set; }
    public string StampNo { get; set; }
    public string StampType { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int LicenseId { get; set; }
    public string LicenseNo { get; set; }
    public string ProfessionalQualification { get; set; }
    public DateTime? IssueDate { get; set; }
    public string OrderNo { get; set; }
    public int OrderId { get; set; }
    public DateTime? OrderDate { get; set; }
    public int State { get; set; }
    public bool OrderCreated { get; set; }
    public DateTime? MaintenanceDate { get; set; }
    public string MaintenanceOrderNo { get; set; }

    public Licencija()
    {
      StampType = "";
      StampNo = "";
      FirstName = "";
      LastName = "";
      LicenseNo = "";
      ProfessionalQualification = "";
      IssueDate=DateTime.MinValue;
      OrderNo = "";
      OrderDate=DateTime.MinValue;
      MaintenanceDate=DateTime.MinValue;
      MaintenanceOrderNo = "";
    }

  }
}

