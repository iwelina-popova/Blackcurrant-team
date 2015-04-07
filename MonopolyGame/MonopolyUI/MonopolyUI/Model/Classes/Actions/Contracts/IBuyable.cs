namespace MonopolyGame.Model.Classes.Actions.Contracts
{
    using Model.Classes.Tiles.Contracts;

    public interface IBuyable
    {
        void Buy(Player player, PropertyTile property);
    }
}
