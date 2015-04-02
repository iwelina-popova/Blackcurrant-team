namespace MonopolyGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Model.Classes;
    using Model.Delegates;
    using Model.Engine;
    using Model.Engine.Contracts;

    public class Game
    {
        // public static void PlayerTurn(Player player, Tile[] tiles, int firstRoll, int secondRoll)
        // {
        //    Tile currentTile;

        //    player.Move(firstRoll + secondRoll, tiles.Length);
        //    if (tiles[player.Position] != null)
        //    {
        //        currentTile = tiles[player.Position];
        //        currentTile.Action(player);
        //    }
        //    Delegates.PrintingMethodInstance(player);
        // }

        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Start();
            Console.WriteLine("Game over");

            // while (board.PlayerCount > 1)
            // {
            //    foreach (Player player in board.Players)
            //    {
            //        int firstRoll = Dice.Roll();
            //        int secondRoll = Dice.Roll();
            //        Delegates.PrintingMethodInstance(String.Format("{0} rolls dice...", player.Name));
            //        Delegates.PrintingMethodInstance(String.Format("first dice rolled: {0} second dice rolled: {1}", firstRoll, secondRoll));

            //        PlayerTurn(player, board.Tiles, firstRoll, secondRoll);

            //        if (player.IsBankrupt)
            //        {
            //            board.RemovePlayer(player);
            //            if (board.PlayerCount <= 1)
            //            {
            //                Delegates.PrintingMethodInstance(String.Format("{0} Wins !", board.Players[0].Name));
            //                break;
            //            }
            //        }
            //    }
            // }
        }
    }
}
