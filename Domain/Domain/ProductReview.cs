namespace Domain
{
    public class ProductReview : IId
    {
        public int? Id { get; set; }
        public int? ProductId { get; set; }
        public string Text { get; set; }
        public int? CustomerId { get; set; }
        public int? Points { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, ProductId: {ProductId}, Text: {Text}, CustomerId: {CustomerId}, Points: {Points}";
        }
    }
}
