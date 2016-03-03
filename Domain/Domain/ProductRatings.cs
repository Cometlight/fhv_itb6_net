using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ProductRatings
    {
        private ICollection<int> ratings;

        public ICollection<int> Ratings { get; set; }

        public double GetAverageRating()
        {
            if (ratings == null || !ratings.Any())
            {    // TODO Check if null check necessary...
                return 0d;
            }
            return ratings.Average();
        }
    }
}
