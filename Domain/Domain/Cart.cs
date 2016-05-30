namespace Domain
{
    public class Cart : IId
    {
        public int? Id { get; set; }
        public int? CustomerId { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, CustomerId: {CustomerId}";
        }
    }
}
