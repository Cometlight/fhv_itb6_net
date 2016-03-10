﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Order : IID
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
