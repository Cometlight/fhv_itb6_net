namespace Domain
{
    public class Stock : IId
    {
        public int? Id { get; set; }
        public int? ProductId { get; set; }
        public int? ProductCount { get; set; }
        public int? WarehouseId { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, ProductId: {ProductId}, Count: {ProductCount}, WarehouseId: {WarehouseId}";
        }
    }
}
