using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
  class BestScore
  {
    const String Filepath = ".\\..\\..\\..\\Logs\\AiBestMoves.txt"; 
    // Speichert die beste moves in AiBestMoves.txt
    public BestScore(string message)
    {
       if (File.Exists(Filepath)) 
       {
          // Kreiert das file
          File.WriteAllText(Filepath, message + "\n");
       }
       else 
       {
          using(StreamWriter writer = new StreamWriter(Filepath)) 
          {
            // Schreibt in das file
            writer.WriteLine(message + "\n");
          }
       }
    }
  }
}
