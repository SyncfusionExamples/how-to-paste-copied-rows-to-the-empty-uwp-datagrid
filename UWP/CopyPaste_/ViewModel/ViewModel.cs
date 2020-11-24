using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CopyPaste_
{
    public class ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Product> product;

        public ObservableCollection<Product> Products
        {
            get { return product; }
            set
            {
                product = value;
                OnPropertyChanged("Products");
            }
        }
        public ViewModel()
        {

            product = new ObservableCollection<Product>();
            this.GetDetails();

        }

        private void GetDetails()
        {
            //Products.Add(new Product { ProductId = "P1", ProductName = "HardWare", SalesID = 1, CustomerName = "Jon", CustomerBranch = "C1", CustomerId = "Ac", ID = 1, ShipmentDetails = "Shiped", ShipmentPlace = "US" });
            //Products.Add(new Product { ProductId = "P2", ProductName = "software", SalesID = 2, CustomerName = "Petter", CustomerBranch = "C2", CustomerId = "Aac", ID = 2, ShipmentDetails = "Shiped", ShipmentPlace = "Uk" });
            //Products.Add(new Product { ProductId = "P3", ProductName = "software", SalesID = 3, CustomerName = "Rohan", CustomerBranch = "C3", CustomerId = "bc", ID = 3, ShipmentDetails = "NotShiped", ShipmentPlace = "US" });
            //Products.Add(new Product { ProductId = "P4", ProductName = "HardWare", SalesID = 4, CustomerName = "Kiran", CustomerBranch = "C4", CustomerId = "cc", ID = 4, ShipmentDetails = "Shiped", ShipmentPlace = "Uk" });
            //Products.Add(new Product { ProductId = "P5", ProductName = "software", SalesID = 5, CustomerName = "Sam", CustomerBranch = "C5", CustomerId = "as", ID = 5, ShipmentDetails = "NotShiped", ShipmentPlace = "Uk" });
            //Products.Add(new Product { ProductId = "P6", ProductName = "HardWare", SalesID = 6, CustomerName = "Pavan", CustomerBranch = "C6", CustomerId = "dc", ID = 6, ShipmentDetails = "Shiped", ShipmentPlace = "Uk" });
            //Products.Add(new Product { ProductId = "P7", ProductName = "software", SalesID = 7, CustomerName = "Jack", CustomerBranch = "C7", CustomerId = "vc", ID = 7, ShipmentDetails = "NotShiped", ShipmentPlace = "Uk" });
            //Products.Add(new Product { ProductId = "P8", ProductName = "HardWare", SalesID = 8, CustomerName = "Jill", CustomerBranch = "C8", CustomerId = "fc", ID = 8, ShipmentDetails = "Shiped", ShipmentPlace = "US" });
            //Products.Add(new Product { ProductId = "P9", ProductName = "software", SalesID = 9, CustomerName = "Kim", CustomerBranch = "C9", CustomerId = "gg", ID = 9, ShipmentDetails = "NotShiped", ShipmentPlace = "Uk" });
            //Products.Add(new Product { ProductId = "P10", ProductName = "HardWare", SalesID = 10, CustomerName = "Michael", CustomerBranch = "C10", CustomerId = "Af", ID = 10, ShipmentDetails = "Shiped", ShipmentPlace = "US" });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
    }
}
