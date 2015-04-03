namespace MonopolyGame.Model.Engine
{
    using System;
    using System.Linq;
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
                    this.PlayerTurn(player, board.Tiles, firstDice.Roll(), secondDice.Roll());
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
            board.AddTile(new StartTile());
            board.AddTile(new StreetTile("Old Kent Road", 60, 2, StreetTileColor.Brown));
            board.AddTile(new CommunityTile());
            board.AddTile(new StreetTile("Whitechapel Road", 60, 4, StreetTileColor.Brown));
            board.AddTile(new TaxTile("Income Tax", 200));
            board.AddTile(new StationTile("Kings Cross Station"));
            board.AddTile(new StreetTile("The Angel Islington", 100, 6, StreetTileColor.LiteBlue));
            board.AddTile(new ChanceTile());
            board.AddTile(new StreetTile("Euston Road", 100, 6, StreetTileColor.LiteBlue));
            board.AddTile(new StreetTile("Pentoville Road", 8, 120, StreetTileColor.LiteBlue));
            board.AddTile(new JailTile());
            board.AddTile(new StreetTile("Pall Mall", 140, 10, StreetTileColor.Pink));
            board.AddTile(new TaxTile("Electric Company", 150));
            board.AddTile(new StreetTile("Whitehall", 140, 10, StreetTileColor.Pink));
            board.AddTile(new StreetTile("Northmurl`d Avenue", 160, 12, StreetTileColor.Pink));
            board.AddTile(new StationTile("Marylebone Station"));
            board.AddTile(new StreetTile("Bow Street", 180, 14, StreetTileColor.Orange));
            board.AddTile(new CommunityTile());
            board.AddTile(new StreetTile("Marlborough Street", 180, 14, StreetTileColor.Orange));
            board.AddTile(new StreetTile("Vine Street", 200, 16, StreetTileColor.Orange));
            board.AddTile(null);
            board.AddTile(new StreetTile("Strand", 220, 18, StreetTileColor.Red));
            board.AddTile(new ChanceTile());
            board.AddTile(new StreetTile("Fleet Street", 220, 18, StreetTileColor.Red));
            board.AddTile(new StreetTile("Trafalgar Square", 240, 20, StreetTileColor.Red));
            board.AddTile(new StationTile("Fenchurch st. Station"));
            board.AddTile(new StreetTile("Leicester Square", 260, 22, StreetTileColor.Yellow));
            board.AddTile(new StreetTile("Coventry Street", 260, 22, StreetTileColor.Yellow));
            board.AddTile(new TaxTile("Water Works", 150));
            board.AddTile(new StreetTile("Piccadilly", 280, 22, StreetTileColor.Yellow));
            board.AddTile(new GoToJailTile());
            board.AddTile(new StreetTile("Regent Street", 300, 26, StreetTileColor.Green));
            board.AddTile(new StreetTile("Oxford Street", 300, 26, StreetTileColor.Green));
            board.AddTile(new CommunityTile());
            board.AddTile(new StreetTile("Bond Street", 320, 28, StreetTileColor.Green));
            board.AddTile(new StationTile("Liverpool st. Station"));
            board.AddTile(new ChanceTile());
            board.AddTile(new StreetTile("Park Lane", 350, 35, StreetTileColor.DarkBlue));
            board.AddTile(new TaxTile("Super Tax", 100));
            board.AddTile(new StreetTile("Mayfair", 400, 50, StreetTileColor.DarkBlue));
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
    }
}
