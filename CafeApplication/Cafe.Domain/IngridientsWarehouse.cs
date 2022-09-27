namespace Cafe.Domain
{
    public class IngridientsWarehouse
    {
        public int Id { get; set; }
        public int IngridientId { get; set; }
        public int? Weight { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime StorageLife { get; set; }
        public double Cost { get; set; }
        public int ProviderId { get; set; }
        public virtual Ingridient Ingridient { get; set; } = null!;
        public virtual Provider Provider { get; set; } = null!;
    }
}
