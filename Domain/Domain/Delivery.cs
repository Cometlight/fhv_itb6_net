using System;

namespace Domain
{
    public class Delivery : IId
    {
        public int? Id { get; set; }
        public int? CustomerId { get; set; }
        public int? OrderId { get; set; }
        public DateTime Date { get; set; }
        public DateTime Expected { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, CustomerId: {CustomerId}, OrderId: {OrderId}, Date: {Date}, Expected: {Expected}";
        }
    }
}
