using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
    public static void Main()
    {
        Game game = new Game();
        game.Play();

        Console.ReadLine();
    }
}

public class Game
{
    // Field 
    private Board _board;
    private List<Player> _players;

    //Constructor
    public Game()
    {
        Console.OutputEncoding = Encoding.UTF8;

        _board = new Board();

        _players = new List<Player>()
        {
            new Player() {Symbole = "\u03a7"},
            new Player() {Symbole = "\u25cb"}
        };
    }

    // Methods
    public void Play()
    {
        // Get players name

        Console.WriteLine("Player 1 Name?");
        _players[0].Name = Console.ReadLine();

        Console.WriteLine("Player 2 Name?");
        _players[1].Name = Console.ReadLine();

        Console.WriteLine("*****************************");

        do
        {
            ChangePlayerTurn();
            _board.DrawBoard();

            var playerAtTurn = _players.Single(p => p.IsMyTurn);

            Console.WriteLine(playerAtTurn.Name);
            Console.WriteLine("Enter Row:");
            int row = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter Column:");
            int column = Int32.Parse(Console.ReadLine());

            _board.PlaceMark(row, column, playerAtTurn.Symbole);

        } while (!_board.CheckForWin() && !_board.CheckForTie());

        _board.DrawBoard();

        if (_board.CheckForWin())
        {
            Console.WriteLine($"Congrats {_players.Single(p => p.IsMyTurn).Name} you have won!");
            Console.WriteLine($"Sorry {_players.Single(p => !p.IsMyTurn).Name} maybe next time!");
        }

        if (_board.CheckForTie())
        {
            Console.WriteLine($"Player {_players[0].Name} and {_players[1].Name} have tie.");
        }
    }

    private void ChangePlayerTurn()
    {
        if (_players[0].IsMyTurn)
        {
            _players[0].IsMyTurn = false;
            _players[1].IsMyTurn = true;
        }
        else
        {
            _players[0].IsMyTurn = true;
            _players[1].IsMyTurn = false;
        }
    }
}

public class Board
{
    public string[][] board = new string[][]
    {
        new string[] {" ", " ", " "},
        new string[] {" ", " ", " "},
        new string[] {" ", " ", " "}
     };

    public void DrawBoard()
    {
        Console.WriteLine("  0 1 2");
        Console.WriteLine("0 " + String.Join("|", board[0]));
        Console.WriteLine("  -----");
        Console.WriteLine("1 " + String.Join("|", board[1]));
        Console.WriteLine("  -----");
        Console.WriteLine("2 " + String.Join("|", board[2]));
        return;
    }

    public void PlaceMark(int row, int column, string symbole)
    {
        board[row][column] = symbole;
    }

    public bool CheckForWin()
    {
        return HorizontalWin() || VerticalWin() || DiagonalWin();
    }

    public bool CheckForTie()
    {
        if (board[0][0] != " " && board[0][1] != " " && board[0][2] != " " && board[1][0] != " "
             && board[1][1] != " " && board[1][2] != " " && board[2][0] != " " && board[2][1] != " "
              && board[2][2] != " ")
        {
            return true;
        }

        return false;
    }

    public bool HorizontalWin()
    {
        if (board[0][0] == board[0][1] && board[0][0] == board[0][2] && board[0][0] != " ")
        {
            return true;
        }
        if (board[1][0] == board[1][1] && board[1][0] == board[1][2] && board[1][0] != " ")
        {
            return true;
        }
        if (board[2][0] == board[2][1] && board[2][0] == board[2][2] && board[2][0] != " ")
        {
            return true;
        }

        return false;
    }

    public bool VerticalWin()
    {
        if (board[0][0] == board[1][0] && board[0][0] == board[2][0] && board[0][0] != " ")
        {
            return true;
        }
        if (board[0][1] == board[1][1] && board[0][1] == board[2][1] && board[0][1] != " ")
        {
            return true;
        }
        if (board[0][2] == board[1][2] && board[0][2] == board[2][2] && board[0][2] != " ")
        {
            return true;
        }

        return false;
    }

    public bool DiagonalWin()
    {
        if (board[0][0] == board[1][1] && board[0][0] == board[2][2] && board[0][0] != " ")
        {
            return true;
        }
        if (board[2][0] == board[1][1] && board[2][0] == board[0][2] && board[2][0] != " ")
        {
            return true;
        }

        return false;
    }
}

public class Player
{
    //Properties

    public string Name { get; set; }
    public string Symbole { get; set; }
    public bool IsMyTurn { get; set; }
}