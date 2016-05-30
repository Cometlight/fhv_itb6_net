namespace Domain
{
    public class CartEntry : IId
    {
        public int? Id { get; set; }
        public int? ProductId { get; set; }
        public int? ProductCount { get; set; }
        public int? Sequence { get; set; }
        public int? CartId { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, ProductId: {ProductId}, ProductCount: {ProductCount}, Sequence: {Sequence}, CartId: {CartId}";
        }
    }
}
