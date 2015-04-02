namespace MonopolyGame.Model.Classes.Actions.Contracts
{
    using Model.Classes.Tiles.Contracts;

    public interface ISellable
    {
        void Sell(Player player, PropertyTile property);
    }
}
