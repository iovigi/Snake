namespace Snake.GameEngine
{
    using Enums;
    using Contracts;

    public partial class Snake : ISnake
    {
        private readonly IMap map;

        private Tale root;

        public Snake(IMap map)
        {
            this.IsAlive = true;
            this.map = map;
        }

        public bool IsAlive { get; private set; }

        public void Move(Direction direction)
        {
            var y = root.Y;
            var x = root.X;

            switch (direction)
            {
                case Direction.Top:
                    y = y == 0 ? this.map.Height : y - 1;
                    break;
                case Direction.Bottom:
                    y = y == this.map.Height ? 0 : y + 1;
                    break;
                case Direction.Left:
                    x = x == 0 ? this.map.Width : x - 1;
                    break;
                case Direction.Right:
                    x = x == this.map.Width ? 0 : x + 1;
                    break;
            }

            if(map[y,x] == FieldType.Food)
            {
                map[y, x] = FieldType.SnakeTale;

                var oldRoot = root;
                root = new Tale(map, x, y);
                root.Prev = oldRoot;
            }
            else
            {
                IsAlive = root.Move(x, y);
            }
        }

        public void Reset()
        {
            IsAlive = true;
            root?.Remove();
            var startPoint = map.GetMiddle();

            root = new Tale(map, startPoint.X, startPoint.Y);
        }
    }
}
