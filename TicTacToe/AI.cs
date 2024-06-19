using System;

namespace TicTacToe1._0
{
  internal class AI
  {
    public int[] GetMove(Pieces[,] board, States state)
    {
      int[] move = new int[2];
      Random rand = new Random();

      // Wenn das Brett fast leer ist, mach einen zufälligen Zug oder nimm die Mitte
      if (IsBoardEmpty(board) < 2)
      {
        if (board[1, 1].state == States.F)
        {
          move[0] = 1;
          move[1] = 1;
        }
        else
        {
          do
          {
            move[0] = rand.Next(0, 3);
            move[1] = rand.Next(0, 3);
          } while (board[move[0], move[1]].state != States.F);
        }
        return move;
      }
      else
      {
        // Prüfe zuerst auf einen möglichen Gewinnzug
        int[] winningMove = GetWinningMove(board, state);
        if (winningMove != null)
        {
          return winningMove;
        }
        // Falls kein Gewinnzug möglich ist, verwende MiniMax
        return MiniMax(board, state);
      }
    }

    private int[] GetWinningMove(Pieces[,] board, States state)
    {
      for (int i = 0; i < 3; i++)
      {
        for (int j = 0; j < 3; j++)
        {
          if (board[i, j].state == States.F)
          {
            board[i, j].state = state;
            if (CheckWin(board, state))
            {
              board[i, j].state = States.F;
              return new int[] { i, j };
            }
            board[i, j].state = States.F;
          }
        }
      }
      return null;
    }

    public int[] MiniMax(Pieces[,] board, States state)
    {
      int bestScore = (state == States.O) ? int.MinValue : int.MaxValue;
      int[] bestMove = new int[2];

      if (IsBoardFull(board) || CheckWin(board, States.X) || CheckWin(board, States.O))
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
      for (int i = 0; i < 3; i++)
      {
        for (int j = 0; j < 3; j++)
        {
          if (board[i, j].state == States.F) return false;
        }
      }
      return true;
    }

    private bool CheckWin(Pieces[,] board, States state)
    {
      for (int i = 0; i < 3; i++)
      {
        if ((board[i, 0].state == state && board[i, 1].state == state && board[i, 2].state == state) ||
            (board[0, i].state == state && board[1, i].state == state && board[2, i].state == state))
          return true;
      }
      if ((board[0, 0].state == state && board[1, 1].state == state && board[2, 2].state == state) ||
          (board[0, 2].state == state && board[1, 1].state == state && board[2, 0].state == state))
        return true;
      return false;
    }

    private int IsBoardEmpty(Pieces[,] board)
    {
      int value = 0;
      for (int i = 0; i < 3; i++)
      {
        for (int j = 0; j < 3; j++)
        {
          if (board[i, j].state != States.F) value++;
        }
      }
      return value;
    }
  }
}
