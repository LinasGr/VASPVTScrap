using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using VASPVTScrap.Models;

namespace VASPVTScrap
{
  class Scrap
  {
    public Response requestL(int PageNr, int RecordsPerPage)
    {
      var client = new RestClient("https://licencijavimas.vaspvt.gov.lt/License/GetPublicSpecialistLicenseList");
      var request = new RestRequest(Method.POST);
      request.AddHeader("postman-token", "502fc85e-16e4-cfce-6d6e-d619fbc5dd75");
      request.AddHeader("cache-control", "no-cache");
      request.AddHeader("cookie", "__RequestVerificationToken=j8FUZueVcN42Lvzc17pjxoSla1jo44fl62iJ3Fe3IVEHF2UJ-NvjNsyj1sFSA8N2U15c2zPOD-xuR9c9cWadwCoANSfsqIogQiEU7KlVzfU1");
      request.AddHeader("accept-language", "lt,en-US;q=0.9,en;q=0.8,ru;q=0.7,pl;q=0.6");
      request.AddHeader("accept-encoding", "gzip, deflate, br");
      request.AddHeader("referer", "https://licencijavimas.vaspvt.gov.lt/License/PublicSpecialistIndex");
      request.AddHeader("content-type", "application/x-www-form-urlencoded; charset=UTF-8");
      request.AddHeader("dnt", "1");
      request.AddHeader("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.77 Safari/537.36");
      request.AddHeader("x-requested-with", "XMLHttpRequest");
      request.AddHeader("origin", "https://licencijavimas.vaspvt.gov.lt");
      request.AddHeader("accept", "*/*");
      request.AddParameter("application/x-www-form-urlencoded; charset=UTF-8", $"sort=&page={PageNr}&pageSize={RecordsPerPage}&group=&filter=State~eq~1~and~ProfessionalQualification~eq~'%C5%A0eimos+gydytojas'", ParameterType.RequestBody);
      request.Timeout = 300000;
      //request.RequestFormat = DataFormat.Json;
      IRestResponse response = client.Execute(request);
      var deserializedResponce = JsonConvert.DeserializeObject<Response>(response.Content);
      return deserializedResponce;
    }
    public void requestP()
    {
      var client = new RestClient("https://licencijavimas.vaspvt.gov.lt/SelectWindows/ReadQualifications");
      var request = new RestRequest(Method.POST);
      request.AddHeader("Postman-Token", "6b8eaa75-7cf4-4fc5-8529-4be2cc58dc7a");
      request.AddHeader("cache-control", "no-cache");
      request.AddHeader("DNT", "1");
      request.AddHeader("Connection", "keep-alive");
      request.AddHeader("X-Requested-With", "XMLHttpRequest");
      request.AddHeader("Referer", "https://licencijavimas.vaspvt.gov.lt/License/PublicSpecialistIndex");
      request.AddHeader("Accept", "*/*");
      request.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
      request.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.77 Safari/537.36");
      request.AddHeader("Accept-Language", "lt,en-US;q=0.9,en;q=0.8,ru;q=0.7,pl;q=0.6");
      request.AddHeader("Accept-Encoding", "gzip, deflate, br");
      request.AddHeader("Origin", "https://licencijavimas.vaspvt.gov.lt");
      request.AddHeader("Cookie", "__RequestVerificationToken=Q_jwGOoitnXJmqEGH26ZYFE5YjLK53O07R1BGAoirMyNopbdEv5vWtibiqVgYsZvhw22uXdm_UB6zCwwTgOLi7PKLx4jX-kQQOq9royTDaE1");
      request.AddParameter("undefined", "serviceName=", ParameterType.RequestBody);
      IRestResponse response = client.Execute(request);
    }
  }
}
