using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CartEntry : IID
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
