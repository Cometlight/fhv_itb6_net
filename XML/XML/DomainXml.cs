using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML
{
    // TODO improve comments
    public abstract class DomainXml<TDomain, TXml> where TDomain : class, new()
    {
        protected TXml managedXmlObject;    // needs to be set

        public void Convert(TDomain source)
        {
            if (managedXmlObject == null)
                throw new NullReferenceException(nameof(managedXmlObject) + " not set.");

            copyAllProperties(source, ref managedXmlObject);
        }

        public TDomain Reconvert()
        {
            if (managedXmlObject == null)
                throw new NullReferenceException(nameof(managedXmlObject) + " not set.");

            TDomain target = new TDomain();
            copyAllProperties(managedXmlObject, ref target);
            return target;
        }

        private void copyAllProperties<TSource, TTarget>(TSource source, ref TTarget target)
        {
            foreach (var property in typeof(TSource).GetProperties())
            {
                var sourcePropertyGetter = property.GetGetMethod();
                var targetPropertySetter = typeof(TTarget).GetProperty(property.Name).GetSetMethod();
                var valueToSet = sourcePropertyGetter.Invoke(source, null);
                targetPropertySetter.Invoke(target, new[] { valueToSet });
            }
        }
    }
}
