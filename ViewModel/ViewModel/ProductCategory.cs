using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ProductCategory : ViewModelBase
    {
        private Domain.ProductCategory model;

        public Domain.ProductCategory Model
        {
            get { return model; }
            set { model = value; }
        }

        public ProductCategory() { }

        public ProductCategory(Domain.ProductCategory model)
        {
            this.model = model;
        }

        public int? Id
        {
            get { return model?.Id; }
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
            get { return model?.Name; }
            set
            {
                model.Name = value;
                string propertyName = MethodBase.GetCurrentMethod().Name.Substring(4);
                RaisePropertyChanged(propertyName);
            }
        }
    }
}
