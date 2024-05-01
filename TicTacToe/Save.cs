using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
  public partial class Save : Form
  {
    MainForms MF = null;
    public Save(MainForms ma)
    {
      InitializeComponent();
      MF = ma; 
    }
    private void SaveScore(string filename)
    {
      String Filepath = $".\\..\\..\\..\\SavedScores\\{filename}.txt";
      if (!File.Exists(Filepath))
      {
        File.WriteAllText(Filepath, $"{MF.xScore}, {MF.oScore}" + "\n" + $"Score: PlX: {MF.xScore} - PlO: {MF.oScore}");
      }
      else MessageBox.Show("Name is given");
    }

    private void OnClosing(object sender, FormClosingEventArgs e)
    {
      if (DialogResult != DialogResult.OK) return;
      if (string.IsNullOrEmpty(TbxFilename.Text))
      {
        e.Cancel = true;
        MessageBox.Show("Filename must be given");
      }
      else 
      {
        SaveScore(TbxFilename.Text);
      }
    }
  }
}
