using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TicTacToe1._0
{
  public partial class Logs : Form
  {
    WriteLogs Wl = new WriteLogs();
    string[] otuput = null;
    public Logs()
    {
      InitializeComponent();
      this.CenterToScreen();
    }
    protected override void OnShown(EventArgs e)
    {
      base.OnShown(e);
      int lenght = 0;
      // Setze den Fokus auf das Ende des Textes, nachdem das Formular angezeigt wurde
      for(int i = 0; i < Outputlogs.Lines.Length; i++)
      {
        lenght = Outputlogs.Lines[i].Length;
      }
      Outputlogs.SelectionStart = lenght;
      Outputlogs.ScrollToCaret();
      Outputlogs.SelectionLength = 0;
    }

    private void Logs_Load(object sender, EventArgs e)
    {
      string value = Wl.getLogs().ToString();
      otuput = value.Split('?');
      Outputlogs.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular);
      Outputlogs.Lines = otuput;
    }

  }
}
