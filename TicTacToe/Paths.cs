using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{ 
  enum Stat
  {
    W,
    L,
    D
  }
  internal class Paths
  {
    public Stat stat = Stat.D;
    private int _anzahlfelder = 0;
    private int _startx = 0;
    private int _starty = 0;
    private double _Indexscore = double.NaN;
    List<Pieces> freeSpace = new List<Pieces>();
    Pieces[,] Board = null;



    public Paths(Pieces[,] Bord, int anzahlfelder)
    {
      _anzahlfelder = anzahlfelder;
      Search();
      Board = Bord;


    }

    private void Search()
    {
      for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
        {
          if (Board[i, j].state != States.F)
          {
            freeSpace.Add(Board[i, j]);
          }
        }
    }
    private void checke()
    {
      if (CheckforPossibleWinloss() == States.O)
      {
        _Indexscore = 1;
      }
      else if (CheckforPossibleWinloss() == States.X)
      {
        _Indexscore = 0.1;
      }
    }

    private States CheckforPossibleWinloss()
    {
      // Rows
      //check if rows are full in a winning position
      for (int i = 0; i < 3; i++)
        if (Board[i, 1].state == Board[i, 0].state
          && Board[i, 1].state == Board[i, 2].state
          && Board[i, 1].state != States.F)
        {
          return Board[i, 1].state;
        }
      // Colunms
      //check if colunms are full in a winning position
      for (int j = 0; j < 3; j++)
        if (Board[1, j].state == Board[0, j].state
          && Board[1, j].state == Board[2, j].state
          && Board[1, j].state != States.F)
        {
          return Board[1, j].state;
        }

      // Diagonals
      //check if the diagonals are full in a winning position
      if (Board[0, 0].state == Board[1, 1].state
        && Board[1, 1].state == Board[2, 2].state
        && Board[1, 1].state != States.F)
        return Board[1, 1].state;
      else if (Board[0, 2].state == Board[1, 1].state
      && Board[1, 1].state == Board[2, 0].state
      && Board[1, 1].state != States.F)
        return Board[1, 1].state;

      return States.F;
    }
  }
}
