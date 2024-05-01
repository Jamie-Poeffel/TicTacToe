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
    Pieces[,] Board = new Pieces[3, 3];
    int role = 0, xScore = 0, oScore = 0;
    public MainForms()
    {
      InitializeComponent();
      Initial();
    }

    private void Initial()
    {
      for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
        {
          Board[i, j] = new Pieces(j * 100, i * 100);
          Board[i, j].Click += Play;
          Board[i, j].Cursor = Cursors.Hand;
          this.Controls.Add(Board[i, j]);
        }
    }

    private void Play(object sender, EventArgs e)
    {
      int i  = ((Button)sender).Top / 100, j = ((Button)sender).Left / 100;
      if (Board[i, j].state == States.F)
      {
        if (role % 2 == 0)
        {
          Board[i, j].state = States.X;
          Board[i, j].Image = Properties.Resources.X;
        }else 
        {
          Board[i, j].state = States.O;
          Board[i, j].Image = Properties.Resources.O;
        }
        role += 1;
      }else MessageBox.Show("Invalid place");
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
