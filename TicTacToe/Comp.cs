using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
  class Comp
  {
   
    Random rand = new Random();
    public Comp(Pieces[,] Board, MainForms main, States sTate) 
    {
      var board = get_move(Board, sTate, main);
      board.state = States.O;
      board.Click += main.Play;
    }
    public Pieces get_move(Pieces[,] Board, States state, MainForms main)
    {
      if (SearchBoard(Board))
      {
        return Board[rand.Next(0, 4), rand.Next(0, 4)];
      }
      else 
      {
        minimax(Board, state, main);
        return Board[0,0];
      }
    }
    public int minimax(Pieces[,] Board, States state, MainForms main)
    {
      var bord = Board;
      var max_player = (main.role % 2 == 0) ? States.X : States.O;
      var other_player = (max_player == States.X) ? States.O : States.X;
      var Best = 0;

      if (state == max_player)
        Best = int.MinValue;
      else
        Best = int.MaxValue;
      for (var i = 0; i < num_Empty(Board); i++)
      {
        if(possible_move(Board) != null)
          possible_move(Board).state = max_player;
        int sim_score = this.minimax(Board, other_player, main);


        //moves rückgängig machen
        Board = bord;

        if (state == max_player) 
        {
          if (sim_score > Best)
          { 
            Best = sim_score;
          }
        }
        else
        {
          if (sim_score < Best)
          {
            Best = sim_score;
          }
        }
      }   
      return Best;
    }
    public bool SearchBoard(Pieces[,] Board)
    {
      for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
          if (Board[i, j].state != States.F) return false;
      return true;
    }
    private int num_Empty(Pieces[,] Board)
    {
      var Empty = 0;
      for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
          if (Board[i, j].state == States.F) Empty++;

      return Empty;
    }
    private Pieces possible_move(Pieces[,] Board)
    {
      for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
          if (Board[i, j].state == States.F) return Board[i, j];
      return null;
    }
  }

}
