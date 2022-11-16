namespace Cafe.Web.Models.WarehouseViewModels
{
    public class SortWarehouseViewModel
    {
        public WarehouseSortState WeightState { get; set; }
        public WarehouseSortState CostState { get; set; }
        public WarehouseSortState ProviderState { get; set; }
        public WarehouseSortState IngridientState { get; set; }
        public WarehouseSortState ReleaseDateState { get; set; }
        public WarehouseSortState StorageLifeState { get; set; }
        public WarehouseSortState Current { get; set; }

        public SortWarehouseViewModel(WarehouseSortState orderState)
        {
            WeightState = orderState == WarehouseSortState.WeightAsc ? WarehouseSortState.WeightDesc : WarehouseSortState.WeightAsc;
            CostState = orderState == WarehouseSortState.CostAsc ? WarehouseSortState.CostDesc : WarehouseSortState.CostAsc;
            ProviderState = orderState == WarehouseSortState.ProviderAsc ? WarehouseSortState.ProviderDesc : WarehouseSortState.ProviderAsc;
            IngridientState = orderState == WarehouseSortState.IngridientAsc ? WarehouseSortState.IngridientDesc : WarehouseSortState.IngridientAsc;
            ReleaseDateState = orderState == WarehouseSortState.ReleaseDateAsc ? WarehouseSortState.ReleaseDateDesc : WarehouseSortState.ReleaseDateAsc;
            StorageLifeState = orderState == WarehouseSortState.StorageLifeAsc ? WarehouseSortState.StorageLifeDesc : WarehouseSortState.StorageLifeAsc;
            Current = orderState;
        }

    }
}
