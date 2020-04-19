namespace Snake.GameEngine
{
    using Contracts;

    public class FoodProcessor : IFoodProcessor
    {
        private readonly IMap map;

        public FoodProcessor(IMap map)
        {
            this.map = map;
        }

        public void Process()
        {
            var foodCoordinates = map.GetFoodPoints();

            if(foodCoordinates.Length > 0)
            {
                return;
            }

            var freePoint = map.GetRandomFreeField();
            map[freePoint.Y, freePoint.X] = Enums.FieldType.Food;
        }

        public void Reset()
        {
            var foodCoordinates = map.GetFoodPoints();

            foreach(var coordinate in foodCoordinates)
            {
                map[coordinate.Y, coordinate.X] = Enums.FieldType.Free;
            }
        }
    }
}
