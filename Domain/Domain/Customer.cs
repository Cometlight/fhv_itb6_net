namespace Domain
{
    public class Customer : IId
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? AddressId { get; set; }
        public int? UserId { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, FirstName: {FirstName}, LastName: {LastName}, AddressId: {AddressId}, UserId: {UserId}";
        }
    }
}
