namespace MonopolyGame.Model.Engine.Contracts
{
    interface IEngine
    {
        void Initialize();
        void Start();
        bool CheckWinningCondition();
    }
}
