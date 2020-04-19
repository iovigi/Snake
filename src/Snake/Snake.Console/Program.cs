namespace Snake.Console
{
    using GameEngine;
    using GameEngine.Contracts;
    using GameEngine.Configuration;
    using GameEngine.Enums;

    using Console = System.Console;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.CursorVisible = false;
            var map = new Map(Console.WindowHeight, Console.WindowWidth);
            var snake = new Snake(map);
            var foodProcessor = new FoodProcessor(map);

            var gameEngine = new GameEngine(snake, foodProcessor, new GameConfiguration() { RefreshSeconds = 50 });
            gameEngine.OnRefresh = () => PrintMap(map);
            gameEngine.StartNewGame();

            while (!gameEngine.IsGameOver)
            {
                switch (Console.ReadKey().Key)
                {
                    case System.ConsoleKey.UpArrow:
                        gameEngine.Move(Direction.Top);
                        break;
                    case System.ConsoleKey.DownArrow:
                        gameEngine.Move(Direction.Bottom);
                        break;
                    case System.ConsoleKey.LeftArrow:
                        gameEngine.Move(Direction.Left);
                        break;
                    case System.ConsoleKey.RightArrow:
                        gameEngine.Move(Direction.Right);
                        break;
                }
            }
        }

        private static object syncroot = new object();

        public static void PrintMap(IMap map)
        {
            lock (syncroot)
            {
                Console.Clear();

                for (int i = 0; i < map.Height; i++)
                {
                    for (int j = 0; j < map.Width; j++)
                    {
                        switch (map[i, j])
                        {
                            case FieldType.Food:
                                Console.SetCursorPosition(j, i);
                                Console.Write('*');
                                break;
                            case FieldType.SnakeTale:
                                Console.SetCursorPosition(j, i);
                                Console.Write('X');
                                break;
                        }
                    }
                }
            }
        }
    }
}
