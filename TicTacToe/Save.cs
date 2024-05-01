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
    private bool SaveScore(string filename)
    {
      String Filepath = $".\\..\\..\\..\\SavedScores\\{filename}.txt";
      if (!File.Exists(Filepath))
      {
        File.WriteAllText(Filepath, $"{MF.xScore}, {MF.oScore}" + "\n" + $"Score: PlX: {MF.xScore} - PlO: {MF.oScore}");
        return true;
      }
      else return false;
    }

    private void OnClosing(object sender, FormClosingEventArgs e)
    {
      // Wenn das Eingabe fenster schliesst und Dialog reslutat Ok ist und Textfeld nicht Leer ist.
      // speichern in datei mit dateiname 
      if (DialogResult != DialogResult.OK) return;
      if (string.IsNullOrEmpty(TbxFilename.Text))
      {
        e.Cancel = true;
        MessageBox.Show("Filename must be given");
      }
      else
      {
        // Wenn datei name schon vergeben dann nicht schliessen sondern ändern lassen
        if (!SaveScore(TbxFilename.Text))
        {
          MessageBox.Show("Name is given");
          e.Cancel = true;
        }
      }
    }

  }
}
