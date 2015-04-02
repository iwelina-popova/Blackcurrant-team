namespace MonopolyGame.Model.Engine.Contracts
{
    public interface IEngine
    {
        void Initialize();

        void Start();

        bool CheckWinningCondition();
    }
}
