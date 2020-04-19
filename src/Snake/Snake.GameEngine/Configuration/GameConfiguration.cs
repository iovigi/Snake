namespace Snake.GameEngine.Configuration
{
    using global::Snake.GameEngine.Configuration.Contracts;

    public class GameConfiguration : IGameConfiguration
    {
        public int RefreshSeconds { get; set; }
    }
}
