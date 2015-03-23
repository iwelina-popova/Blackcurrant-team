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
            Board board = new Board();
            Player pesho = new Player("Pesho");
            Player gosho = new Player("Gosho");
            board.AddPlayer(pesho);
            board.AddPlayer(gosho);
            Dice dice = new Dice();

            while (board.PlayerCount > 1)
            {

                gosho.Move(dice, board.BoardArr);
                Console.WriteLine(gosho);

                if (gosho.Money <= 0)
                {
                    board.RemovePlayer(gosho);
                    Console.WriteLine(String.Format("{0} Wins !", pesho.Name));
                    break;
                }


                pesho.Move(dice, board.BoardArr);
                Console.WriteLine(pesho);

                Console.WriteLine(pesho);
                if (pesho.Money <= 0)
                {
                    board.RemovePlayer(pesho);
                    Console.WriteLine(String.Format("{0} Wins !", gosho.Name));
                }
            }

            Console.WriteLine("Game over");
        }
    }
}
