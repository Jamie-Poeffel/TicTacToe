using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
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
    String Path = @".\..\..\..\SavedScores\SaveScore.txt";
    public int role = 0, xScore = 0, oScore = 0;
    AI AI = new AI();
    Label Lblscore = null;
    bool pause = false;
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
      this.BtnPause.Visible = true;
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
          checkWinner();
          //if there are 9 buttons pressed send tho logs Draw and reset the bord
        }
        if (this.BtnAiOption.Text == "AI" && this.BtnAiStrength.Text == "Strong")
        {
          int[] a = AI.GetMove(Board, role % 2 == 0 ? States.X : States.O);
          if (a[0] != -1 && a[1] != -1)
          {
            Board[a[0], a[1]].state = States.O;
            Board[a[0], a[1]].Image = Properties.Resources.O;
          }
          checkWinner();
          //if there are 9 buttons pressed send tho logs Draw and reset the bord
          role += 1;
        }
        if (this.BtnAiOption.Text == "AI" && this.BtnAiStrength.Text == "Medium")
        {
          int[] a = AI.MiniMax(Board, role % 2 == 0 ? States.X : States.O);
          if (a[0] != -1 && a[1] != -1)
          {
            Board[a[0], a[1]].state = States.O;
            Board[a[0], a[1]].Image = Properties.Resources.O;
          }
          checkWinner();
          role += 1;
        }
        if (this.BtnAiOption.Text == "AI" && this.BtnAiStrength.Text == "Weak")
        {
          Random rand = new Random();
          int[] a = new int[2];
          do
          {
            a[0] = rand.Next(0, 3);
            a[1] = rand.Next(0, 3);
          } while (Board[a[0], a[1]].state != States.F);
          if (a[0] != -1 && a[1] != -1)
          {
            Board[a[0], a[1]].state = States.O;
            Board[a[0], a[1]].Image = Properties.Resources.O;
          }
          role += 1;
          checkWinner();
        }
        if (this.BtnAiOption.Text == "Human" && role % 2 != 0)
        {
          Board[i, j].state = States.O;
          Board[i, j].Image = Properties.Resources.O;
          checkWinner();
          //if there are 9 buttons pressed send tho logs Draw and reset the bord
        }
        if (role > 8) { resteBord(); Log = new WriteLogs("Draw: Score: " + "PlX: " + xScore.ToString() + " - " + "PlO: " + oScore.ToString()); };
        role += 1;
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
      if (File.Exists(Path))
      {
        xScore = getscore('x');
        oScore = getscore('o');
        this.BtnAiOption.Text = getData('o');
        this.BtnAiStrength.Text = getData('s');
        HideMenu();
        Initial();
      }
      else
      {
        MessageBox.Show("Kein Score verfügbar", "Missing");
      }
    }

    private string getData(char d)
    {
      string[] st = new string[2];
      string value = string.Empty;
      using (StreamReader reader = new StreamReader(Path))
      {
        value = reader.ReadToEnd();
      };
      value = BitsToString(value);
      st = value.Split('§');
      st = st[1].Split(',');
      if (d == 'o')
      {
        value = st[0];
      }
      else if (d == 's')
      {
        value = st[1];
      }
      return value;
    }
    private void OnFormsClosing(object sender, FormClosingEventArgs e)
    {
      save();
      Log = new WriteLogs(0);
    }
    private void save()
    {
      if (File.Exists(Path)) File.Delete(Path);
      File.WriteAllText(Path, StringToBits($"{xScore.ToString()},{oScore.ToString()}" + "§\n"
                            + $"{BtnAiOption.Text},{BtnAiStrength.Text}"));
      Thread.Sleep(1000);
    }
    private int getscore(char c)
    {
      string Sco = string.Empty;
      string[] st = new string[2];
      string value_ = string.Empty;
      using (StreamReader reader = new StreamReader(Path))
      {
          value_ = reader.ReadToEnd();
      };
      value_ = BitsToString(value_);
      st = value_.Split('§');
      st = st[0].Split(',');
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

    private void OnExitOptionCLicke(object sender, EventArgs e)
    {
      HideOptions();
      if (pause)
      {
        ShowPause();
        this.BtnPause.Visible = true;
      }
      else
        ShowMenu();
    }

    private void OnExitCliked(object sender, EventArgs e)
    {
      this.Close();
    }

    private void OnLogsClicked(object sender, EventArgs e)
    {
      Logs log = new Logs();
      log.Show();
    }

    private void OnHumanAiClicked(object sender, EventArgs e)
    {
      if (this.BtnAiOption.Text == "Human")
      {
        this.BtnAiOption.Text = "AI";
      }
      else
      {
        this.BtnAiOption.Text = "Human";
      }
    }

    private void OnBtnAIstrength(object sender, EventArgs e)
    {
      if (this.BtnAiStrength.Text == "Strong")
      {
        this.BtnAiStrength.Text = "Weak";
      }
      else if (this.BtnAiStrength.Text == "Weak")
      {
        this.BtnAiStrength.Text = "Medium";
      }
      else
      {
        this.BtnAiStrength.Text = "Strong";
      }
    }

    private void OnKeyUppressed(object sender, KeyEventArgs e)
    {

    }

    private void ShowPause()
    {
      BtnExitPause.Visible = true;
      BtnPauseOption.Visible = true;
      BtnPauseResume.Visible = true;
    }

    private void OnBtnExitPauseClicked(object sender, EventArgs e)
    {
      ShowMenu();
      HideBoard();
      HidePause();
      this.Lblscore.Hide();
      this.BtnPause.Visible = false;
      pause = false;
    }

    private void HidePause()
    {
      BtnExitPause.Visible = false;
      BtnPauseOption.Visible = false;
      BtnPauseResume.Visible = false;
    }

    private void HideBoard()
    {
      foreach (var b in Board)
      {
        b.Hide();
      }
    }
    private void ShowBoard()
    {
      foreach (var b in Board)
      {
        b.Show();
      }
    }

    private void onKeyPressed(object sender, KeyPressEventArgs e)
    {
    }

    private void OnPauseClicked(object sender, EventArgs e)
    {
      HideBoard();
      ShowPause();
      this.Lblscore.Hide();
      pause = true;
    }

    private void OnPauseOptionClicke(object sender, EventArgs e)
    {
      HidePause();
      this.BtnPause.Visible = false;
      OnOptionClicked(sender, e);
    }

    private void OnPauseResumeClicked(object sender, EventArgs e)
    {
      HidePause();
      ShowBoard();
      this.Lblscore.Show();
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

    private static string StringToBits(string s)
    {
      string result = "";
      foreach (char c in s)
      {
        // Convert character to its ASCII value
        int asciiValue = Convert.ToInt32(c);
        // Convert ASCII value to binary and pad with leading zeros to ensure it's 8 bits long
        string binaryValue = Convert.ToString(asciiValue, 2).PadLeft(8, '0');
        result += binaryValue;
      }
      return result;
    }
    private static string BitsToString(string binaryString)
    {
      // Ensure the binary string's length is a multiple of 8
      if (binaryString.Length % 8 != 0)
      {
        throw new ArgumentException("Binary string length must be a multiple of 8.");
      }

      string result = "";
      for (int i = 0; i < binaryString.Length; i += 8)
      {
        // Get the current 8-bit chunk
        string byteString = binaryString.Substring(i, 8);
        // Convert the 8-bit chunk to an integer (ASCII value)
        int asciiValue = Convert.ToInt32(byteString, 2);
        // Convert the ASCII value to the corresponding character
        char character = Convert.ToChar(asciiValue);
        result += character;
      }
      return result;
    }
  }
}