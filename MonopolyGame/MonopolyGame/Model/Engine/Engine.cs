namespace MonopolyGame.Model.Engine
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using Model.Common.Helpers;
    using Model.Common.Validators;
    using Model.Engine.Contracts;
    using Model.Classes.Tiles;
    using Model.Classes.Tiles.Contracts;
    using Model.Enumerations;
    using Model.Classes.Cards;
    using Model.Classes.Cards.Contracts;
    using Model.Classes;
    using Model.Classes.Actions.Contracts;

    public class Engine : IEngine
    {
        private Board board;
        private ICollection<Player> players;
        private Queue<ChanceCard> chanceCards;
        private Queue<CommunityCard> communityCards;
        private Dice firstDice;
        private Dice secondDice;
        private static Random r = new Random();
        private static ConsoleColor defaultColor = ConsoleColor.Green;

        public Engine()
        {
            Initialize();
        }

        public ICollection<Player> Players
        {
            get
            {
                return new List<Player>(this.players);
            }
        }

        public void RemovePlayer(Player player)
        {
            this.players.Remove(player);
        }

        public void AddPlayer(Player player)
        {

            this.players.Add(player);
        }

        public void Initialize()
        {
            board = Board.Instance;
            firstDice = new Dice();
            secondDice = new Dice();
            this.players = new List<Player>();
            this.LoadTiles();
            this.chanceCards = this.LoadChanceCards();
            this.communityCards = this.LoadCommunityCards();
        }


        public void Start()
        {
             
            SetDefaultForegroundColor();
          //  Console.WriteLine("Select number of players: ");
          //  int number = int.Parse(Console.ReadLine());
          //  if (number < 2)
          //  {
         //       throw new ArgumentException("Atleast two players should play the game");
         //   }
            Console.Write("Player 1 name:");
            Player firstPlayer = new Player(Console.ReadLine());
            Console.Write("Player 2 name:");
            Player secondPlayer = new Player(Console.ReadLine());
            this.AddPlayer(firstPlayer);
            this.AddPlayer(secondPlayer);
         //   StatusPlayer(firstPlayer, secondPlayer);
        //   for (int i = 0; i < number; i++)
        //    {
        //        Console.Write("Player name:");
        //        this.AddPlayer(new Player(Console.ReadLine()));

        //    }

            
            while (true)
            {
                foreach (Player player in this.players)
                {
                    Console.WriteLine();
                    ClearConsole();
                    RenderPlayersStats(player);

                    this.PlayerTurn(player, board, firstDice.Roll(), secondDice.Roll());
                   // ClearConsole();
                    ClearPositionAndMoneyInfo();
                    StatusPlayer(firstPlayer, secondPlayer);
                   // Console.ReadLine();
                  
                    if (this.CheckWinningCondition())
                    {
                        break;
                    }
                }

                if (CheckWinningCondition())
                {
                    break;
                }

            }
        }

        public bool CheckWinningCondition()
        {
            return this.players.Count <= 1;
        }


        public void PlayerTurn(Player player, Board boar, int firstRoll, int secondRoll)
        {
            Tile currentTile;

            this.MovePlayer(player, firstDice, secondDice, board);
            currentTile = board.GetTileAtPosition(player.Position);

            Console.WriteLine("Current tile {0}", currentTile);
            IChoosableAction actionTile = currentTile as IChoosableAction;
            if (actionTile != null)
            {
                this.ExecuteActionFromTile(actionTile, player);
            }

            if (currentTile is CommunityTile)
            {
                CommunityCard card = CardHelpers.DrawCard(this.communityCards);

                Console.WriteLine("Community Card");
                Console.WriteLine("Card Desciption: {0}", card.Description);
                Console.ReadLine();

                this.ExecuteActionFromCard(card, player);
            }
            else if (currentTile is ChanceTile)
            {
                ChanceCard card = CardHelpers.DrawCard(this.chanceCards);

                Console.WriteLine("Chance Card");
                Console.WriteLine("Card Desciption: {0}", card.Description);
                Console.ReadLine();

                this.ExecuteActionFromCard(card, player);
            }
        }

        private void MovePlayer(Player player, Dice firstDice, Dice secondDice, Board board)
        {
            int spaces = firstDice.Roll() + secondDice.Roll();

            int newPosition = player.Position + spaces;

            if (newPosition >= board.Size)
            {
                newPosition -= board.Size;
                player.AddMoney(200);
            }
            player.Move(newPosition);
        }

        private void ExecuteActionFromCard(Card card, Player player)
        {
            card.Actions.First().Execute(card, player);
        }

        private void ExecuteActionFromTile(IChoosableAction tile, Player player)
        {
            if (tile.Actions.Count > 1)
            {
                ChoosableActionTile actionTile = tile as ChoosableActionTile;
                ObjectValidator.NullObjectValidation(actionTile);

                ICollection<IAction> availableActions = this.GetAvailableActions(actionTile, player);

                Console.WriteLine("Choose Action");
                Console.WriteLine(this.AvailableActionsToString(availableActions));

                string actionString = Console.ReadLine();

                IAction chosenAction = this.ChooseAction(availableActions, actionString);
                chosenAction.Execute(tile, player);

                if (player.IsBankrupt)
                {
                    this.players.Remove(player);
                }
            }
            else
            {
                Console.WriteLine("Continue...");
                Console.ReadLine();

                tile.Actions.First().Execute(tile, player);

                if (player.IsBankrupt)
                {
                    this.players.Remove(player);
                }
            }
        }

        private IAction ChooseAction(ICollection<IAction> availableActions, string actionString)
        {
            switch (actionString)
            {
                case "buy": return availableActions.First(action => action is IBuyable);
                case "payrent": return availableActions.First(action => action is IRentable);
                case "sell": return availableActions.First(action => action is ISellable);
                case "paytax": return availableActions.First(action => action is ITaxable);
                default:
                    throw new ArgumentException("Invalid action");
            }
        }

        private string AvailableActionsToString(IEnumerable<IAction> availableActions)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Available actions: ");
            foreach (IAction action in availableActions)
            {
                if (action is IBuyable)
                {
                    result.AppendLine("buy");
                }
                else if (action is ISellable)
                {
                    result.AppendLine("sell");
                }
                else if (action is IRentable)
                {
                    result.AppendLine("payrent");
                }
                else if (action is ITaxable)
                {
                    result.AppendLine("paytax");
                }
            }
            return result.ToString();
        }

        private ICollection<IAction> GetAvailableActions(ChoosableActionTile tile, Player player) 
        {
            List<IAction> availableActions = new List<IAction>();
            foreach(IAction action in tile.Actions)
            {
                if(action is IBuyable){
                    if(((PropertyTile)tile).Owner == null && ((PropertyTile)tile).Price <= player.Money)
                    {
                        availableActions.Add(action);
                    }
                    continue;
                }else if(action is ISellable)
                {
                    if(((PropertyTile)tile).Owner == player)
                    {
                        availableActions.Add(action);
                    }
                    continue;
                }

                availableActions.Add(action);
            }

            return availableActions;
        }

        private void LoadTiles()
        {
            board.AddTile(new StartTile());
            board.AddTile(new StreetTile("Old Kent Road", 60, 2, DistrictColor.Brown));
            board.AddTile(new CommunityTile());
            board.AddTile(new StreetTile("Whitechapel Road", 60, 4, DistrictColor.Brown));
            board.AddTile(new TaxTile("Income Tax", 200));
            board.AddTile(new StationTile("Kings Cross Station"));
            board.AddTile(new StreetTile("The Angel Islington", 100, 6, DistrictColor.LiteBlue));
            board.AddTile(new ChanceTile());
            board.AddTile(new StreetTile("Euston Road", 100, 6, DistrictColor.LiteBlue));
            board.AddTile(new StreetTile("Pentoville Road", 8, 120, DistrictColor.LiteBlue));
            board.AddTile(new JailTile());
            board.AddTile(new StreetTile("Pall Mall", 140, 10, DistrictColor.Pink));
            board.AddTile(new TaxTile("Electric Company", 150));
            board.AddTile(new StreetTile("Whitehall", 140, 10, DistrictColor.Pink));
            board.AddTile(new StreetTile("Northmurl`d Avenue", 160, 12, DistrictColor.Pink));
            board.AddTile(new StationTile("Marylebone Station"));
            board.AddTile(new StreetTile("Bow Street", 180, 14, DistrictColor.Orange));
            board.AddTile(new CommunityTile());
            board.AddTile(new StreetTile("Marlborough Street", 180, 14, DistrictColor.Orange));
            board.AddTile(new StreetTile("Vine Street", 200, 16, DistrictColor.Orange));
            board.AddTile(new FreeParking("Free Parking"));
            board.AddTile(new StreetTile("Strand", 220, 18, DistrictColor.Red));
            board.AddTile(new ChanceTile());
            board.AddTile(new StreetTile("Fleet Street", 220, 18, DistrictColor.Red));
            board.AddTile(new StreetTile("Trafalgar Square", 240, 20, DistrictColor.Red));
            board.AddTile(new StationTile("Fenchurch st. Station"));
            board.AddTile(new StreetTile("Leicester Square", 260, 22, DistrictColor.Yellow));
            board.AddTile(new StreetTile("Coventry Street", 260, 22, DistrictColor.Yellow));
            board.AddTile(new TaxTile("Water Works", 150));
            board.AddTile(new StreetTile("Piccadilly", 280, 22, DistrictColor.Yellow));
            board.AddTile(new GoToJailTile());
            board.AddTile(new StreetTile("Regent Street", 300, 26, DistrictColor.Green));
            board.AddTile(new StreetTile("Oxford Street", 300, 26, DistrictColor.Green));
            board.AddTile(new CommunityTile());
            board.AddTile(new StreetTile("Bond Street", 320, 28, DistrictColor.Green));
            board.AddTile(new StationTile("Liverpool st. Station"));
            board.AddTile(new ChanceTile());
            board.AddTile(new StreetTile("Park Lane", 350, 35, DistrictColor.DarkBlue));
            board.AddTile(new TaxTile("Super Tax", 100));
            board.AddTile(new StreetTile("Mayfair", 400, 50, DistrictColor.DarkBlue));
        }

        private Queue<ChanceCard> LoadChanceCards()
        {
            var CardsArr = new[]
                {
                 new ChanceCard("Destributed Dental System Attack - you lose $150", CardType.Lose, 150),
                 new ChanceCard("Ouch - Heartbleed - you lose $100", CardType.Lose ,100),
                 new ChanceCard("You used float insted of decimal - you lose $50",CardType.Lose, 50),
                 new ChanceCard("Your Visual Studio license expired - you lose $75", CardType.Lose, 75),
                 new ChanceCard("Blue Screen of Death!!! - you lose $20", CardType.Lose, 20),
                 new ChanceCard("A flush of inspiration - your code compiled without any errors! - you win $100",CardType.Win, 100),
                 new ChanceCard("You fixed a nasty bug - you win $50", CardType.Win,50),
                 new ChanceCard("You received a Telerik Academy Ninja Certificate - you win $150",CardType.Win,150),
                 new ChanceCard("Internet Explorer has extincted! - you win $75",CardType.Win, 75),
                 new ChanceCard("Intenet boost! - you win $20", CardType.Win,20),
                };

            return CardHelpers.ShuffleCards(CardsArr);
        }

        private Queue<CommunityCard> LoadCommunityCards()
        {
            var CardsArr = new[]
               {
                new CommunityCard("Your HDD burnt - you lose $150", CardType.Lose, 150),
                new CommunityCard("Your RAM burnt - you lose $100", CardType.Lose, 100),
                new CommunityCard("You get a raise - you win $150", CardType.Win,150),
                new CommunityCard("You receive 2GB RAM - you win $100", CardType.Win, 100),
                new CommunityCard("Your laptop computer crashed - you lose $50",CardType.Lose, 50),
                new CommunityCard("You spill coffe on your keyboard - you lose $20", CardType.Lose, 20),
                new CommunityCard("Your dog ate you laptop computer recharger - you lose $75", CardType.Lose, 75),
                new CommunityCard("You receive a new battery for your laptop computer - you win $75", CardType.Win,75),
                new CommunityCard("A gift! - new smartphone for you - you win $50", CardType.Win,50),
                new CommunityCard("You have a birthday! - you win $20", CardType.Win ,20),
               };

            return CardHelpers.ShuffleCards(CardsArr);
        }

        private static void SetDefaultForegroundColor()
        {
            Console.ForegroundColor = defaultColor;
        }
        private void RenderPlayersStats(Player currentPlayer) //int playersCount , Player anotherPlayer
        {
            Console.SetCursorPosition(5, 0);//Console.SetCursorPosition(5, 3 + playersCount);
            Console.WriteLine("Current Player: << {0} >>", currentPlayer.Name);
            Console.SetCursorPosition(5, 2);
            Console.WriteLine("Position: << {0} >>", currentPlayer.Position);
            Console.SetCursorPosition(5, 4);
            Console.WriteLine("Money: << {0} >>", currentPlayer.Money);
            Console.SetCursorPosition(0, 8);      

        }
        private void ClearConsole()
        {
            for (int i = 0; i < 70; i++)
            {
                if (i < 7)
                {
                    Console.SetCursorPosition(0, i);
                    Console.WriteLine(new string(' ', 49));
                }
                else
                {
                    Console.SetCursorPosition(0, i);
                    Console.WriteLine(new string(' ', 80));
                }
            }

        }
        private void StatusPlayer(Player firstPlayer, Player secondPlayer)
        {
            Console.SetCursorPosition(50, 0);
            Console.WriteLine("Name: {0}", firstPlayer.Name);
            Console.SetCursorPosition(50, 1);
            Console.WriteLine("Position: {0}", firstPlayer.Position);
            Console.SetCursorPosition(50, 2);
            Console.WriteLine("Money: {0}", firstPlayer.Money);
            Console.SetCursorPosition(50, 3);

            Console.WriteLine(new string('-',10));

            Console.SetCursorPosition(50, 4);
            Console.WriteLine("Name: {0}", secondPlayer.Name);
            Console.SetCursorPosition(50, 5);
            Console.WriteLine("Position: {0}", secondPlayer.Position);
            Console.SetCursorPosition(50, 6);
            Console.WriteLine("Money: {0}", secondPlayer.Money);
        }
        private void ClearPositionAndMoneyInfo()
        {
            
            Console.SetCursorPosition(50, 1);
            Console.WriteLine(new string(' ',13));
            Console.SetCursorPosition(50, 2);
            Console.WriteLine(new string(' ',11));
          
         //   Console.WriteLine(new string('-', 10));

            Console.SetCursorPosition(50, 5);
            Console.WriteLine(new string(' ', 13));
            Console.SetCursorPosition(50, 6);
            Console.WriteLine(new string(' ', 11));
        }
        

    }
}
