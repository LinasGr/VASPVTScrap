using System;

namespace VASPVTScrap
{
  internal class LogData
  {
    public TimeSpan timeSpan { get; set; }
    public int errors { get; set; }
    public int dublicates { get; set; }
    public int processed { get; set; }
    public int remotePages { get; set; }
    public int localPages { get; set; }
  }
}