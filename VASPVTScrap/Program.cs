using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace VASPVTScrap
{
  internal static class Program
  {
    /// <summary>
    ///   The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main(string[] args)
    {
      if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
      {
        return;
      }
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new Form1(args.Contains("-a"), args.Contains("-s")));
    }
  }
}