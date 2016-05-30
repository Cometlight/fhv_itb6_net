using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using XML;

namespace Service
{
    public class XmlExportImport
    {
        public void Export<TDomainType, TXmlType>(string fileName, List<TDomainType> domainObjects) where TXmlType : DomainXml<TDomainType, TXmlType> where TDomainType : class, new()
        {
            // Convert from List<TDomainType> to List<TXmlType>
            List<TXmlType> xmlObjects = new List<TXmlType>(domainObjects.Count);
            foreach (TDomainType domainObject in domainObjects)
            {
                TXmlType xmlObject = (TXmlType)Activator.CreateInstance(typeof(TXmlType), domainObject);
                xmlObjects.Add(xmlObject);
            }

            // Serialize List<TmlType> to XML file
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<TXmlType>));
            using (TextWriter textWriter = new StreamWriter(fileName))
            {
                xmlSerializer.Serialize(textWriter, xmlObjects);
            }
        }

        public List<TDomainType> Import<TDomainType, TXmlType>(string fileName) where TXmlType : DomainXml<TDomainType, TXmlType> where TDomainType : class, new()
        {
            List<TXmlType> xmlObjects;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<TXmlType>));
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                xmlObjects = (List<TXmlType>) xmlSerializer.Deserialize(fileStream);
            }
            List<TDomainType> domainObjects = new List<TDomainType>(xmlObjects.Count);
            foreach (TXmlType xmlObject in xmlObjects)
            {
                TDomainType domainObject = xmlObject.Reconvert();
                domainObjects.Add(domainObject);
            }
            return domainObjects;
        }
    }
}
