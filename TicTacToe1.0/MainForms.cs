﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe1._0
{
  public partial class MainForms : Form
  {
    WriteLogs Log = null;
    Pieces[,] Board = null;
    public int role = 0, xScore = 0, oScore = 0;
    AI AI = new AI();
    Label Lblscore = null;
    public MainForms()
    {
      InitializeComponent();
    }

    private void Initial()
    {
      Board = new Pieces[3, 3];
      Lblscore = new Label();

      //Create the bord and ScoreLabel
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
      //create the Scorelabel
      Lblscore.Location = new Point(0, 320);
      Lblscore.Width = 300;
      Lblscore.Text = $"PlX: {xScore} - PlO: {oScore}";
      this.Controls.Add(Lblscore);
    }

    public void Play(object sender, EventArgs e)
    {
      //When a button on the board is clicked it changes the player and the shown picture 
      //on the screen.
      int i = ((Button)sender).Top / 100, j = ((Button)sender).Left / 100;
      if (Board[i, j].state == States.F)
      {
        if (role % 2 == 0)
        {
          Board[i, j].state = States.X;
          Board[i, j].Image = Properties.Resources.X;
        }
        int[] a = AI.GetMove(Board, role % 2 == 0 ? States.X : States.O);
        if (a[0] != -1 && a[1] != -1)
        {
          Board[a[0], a[1]].state = States.O;
          Board[a[0], a[1]].Image = Properties.Resources.O;
        }

        role += 2;
        checkWinner();
        //if there are 9 buttons pressed send tho logs Draw and reset the bord
        if (role == 10) { resteBord(); Log = new WriteLogs("Draw: Score: " + "PlX: " + xScore.ToString() + " - " + "PlO: " + oScore.ToString()); };
      }
      else
      {
        MessageBox.Show("Invalid place");
        Log = new WriteLogs("Error: Wrong Place");
      }
    }

    public void checkWinner()
    {
      // Rows
      //check if rows are full in a winning position
      for (int i = 0; i < 3; i++)
        if (Board[i, 1].state == Board[i, 0].state
          && Board[i, 1].state == Board[i, 2].state
          && Board[i, 1].state != States.F)
        {
          done(i, 1);
          return;
        }
      // Colunms
      //check if colunms are full in a winning position
      for (int j = 0; j < 3; j++)
        if (Board[1, j].state == Board[0, j].state
          && Board[1, j].state == Board[2, j].state
          && Board[1, j].state != States.F)
        {
          done(1, j);
          return;
        }

      // Diagonals
      //check if the diagonals are full in a winning position
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
      // send the winner and the score to the logs and rest the bord and show the score on the score label
      if (Board[i, j].state == States.X) { xScore++; Log = new WriteLogs("Winner:  Winner is " + Board[i, j].state.ToString() + " Score: " + "PlX: " + xScore.ToString() + " - " + "PlO: " + oScore.ToString()); }
      else { oScore++; Log = new WriteLogs("Winner:  Winner is " + Board[i, j].state.ToString() + " Score: " + "PlX: " + xScore.ToString() + " - " + "PlO: " + oScore.ToString()); }
      resteBord();
      Lblscore.Text = "PlX: " + xScore.ToString() + " - " + "PlO: " + oScore.ToString();
    }

    private void resteBord()
    {
      // clears the whole bord
      for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
        {
          Board[i, j].Image = null;
          Board[i, j].state = States.F;
        }
      role = 0;
    }

    private void OnNewGameClicked(object sender, EventArgs e)
    {
      Initial();
      HideMenu();
    }

    private void OnFormsLoad(object sender, EventArgs e)
    {
      //when the app is opend send a oppaning Log tag
      Log = new WriteLogs(1);
    }

    private void OnResumeGameClicked(object sender, EventArgs e)
    {
      String Filepath = $".\\..\\..\\..\\SavedScores\\Saved.txt";

      if (File.Exists(Filepath))
      {
        xScore = getscore('x');
        oScore = getscore('o');
        HideMenu();
        Initial();
      }
      else
      {
        MessageBox.Show("Kein Score verfügbar", "Missing");
      }
    }

    private void OnFormsClosing(object sender, FormClosingEventArgs e)
    {
      save();
      Log = new WriteLogs(0);
    }
    private void save()
    {
      // save the file in the ordner SavedScores with a chosen filename
      String Filepath = $".\\..\\..\\..\\SavedScores\\Saved.txt";
      if (File.Exists(Filepath))
      {
        if (File.Exists(Filepath))
        {
          File.Delete(Filepath);
          Thread.Sleep(700);
        }
        File.WriteAllText(Filepath, $"{xScore},{oScore}" + "\n" + $"Score: PlX: {xScore} - PlO: {oScore}");
      }


    }
    private int getscore(char c)
    {
      string Sco = string.Empty;
      string[] st = new string[2];
      string value = "";
      String Filepath = $".\\..\\..\\..\\SavedScores\\Saved.txt";
      using (StreamReader stream = new StreamReader(Filepath))
      {
        value = stream.ReadLine();
      }
      st = value.Split(',');
      if (c == 'x')
      {
        Sco = st[0];
      }
      else if (c == 'o')
      {
        Sco = st[1];
      }
      return Convert.ToInt32(Sco);
    }

    private void OnOptionClicked(object sender, EventArgs e)
    {
      HideMenu();
      ShowOptions();
    }

    private void HideMenu()
    {
      this.BtnExit.Hide();
      this.BtnNewGame.Hide();
      this.BtnOptions.Hide();
      this.BtnResume.Hide();
    }
    private void ShowMenu()
    {
      this.BtnExit.Show();
      this.BtnNewGame.Show();
      this.BtnOptions.Show();
      this.BtnResume.Show();
    }
    private void ShowOptions()
    {
      this.BtnAiOption.Show();
      this.BtnAiStrength.Show();
      this.BtnExitOptions.Show();
      this.BtnLogs.Show();
    }
    private void HideOptions()
    {
      this.BtnAiOption.Hide();
      this.BtnAiStrength.Hide();
      this.BtnExitOptions.Hide();
      this.BtnLogs.Hide();
    }
  }
}