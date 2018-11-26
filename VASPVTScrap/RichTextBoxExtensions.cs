﻿using System.Drawing;
using System.Windows.Forms;

namespace VASPVTScrap
{
  public static class RichTextBoxExtensions
  {
    public static void AppendText(this RichTextBox box, string text, Color color)
    {
      box.SelectionStart = box.TextLength;
      box.SelectionLength = 0;
      var defaultColor = box.SelectionColor;
      box.SelectionColor = color;
      box.AppendText(text);
      box.SelectionColor = defaultColor;
    }
  }
}