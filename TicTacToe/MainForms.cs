using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
  public partial class MainForms : Form
  {
    WriteLogs Log = null;
    public MainForms()
    {
      InitializeComponent();
    }

    private void OnFormsLoad(object sender, EventArgs e)
    {
      Log = new WriteLogs(1);
    }

    private void OnFormsClosing(object sender, FormClosingEventArgs e)
    {
      Log = new WriteLogs(0);
    }
  }
}
