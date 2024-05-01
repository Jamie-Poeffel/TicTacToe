using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
  public class WriteLogs
  {
    // Logs erstellen und einen Zeitpunkt festlegen
    DateTime time = DateTime.Now;
    private const String FilePfad = ".\\..\\..\\..\\Logs\\Logs.txt";


     // Beim aufrufen dieser klasse kann man sagen wie man in das File Logs.txt schreiben will mit einer fehler meldung oder mit einer message oder wann die app geöffet wurde und wann sie geschlossen wurde.
    public WriteLogs(Exception e)
    {
      Task.Run(Wait);
      Exep(e);
    }
    public WriteLogs(string message)
    {
      Task.Run(Wait);
      Write(message);
    }
    public WriteLogs(byte i)
    {
      Task.Run(Wait);
      OnStartClose(i);
    }

    private void Write(string message)
    {
      using (StreamWriter writer = new StreamWriter(FilePfad, true))
      {
        writer.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] {message}");
      }
    }
    private void OnStartClose(byte i)
    {
      string message = (i == 0) ? "Closed" : "Opened";
      if (File.Exists(FilePfad))
      {
        using (StreamWriter writer = new StreamWriter(FilePfad, true))
        {
          writer.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] {message}");
        }
      }
      else 
      {
        do
        {
          Cursor.Current = Cursors.WaitCursor;
        }while(!File.Exists(FilePfad));
      }

    }
    private void Exep(Exception e)
    {
      string message = $"Error : {e}";
      using (StreamWriter writer = new StreamWriter(FilePfad, true))
      {
        writer.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] {message}");
      }
    }
    static async Task Wait()
    {
      if (!File.Exists(FilePfad))
      {
        File.WriteAllText(FilePfad, "Logs Erstellt\n");
      }

      while (!File.Exists(FilePfad))
      {
        await Task.Delay(1000); 
      }
    }
  }
}
