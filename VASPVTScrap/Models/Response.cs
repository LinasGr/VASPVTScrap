using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VASPVTScrap.Models
{
  class Response
  {
    public List<Licencija> Data { get; set; }
    public int Total { get; set; }
    public string AggregateResults { get; set; }
    public string Errors { get; set; }

    public Response()
    {
      Data=new List<Licencija>();
      Total = 0;
      AggregateResults = "";
      Errors = "";
    }
  }
}
