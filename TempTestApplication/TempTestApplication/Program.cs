using Database.Broker;
using Domain;
using Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using XML;

namespace TempTestApplication
{
    class Program
    {
        /*static void Main(string[] args)
        {
            DapperConfiguration.Initialize();
            string servername = Database.Properties.Settings.Default.servername[0];
            string database = Database.Properties.Settings.Default.database[0];
            string uid = Database.Properties.Settings.Default.usename[0];
            string pwd = Database.Properties.Settings.Default.password[0];
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
        }*/

        static void Main(string[] args)
        {
            Product product = new Product()
            {
                Id = 1,
                CategoryId = 2,
                Description = "desc",
                Image = "image",
                Name = "name",
                Number = "123",
                Price = 13.37m,
                SupplierId = 4
            };
            Product product2 = new Product()
            {
                Id = 2,
                CategoryId = 3,
                Description = "abc",
                Image = "abc",
                Name = "abc",
                Number = "321",
                Price = 42.37m,
                SupplierId = 5
            };
            ProductXml productXml = new ProductXml(product);
            ProductXml productXml2 = new ProductXml(product2);
            List<ProductXml> products = new List<ProductXml>()
            {
                productXml,
                productXml2
            };

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ProductXml>));
            TextWriter textWriter = new StreamWriter(@"C:\temp\test.xml");
            xmlSerializer.Serialize(textWriter, products);
            textWriter.Close();

            FileStream fileStream = new FileStream(@"C:\temp\test.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
            List<ProductXml> productsXmlLoaded = (List<ProductXml>) xmlSerializer.Deserialize(fileStream);
            fileStream.Close();
            foreach (var p in productsXmlLoaded)
            {
                Console.WriteLine(p.Reconvert());   
            }
        }
    }
}
