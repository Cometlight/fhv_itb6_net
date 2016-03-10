﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class OrderItem : IID
    {
        public int? Id { get; set; }
        public int? ProductId { get; set; }
        public int? ProductCount { get; set; }
        public int? Sequence { get; set; }
        public int? OrderId { get; set; }
        public decimal? Price { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, ProductId: {ProductId}, ProductCount: {ProductCount}, Sequence: {Sequence}, OrderId: {OrderId}, Price: {Price}";
        }
    }
}
