using System;

namespace Domain
{
    public class Order : IId
    {
        public int? Id { get; set; }
        public DateTime Date { get; set; }
        public int? CustomerId { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Date: {Date}, CustomerId: {CustomerId}";
        }
    }
}
