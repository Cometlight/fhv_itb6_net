using System.Reflection;
using System.Windows.Input;
using ViewModel.Commands;

namespace ViewModel
{
    public class Product : ViewModelBase
    {
        private bool unsavedChanges;
        private Domain.Product model;

        public Domain.Product Model
        {
            get { return model; }
            set { model = value; }
        }

        public bool UnsavedChanges
        {
            get { return unsavedChanges; }
            set
            {
                unsavedChanges = value;
                UnsavedChangesChanged?.Invoke(this, value);
            }
        }

        public event Delegates.UnsavedChangesChangedEventHandler UnsavedChangesChanged;

        public ICommand SaveProductToDb { get; private set; }

        public Product() { }

        public Product(Domain.Product model)
        {
            this.model = model;
            SaveProductToDb = new SaveProductToDb(this);
        }

        public void AllChangesSaved()
        {
            UnsavedChanges = false;
        }

        public void AllChangesReverted()
        {
            UnsavedChanges = false;
        }

        public int? Id
        {
            get { return model?.Id; }
            set
            {
                model.Id = value;
                UnsavedChanges = true;
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
                UnsavedChanges = true;
                string propertyName = MethodBase.GetCurrentMethod().Name.Substring(4);
                RaisePropertyChanged(propertyName);
            }
        }

        public string Description
        {
            get { return model?.Description; }
            set
            {
                model.Description = value;
                UnsavedChanges = true;
                string propertyName = MethodBase.GetCurrentMethod().Name.Substring(4);
                RaisePropertyChanged(propertyName);
            }
        }

        public string Image
        {
            get { return model?.Image; }
            set
            {
                model.Image = value;
                UnsavedChanges = true;
                string propertyName = MethodBase.GetCurrentMethod().Name.Substring(4);
                RaisePropertyChanged(propertyName);
            }
        }

        public string Number
        {
            get { return model?.Number; }
            set
            {
                model.Number = value;
                UnsavedChanges = true;
                string propertyName = MethodBase.GetCurrentMethod().Name.Substring(4);
                RaisePropertyChanged(propertyName);
            }
        }

        public int? CategoryId
        {
            get { return model?.CategoryId; }
            set
            {
                model.CategoryId = value;
                UnsavedChanges = true;
                string propertyName = MethodBase.GetCurrentMethod().Name.Substring(4);
                RaisePropertyChanged(propertyName);
            }
        }

        public int? SupplierId
        {
            get { return model?.SupplierId; }
            set
            {
                model.SupplierId = value;
                UnsavedChanges = true;
                string propertyName = MethodBase.GetCurrentMethod().Name.Substring(4);
                RaisePropertyChanged(propertyName);
            }
        }

        public decimal? Price
        {
            get { return model?.Price; }
            set
            {
                model.Price = value;
                UnsavedChanges = true;
                string propertyName = MethodBase.GetCurrentMethod().Name.Substring(4);
                RaisePropertyChanged(propertyName);
            }
        }
    }
}
