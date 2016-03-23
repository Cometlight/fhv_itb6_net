using Database.Broker;
using Domain;
using Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempTestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            DapperConfiguration.Initialize();
            string servername = Database.Properties.Settings.Default.servername;
            string database = Database.Properties.Settings.Default.database;
            string uid = Database.Properties.Settings.Default.usename;
            string pwd = Database.Properties.Settings.Default.password;
            string connectionString = "Server=" + servername + ";Database=" + database + ";Uid=" + uid + ";Pwd=" + pwd + ";";
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                IBroker<Address> addressBroker = new Broker<Address>();
                Address address = addressBroker.Get(connection, 1);
                Console.WriteLine("Address: " + address);

                Address addressNew = new Address("Feldweg", "42", "1234", "Schwarzach", 2);
                Console.WriteLine("AddressNew: " + addressNew);
                addressBroker.Save(connection, ref addressNew);
                Console.WriteLine("AddressNew: " + addressNew);

                addressNew.HouseNumber = "1337";
                addressBroker.Save(connection, ref addressNew);
                if (addressNew.Id.HasValue)
                {
                    Address addressNewRead = addressBroker.Get(connection, addressNew.Id.Value);
                    Console.WriteLine("AddressNewChanged: " + addressNew);
                    Console.WriteLine("AddressNewChangedRead: " + addressNewRead);
                }

                IEnumerable<Address> addresses = addressBroker.GetAll(connection);
                Console.WriteLine($"{addresses.Count()} addresses are currently in the database.");

                addressBroker.Delete(connection, addressNew);
                Console.WriteLine("AddressNew deleted");

                addresses = addressBroker.GetAll(connection);
                Console.WriteLine($"{addresses.Count()} addresses are currently in the database.");

                Invoice invoice = new Invoice
                {
                    CustomerId = 1,
                    OrderId = 1,
                    Date = DateTime.Now
                };
                new Broker<Invoice>().Save(connection, ref invoice);
                Console.WriteLine("Invoice: " + invoice);
                if (invoice.Id.HasValue)
                {
                    Invoice invoiceRead = new Broker<Invoice>().Get(connection, invoice.Id.Value);
                    Console.WriteLine("InvoiceRead: " + invoiceRead);
                }
            }
        }
    }
}
