namespace MonopolyGame.Model.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Model.Classes;
    using Model.Classes.Actions.Contracts;
    using Model.Classes.Cards;
    using Model.Classes.Tiles;
    using Model.Classes.Tiles.Contracts;
    using Model.Common.Helpers;
    using Model.Engine.Contracts;
    using Model.Enumerations;

    public class Engine : IEngine
    {
        private static Random r = new Random();
        private Board board;
        private ICollection<Player> players;
        private Queue<ChanceCard> chanceCards;
        private Queue<CommunityCard> communityCards;
        private Dice firstDice;
        private Dice secondDice;

        public Engine()
        {
            this.Initialize();
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
            this.board = Board.Instance;
            this.firstDice = new Dice();
            this.secondDice = new Dice();
            this.players = new List<Player>();
            this.LoadTiles();
            this.chanceCards = this.LoadChanceCards();
            this.communityCards = this.LoadCommunityCards();
        }

        public void Start()
        {
            Console.WriteLine("Select number of players: ");
            int number = int.Parse(Console.ReadLine());
            if (number < 2)
            {
                throw new ArgumentException("Atleast two players should play the game");
            }

            for (int i = 0; i < number; i++)
            {
                Console.Write("Player name:");
                this.AddPlayer(new Player(Console.ReadLine()));
            }

            while (true)
            {
                foreach (Player player in this.players)
                {
                    this.PlayerTurn(player, this.board.Tiles, this.firstDice.Roll(), this.secondDice.Roll());
                    if (this.CheckWinningCondition())
                    {
                        break;
                    }
                }

                if (this.CheckWinningCondition())
                {
                    break;
                }
            }
        }

        public bool CheckWinningCondition()
        {
            return this.players.Count <= 1;
        }

        public void PlayerTurn(Player player, IList<Tile> tiles, int firstRoll, int secondRoll)
        {
            Tile currentTile;

            player.Move(firstRoll + secondRoll, tiles.Count);
            if (tiles[player.Position] != null)
            {
                currentTile = tiles[player.Position];

                Console.WriteLine(currentTile.Name);
                IChoosableAction actionTile = currentTile as IChoosableAction;
                if (actionTile != null)
                {
                    this.ExecuteActionFromTile(actionTile, player);
                }

                if (currentTile is CommunityTile)
                {
                    CommunityCard card = CardHelpers.DrawCard(this.communityCards);

                    Console.WriteLine(card.Description);
                    Console.WriteLine("Choose Options");
                    Console.ReadLine();

                    card.Actions.First().Execute(card, player);
                }
                else if (currentTile is ChanceTile)
                {
                    ChanceCard card = CardHelpers.DrawCard(this.chanceCards);

                    Console.WriteLine(card.Description);
                    Console.WriteLine("Continue...");
                    Console.ReadLine();

                    card.Actions.First().Execute(card, player);
                }
            }

            Console.WriteLine(player);
        }

        private void ExecuteActionFromTile(IChoosableAction tile, Player player)
        {
            if (tile.Actions.Count > 1)
            {
                Console.WriteLine("Continue");
                Console.ReadLine();
                foreach (IAction action in tile.Actions)
                {
                    action.Execute(tile, player);

                    if (player.IsBankrupt)
                    {
                        this.players.Remove(player);
                    }
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

        private void LoadTiles()
        {
            this.board.AddTile(new StartTile(null, 1180,630));
            this.board.AddTile(new StreetTile("SEE BURGER",1123, 630, 60, 2, StreetTileColor.Brown));
            this.board.AddTile(new CommunityTile(null, 1066, 630));
            this.board.AddTile(new StreetTile("SEE BURGER",1009,630, 80, 4, StreetTileColor.Brown));
            this.board.AddTile(new TaxTile("Buy new Motherboard", 952,630, 200));
            this.board.AddTile(new StationTile("MTEL", 895, 630));
            this.board.AddTile(new StreetTile("HP", 833, 630, 100, 6, StreetTileColor.LiteBlue));
            this.board.AddTile(new ChanceTile(null, 776,630));
            this.board.AddTile(new StreetTile("HP", 719, 630, 120, 6, StreetTileColor.LiteBlue));
            this.board.AddTile(new StreetTile("HP",662, 630, 8, 140, StreetTileColor.LiteBlue));
            this.board.AddTile(new  JailTile(null, 605,630, 50));
            this.board.AddTile(new  StreetTile("IBM",605,573,  150, 10, StreetTileColor.Pink));
            this.board.AddTile(new  TaxTile("Electric Company",605,516, 150));
            this.board.AddTile(new  StreetTile("IBM",605,459, 170, 10, StreetTileColor.Pink));
            this.board.AddTile(new  StreetTile("IBM",605,402,  190, 12, StreetTileColor.Pink));
            this.board.AddTile(new  StationTile("MTEL", 605, 345));
            this.board.AddTile(new  StreetTile("BLIZZARD",605,288,  200, 14, StreetTileColor.Orange));
            this.board.AddTile(new  CommunityTile(null, 605,231));
            this.board.AddTile(new  StreetTile("BLIZZARD",605,174, 210, 14, StreetTileColor.Orange));
            this.board.AddTile(new  StreetTile("BLIZZARD",605, 117,  210, 16, StreetTileColor.Orange));
            this.board.AddTile(new ChanceTile(null, 605, 60));
            this.board.AddTile(new  StreetTile("Microsoft", 662, 60, 220, 18, StreetTileColor.Red));
            this.board.AddTile(new  ChanceTile(null, 719,60));
            this.board.AddTile(new  StreetTile("Microsoft",776, 60, 230, 18, StreetTileColor.Red));
            this.board.AddTile(new  StreetTile("Microsoft", 833, 60, 240, 20, StreetTileColor.Red));
            this.board.AddTile(new  StationTile("MTEL",895, 60 ));
            this.board.AddTile(new  StreetTile("Apple",952, 60, 260, 22, StreetTileColor.Yellow));
            this.board.AddTile(new  StreetTile("Apple", 1009,60,280, 22, StreetTileColor.Yellow));
            this.board.AddTile(new  TaxTile("Water Works", 1066,60, 150));
            this.board.AddTile(new  StreetTile("Apple", 1123, 60, 300, 22, StreetTileColor.Yellow));
            this.board.AddTile(new  GoToJailTile(null, 1180, 60));
            this.board.AddTile(new  StreetTile("Google", 1180, 117, 310, 26, StreetTileColor.Green));
            this.board.AddTile(new  StreetTile("Google", 1180,174,  320, 26, StreetTileColor.Green));
            this.board.AddTile(new  CommunityTile(null, 1180, 231));                                     
            this.board.AddTile(new  StreetTile("Google", 1180,288,  330, 28, StreetTileColor.Green));
            this.board.AddTile(new  StationTile("MTEL", 1180, 345));
            this.board.AddTile(new  ChanceTile(null, 1180, 402));
            this.board.AddTile(new  StreetTile("Netherrealms Studios", 1180, 459, 350, 35, StreetTileColor.DarkBlue));
            this.board.AddTile(new  TaxTile("Buy more RAM", 1180, 516, 100));
            this.board.AddTile(new  StreetTile("Netherrealms Studios", 1180, 573, 400, 50, StreetTileColor.DarkBlue));
        }

        private Queue<ChanceCard> LoadChanceCards()
        {
            var cardsArr = new[]
                {
                 new ChanceCard("Destributed Dental System Attack - you lose $150", CardType.Lose, 150),
                 new ChanceCard("Ouch - Heartbleed - you lose $100", CardType.Lose, 100),
                 new ChanceCard("You used float insted of decimal - you lose $50", CardType.Lose, 50),
                 new ChanceCard("Your Visual Studio license expired - you lose $75", CardType.Lose, 75),
                 new ChanceCard("Blue Screen of Death!!! - you lose $20", CardType.Lose, 20),
                 new ChanceCard("A flush of inspiration - your code compiled without any errors! - you win $100", CardType.Win, 100),
                 new ChanceCard("You fixed a nasty bug - you win $50", CardType.Win, 50),
                 new ChanceCard("You received a Telerik Academy Ninja Certificate - you win $150", CardType.Win, 150),
                 new ChanceCard("Internet Explorer has extincted! - you win $75", CardType.Win, 75),
                 new ChanceCard("Intenet boost! - you win $20", CardType.Win, 20),
                };

            return CardHelpers.ShuffleCards(cardsArr);
        }

        private Queue<CommunityCard> LoadCommunityCards()
        {
            var cardsArr = new[]
               {
                new CommunityCard("Your HDD burnt - you lose $150", CardType.Lose, 150),
                new CommunityCard("Your RAM burnt - you lose $100", CardType.Lose, 100),
                new CommunityCard("You get a raise - you win $150", CardType.Win, 150),
                new CommunityCard("You receive 2GB RAM - you win $100", CardType.Win, 100),
                new CommunityCard("Your laptop computer crashed - you lose $50", CardType.Lose, 50),
                new CommunityCard("You spill coffe on your keyboard - you lose $20", CardType.Lose, 20),
                new CommunityCard("Your dog ate you laptop computer recharger - you lose $75", CardType.Lose, 75),
                new CommunityCard("You receive a new battery for your laptop computer - you win $75", CardType.Win, 75),
                new CommunityCard("A gift! - new smartphone for you - you win $50", CardType.Win, 50),
                new CommunityCard("You have a birthday! - you win $20", CardType.Win, 20),
               };

            return CardHelpers.ShuffleCards(cardsArr);
        }
    }
}
