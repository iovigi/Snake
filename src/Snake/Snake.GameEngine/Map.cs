namespace Snake.GameEngine
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Enums;

    public class Map : IMap
    {
        private readonly Random random = new Random();
        private FieldType[,] map;

        public Map(int height, int width)
        {
            Height = height;
            Width = width;

            map = new FieldType[height, width];
        }

        public FieldType this[int row, int column]
        {
            get
            {
                return map[row, column];
            }
            set
            {
                map[row, column] = value;
            }
        }

        public int Height { get; }

        public int Width { get; }

        public Point[] GetFoodPoints()
        {
            List<Point> points = new List<Point>();

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (map[i, j] == FieldType.Food)
                    {
                        points.Add(new Point(j, i));
                    }
                }
            }

            return points.ToArray();
        }

        public Point GetMiddle()
        {
            int middleX = Width % 2 == 0 ? Width / 2 : Width / 2 + 1;
            int middleY = Height % 2 == 0 ? Height / 2 : Height / 2 + 1;

            return new Point(middleX, middleY);
        }

        public Point GetRandomFreeField()
        {
            List<Point> points = new List<Point>();

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (map[i, j] == FieldType.Free)
                    {
                        points.Add(new Point(j, i));
                    }
                }
            }

            if(points.Count == 0)
            {
                return null;
            }

            return points[random.Next(0, points.Count)];
        }

        public void Reset()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    map[i, j] = FieldType.Free;
                }
            }
        }
    }
}
