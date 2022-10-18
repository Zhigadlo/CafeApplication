namespace Cafe.Domain
{
    public class Ingridient
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<IngridientsDish> IngridientsDishes { get; } = new List<IngridientsDish>();
        public virtual ICollection<IngridientsWarehouse> IngridientsWarehouses { get; } = new List<IngridientsWarehouse>();

    }
}
