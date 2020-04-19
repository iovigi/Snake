namespace Snake.GameEngine
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using Contracts;
    using Enums;
    using global::Snake.GameEngine.Configuration.Contracts;

    public class GameEngine
    {
        private Direction direction;
        private Task task;
        private volatile bool isRunning; 

        public readonly ISnake snake;
        public readonly IFoodProcessor foodProcessor;
        public readonly IGameConfiguration gameConfiguration;

        public GameEngine(ISnake snake, IFoodProcessor foodProcessor, IGameConfiguration gameConfiguration)
        {
            this.snake = snake;
            this.foodProcessor = foodProcessor;
            this.gameConfiguration = gameConfiguration;
        }

        public bool IsGameOver { get { return !snake.IsAlive; } }
        public Action OnRefresh { get; set; }

        public void StartNewGame()
        {
            snake.Reset();
            foodProcessor.Reset();

            isRunning = true;

            task = Task.Run(GameLoop);
        }

        public void StopGame()
        {
            isRunning = false;
            task?.Wait();
        }

        private void GameLoop()
        {
            while(isRunning)
            {
                foodProcessor.Process();
                snake.Move(direction);

                if(!snake.IsAlive)
                {
                    break;
                }

                OnRefresh?.Invoke();
                Task.Delay(gameConfiguration.RefreshSeconds).Wait();
            }
        }

        public void Move(Direction direction)
        {
            this.direction = direction;
        }
    }
}
