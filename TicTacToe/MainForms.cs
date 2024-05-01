using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
  public partial class MainForms : Form
  {
    WriteLogs Log = null;
    Pieces[,] Board = new Pieces[3, 3];
    int role = 0, xScore = 0, oScore = 0;
    Label Lblscore = new Label();
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
      LabelScore();
    }

    private void LabelScore()
    {
      Lblscore.Location = new Point(0, 320);
      Lblscore.Width = 300;
      Lblscore.Text = "PlX: 0 - PlO: 0";
      this.Controls.Add(Lblscore);
    }

    private void Play(object sender, EventArgs e)
    {
      int i = ((Button)sender).Top / 100, j = ((Button)sender).Left / 100;
      if (Board[i, j].state == States.F)
      {
        if (role % 2 == 0)
        {
          Board[i, j].state = States.X;
          Board[i, j].Image = Properties.Resources.X;
        }
        else
        {
          Board[i, j].state = States.O;
          Board[i, j].Image = Properties.Resources.O;
        }
        role += 1;
        checkWinner();
        if (role == 9) resteBord();
      }
      else
      {
        MessageBox.Show("Invalid place");
        Log = new WriteLogs("Error: Wrong Place");
      }
    }

    private void checkWinner()
    {
      // Rows
      for (int i = 0; i < 3; i++)
        if (Board[i, 1].state == Board[i, 0].state
          && Board[i, 1].state == Board[i, 2].state
          && Board[i, 1].state != States.F)
        {
          done(i, 1);
          return;
        }
      // Colunms
      for (int j = 0; j < 3; j++) 
        if (Board[1, j].state == Board[0, j].state
          && Board[1, j].state == Board[2, j].state
          && Board[1, j].state != States.F)
        {
          done(1, j);
          return;
        }

      // Diagonals
      if (Board[0, 0].state == Board[1, 1].state
        && Board[1, 1].state == Board[2, 2].state
        && Board[1, 1].state != States.F)
        done(1, 1);
      else if (Board[0, 2].state == Board[1, 1].state
      && Board[1, 1].state == Board[2, 0].state
      && Board[1, 1].state != States.F)
      done(1, 1);
    }

    private void done(int i, int j)
    {
      if (Board[i, j].state == States.X) { xScore++; Log = new WriteLogs("Winner:  Winner is "+ Board[i, j].state.ToString() + "PlX: " + xScore.ToString() + " - " + "PlO: " + oScore.ToString()); }
      else { oScore++; Log = new WriteLogs("Winner:  Winner is " + Board[i, j].state.ToString() + "PlX: " + xScore.ToString() + " - " + "PlO: " + oScore.ToString()); }
      resteBord();
      Lblscore.Text = "PlX: " + xScore.ToString() + " - " + "PlO: " + oScore.ToString();
    }

    private void resteBord()
    {
      for (int i = 0; i < 3; i++) 
        for (int j = 0; j < 3; j++)
        {
          Board[i, j].Image = null;
          Board[i, j].state = States.F;
        }
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
