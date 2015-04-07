namespace MonopolyGame.Model.Classes.Cards.Contracts
{
    using System.Collections.Generic;

    using Model.Classes.Actions;
    using Model.Classes.Actions.Contracts;
    using Model.Common.Validators;
    using Model.Enumerations;

    public abstract class Card : IChoosableAction
    {
        private ICollection<IAction> actions;

        public Card(string description, CardType type, int money)
        {
            this.Description = description;
            this.Type = type;
            this.Money = money;
            this.actions = new List<IAction>();
            if (this.Type == CardType.Win) 
            {
                this.AddAction(new WinAction());
            }
            else if (this.Type == CardType.Lose) 
            {
                this.AddAction(new LoseAction());
            }
        }

        public int Money { get; set; }

        public string Description { get; private set; }

        public CardType Type { get; private set; }

        public ICollection<IAction> Actions
        {
            get
            {
                return new List<IAction>(this.actions);
            }
        }

        public void AddAction(IAction action)
        {
            ObjectValidator.NullObjectValidation(action, "Action instance shouldn`t be null");
            this.actions.Add(action);
        }

        public override string ToString()
        {
            return this.Description;
        }

        //static Random r = new Random();

        //internal static Queue<T> Shuffle<T>(T[] cards)
        //{
        //    for (int n = cards.Length - 1; n > 0; --n)
        //    {
        //        int k = r.Next(n + 1);
        //        var temp = cards[n];
        //        cards[n] = cards[k];
        //        cards[k] = temp;
        //    }

        //    var result = new Queue<T>();

        //    foreach (var item in cards)
        //    {
        //        // Console.WriteLine(item);
        //        result.Enqueue(item);
        //    }

        //    return result;
        //}
    }
}
