namespace MonopolyGame.Model.Classes
{
    public class ChanceCard : Card
    {
        public ChanceCard(string description, int money)
            : base(description, money)
        {
        }

        public override void Action(Player player)
        {
            player.AddMoney(base.Money);
        }
    }
}
