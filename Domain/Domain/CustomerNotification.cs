using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CustomerNotification
    {
        private string message;
        private Customer recipient;
        private NotificationState state;

        public string Message { get; set; }
        public Customer Recipient { get; set; }
        public NotificationState State { get; set; }
    }
}
