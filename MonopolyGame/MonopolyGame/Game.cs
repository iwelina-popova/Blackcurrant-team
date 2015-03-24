namespace MonopolyGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Model.Classes;

    class Game
    {
        static void Main(string[] args)
        {
            Board board = Board.CreateBoardInstance();
            Player pesho = new Player("Pesho");
            Player gosho = new Player("Gosho");
            board.AddPlayer(pesho);
            board.AddPlayer(gosho);

            while (board.PlayerCount > 1)
            {

                gosho.Move(Dice.Roll() + Dice.Roll(), board.BoardArr.Length);
                if (board.BoardArr[gosho.Position] != null)
                {
                    board.BoardArr[gosho.Position].Action(gosho);
                }
                Console.WriteLine(gosho);

                if (gosho.IsBankrupt)
                {
                    board.RemovePlayer(gosho);
                    Console.WriteLine(String.Format("{0} Wins !", pesho.Name));
                    break;
                }

                pesho.Move(Dice.Roll() + Dice.Roll(), board.BoardArr.Length);
                if (board.BoardArr[pesho.Position] != null)
                {
                    board.BoardArr[pesho.Position].Action(pesho);
                }
                Console.WriteLine(pesho);

                if (pesho.IsBankrupt)
                {
                    board.RemovePlayer(pesho);
                    Console.WriteLine(String.Format("{0} Wins !", gosho.Name));
                }
            }

            Console.WriteLine("Game over");
        }
    }
}
