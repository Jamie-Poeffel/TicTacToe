using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe1._0
{
  // the Pieces can be in one of those three states 
  internal enum States
  {
    X,
    O,
    F
  }

  internal class Pieces : Button
  {
    public States state = States.F;
    //Create buttons for the grid
    public Pieces(int x, int y)
    {
      Location = new System.Drawing.Point(x, y);
      Size = new System.Drawing.Size(100, 100);
    }
  }
}
