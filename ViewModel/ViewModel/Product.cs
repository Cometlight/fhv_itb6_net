using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class Product : ViewModelBase
    {
        private readonly Domain.Product model;

        public Product() { }

        public Product(Domain.Product model)
        {
            this.model = model;
        }

        public int? Id
        {
            get { return model.Id; }
            set
            {
                model.Id = value;
                // The name is in form set_Id, hence the front part is removed with Substring(4)
                string propertyName = MethodBase.GetCurrentMethod().Name.Substring(4);
                RaisePropertyChanged(propertyName);
            }
        }

        public string Name
        {
            get { return model.Name; }
            set
            {
                model.Name = value;
                string propertyName = MethodBase.GetCurrentMethod().Name.Substring(4);
                RaisePropertyChanged(propertyName);
            }
        }

        public string Description
        {
            get { return model.Description; }
            set
            {
                model.Description = value;
                string propertyName = MethodBase.GetCurrentMethod().Name.Substring(4);
                RaisePropertyChanged(propertyName);
            }
        }

        public string Image
        {
            get { return model.Image; }
            set
            {
                model.Image = value;
                string propertyName = MethodBase.GetCurrentMethod().Name.Substring(4);
                RaisePropertyChanged(propertyName);
            }
        }

        public string Number
        {
            get { return model.Number; }
            set
            {
                model.Number = value;
                string propertyName = MethodBase.GetCurrentMethod().Name.Substring(4);
                RaisePropertyChanged(propertyName);
            }
        }

        public int? CategoryId
        {
            get { return model.CategoryId; }
            set
            {
                model.CategoryId = value;
                string propertyName = MethodBase.GetCurrentMethod().Name.Substring(4);
                RaisePropertyChanged(propertyName);
            }
        }

        public int? SupplierId
        {
            get { return model.SupplierId; }
            set
            {
                model.SupplierId = value;
                string propertyName = MethodBase.GetCurrentMethod().Name.Substring(4);
                RaisePropertyChanged(propertyName);
            }
        }

        public decimal? Price
        {
            get { return model.Price; }
            set
            {
                model.Price = value;
                string propertyName = MethodBase.GetCurrentMethod().Name.Substring(4);
                RaisePropertyChanged(propertyName);
            }
        }
    }
}
