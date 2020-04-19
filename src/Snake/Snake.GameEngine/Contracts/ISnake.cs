namespace Snake.GameEngine.Contracts
{
    using Enums;

    public interface ISnake
    {
        bool IsAlive { get; }

        void Move(Direction direction);

        void Reset();
    }
}
