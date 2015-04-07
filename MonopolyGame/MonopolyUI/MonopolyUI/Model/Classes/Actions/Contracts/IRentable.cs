namespace MonopolyGame.Model.Classes.Actions.Contracts
{
    using Model.Classes.Tiles.Contracts;
    
    public interface IRentable
    {
        void PayRent(Player player, PropertyTile property);
    }
}
