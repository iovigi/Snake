namespace Snake.GameEngine.Contracts
{
    using Enums;

    public interface IMap 
    {
        int Height { get;  }
        int Width { get; }

        FieldType this[int row, int column] { get; set; }

        Point GetRandomFreeField();

        Point[] GetFoodPoints();

        Point GetMiddle();

        void Reset();
    }
}
