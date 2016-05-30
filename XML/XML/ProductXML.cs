using System.Xml.Serialization;
using Domain;

namespace XML
{
    public class ProductXml : DomainXml<Product, ProductXml>
    {
        [XmlElement]
        public int? Id { get; set; }

        [XmlElement]
        public string Name { get; set; }

        [XmlElement]
        public string Description { get; set; }

        [XmlElement]
        public string Image { get; set; }

        [XmlElement]
        public string Number { get; set; }

        [XmlElement]
        public int? CategoryId { get; set; }

        [XmlElement]
        public int? SupplierId { get; set; }

        [XmlElement]
        public decimal? Price { get; set; }

        public ProductXml()
        {
            managedXmlObject = this;
        }

        public ProductXml(Product product) : this()
        {
            Convert(product);
        }
    }
}
