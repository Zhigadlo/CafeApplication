namespace Cafe.Domain
{
    public class Dish
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public double Cost { get; set; }

        public int CookingTime { get; set; }

    }
}
