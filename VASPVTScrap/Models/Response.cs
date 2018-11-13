using System.Collections.Generic;

namespace VASPVTScrap.Models
{
  internal class Response
  {
    public Response()
    {
      Data = new List<Licencija>();
      Total = 0;
      AggregateResults = "";
      Errors = "";
    }

    public List<Licencija> Data { get; set; }
    public int Total { get; set; }
    public string AggregateResults { get; set; }
    public string Errors { get; set; }
  }
}