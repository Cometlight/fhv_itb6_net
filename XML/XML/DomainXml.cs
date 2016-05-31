using System;

namespace XML
{
    public abstract class DomainXml<TDomain, TXml> where TDomain : class, new()
    {
        protected TXml managedXmlObject;    // needs to be set, preferably in the constructor of the inheritor

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

        /// <summary>
        /// Copies all property values from source to target.
        /// Note that the source's and target's property names must be the same to use this method!
        /// </summary>
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
