namespace Snake.GameEngine
{
    using Contracts;

    public partial class Snake
    {
        private class Tale
        {
            private readonly IMap map;

            public Tale(IMap map, int x, int y)
            {
                this.map = map;
                X = x;
                Y = y;
            }

            public int X { get; private set; }
            public int Y { get; private set; }

            public Tale Prev { get; set; }

            public bool Move(int x, int y)
            {
                map[Y, X] = Enums.FieldType.Free;

                if (Prev != null)
                {
                    if (!Prev.Move(X, Y))
                    {
                        return false;
                    }
                }

                if (map[y ,x] == Enums.FieldType.SnakeTale)
                {
                    return false;
                }

                X = x;
                Y = y;
                map[Y, X] = Enums.FieldType.SnakeTale;

                return true;
            }

            public void Remove()
            {
                this.map[Y, X] = Enums.FieldType.Free;
                Prev?.Remove();
                Prev = null;
            }
        }
    }
}
