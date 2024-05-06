using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
  // the Pieces can be in one of those three states 
  enum States
  {
    X,
    O,
    F
  }
  class Pieces : Button
  {
    BestScore Log = null;
    public States state = States.F;
    public int _score;
    List<Pieces> _fields = new List<Pieces>();
    Pieces BestMove = null;
    //Create buttons for the grid
    public Pieces(int x, int y, int Score)
    {
      Location = new System.Drawing.Point(x, y);
      Size = new System.Drawing.Size(100, 100);
      _fields.Add(new Pieces(x, y, 0));
    }
    public Pieces Best(int x, int y, int score)
    {
      BestMove = new Pieces(x, y, score);
      Log = new BestScore($"Best Move = x{x} ,y{y}, score{score}");
      return BestMove;
    }
  }
}
