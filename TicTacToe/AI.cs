using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
  class AI
  {
    public int[] MiniMax(Pieces[,] board, States state)
    {
      int bestScore = (state == States.O) ? int.MinValue : int.MaxValue;
      int[] bestMove = new int[2];

      if (IsBoardFull(board) || CheckWin(board ,States.X) || CheckWin(board, States.O))
      {
        return new int[] { -1, -1 };
      }

      for (int i = 0; i < 3; i++)
      {
        for (int j = 0; j < 3; j++)
        {
          if (board[i, j].state == States.F)
          {
            board[i, j].state = state;
            int score = MiniMax(board, state == States.X ? States.O : States.X)[0];
            board[i, j].state = States.F;
            if (state == States.O)
            {
              if (score > bestScore)
              {
                bestScore = score;
                bestMove[0] = i;
                bestMove[1] = j;
              }
            }
            else
            {
              if (score < bestScore)
              {
                bestScore = score;
                bestMove[0] = i;
                bestMove[1] = j;
              }
            }
          }
        }
      }
      return bestMove;

    }
    private bool IsBoardFull(Pieces[,] board) 
    {
      for (int i = 0;i < 3; i++)
        for (int j = 0;j < 3; j++)
        {
          if(board[i, j].state == States.F) return false;
        }
      return true;
    }
    private bool CheckWin(Pieces[,] board, States states) 
    {
      for (int i = 0; i < 3; i++)
      {
        if ((board[i, 0].state == states && board[i, 1].state == states && board[i, 2].state == states) ||
            (board[0, i].state == states && board[1, i].state == states && board[2, i].state == states))
          return true;
      }
      if ((board[0, 0].state == states && board[1, 1].state == states && board[2, 2].state == states) ||
          (board[0, 2].state == states && board[1, 1].state == states && board[2, 0].state == states))
        return true;
      return false;
    }
  }
}
