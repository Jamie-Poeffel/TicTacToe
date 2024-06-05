using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe1._0
{
  public class WriteLogs
  {
    // Logs erstellen und einen Zeitpunkt festlegen
    DateTime time = DateTime.Now;
    private const String FilePfad = ".\\..\\..\\..\\Logs\\Logs.txt";


    // Beim aufrufen dieser klasse kann man sagen wie man in das File Logs.txt -
    // schreiben will mit einer fehler meldung oder mit einer message oder wann -
    // sdie app geöffet wurde und wann sie geschlossen wurde.
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
    public WriteLogs() 
    {
    }

    private void Write(string message)
    {
      // diese Methode schreibt das datum und die message in das file Logs.txt
      using (StreamWriter writer = new StreamWriter(FilePfad, true))
      {
        writer.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}]: {message}");
      }
    }
    private void OnStartClose(byte i)
    {
      // diese Methode schreibt wann die App geöffnet wurde und wann sie wieder geschlossen wurde.
      string message = (i == 0) ? "App Closed" : "App Started";
      if (File.Exists(FilePfad))
      {
        if (message == "App Closed")
          using (StreamWriter writer = new StreamWriter(FilePfad, true))
          {
            writer.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}]: {message}\n");
          }
        else
          using (StreamWriter writer = new StreamWriter(FilePfad, true))
          {
            writer.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}]: {message}");
          }
      }
      else
      {
        do
        {
          Cursor.Current = Cursors.WaitCursor;
        } while (!File.Exists(FilePfad));
      }

    }
    private void Exep(Exception e)
    {
      // Diese Methode schreibt Fehler meldungen in das file Logs.txt
      string message = $"Error : {e}";
      using (StreamWriter writer = new StreamWriter(FilePfad, true))
      {
        writer.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}]: {message}");
      }
    }
    static async Task Wait()
    {
      // Dieser Task erstellt das file Logs.txt wenn es nicht vorhanden ist und wartet bis es benutzt werden kann.
      if (!File.Exists(FilePfad))
      {
        File.WriteAllText(FilePfad, $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}]: Logs Erstellt\n");
      }

      while (!File.Exists(FilePfad))
      {
        await Task.Delay(1000);
      }
    }
    public string getLogs()
    {
      string value = string.Empty;
      using (StreamReader reader = new StreamReader(FilePfad))
      {
        do
        {
          value += reader.ReadLine();
          value += "?";
        } while (!reader.EndOfStream);
      }
      return value;
    }
  }
}
