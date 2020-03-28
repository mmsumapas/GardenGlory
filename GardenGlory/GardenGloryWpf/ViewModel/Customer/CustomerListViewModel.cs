using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using GardenGlory.Context;
using ServiceLayer;

namespace GardenGloryWpf.ViewModel.Customer
{
    public class CustomerListViewModel
    {
        private CustomerViewModel _selectedCustomer;
        private OwnerService _ownerService;
        private string _searchText;

        public CustomerListViewModel(OwnerService ownerService)
        {
            _ownerService = ownerService;

            CustomerList= new ObservableCollection<CustomerViewModel>(_ownerService.GetOwners().Select(c =>
                new CustomerViewModel(c, new ServiceService(new GardenGloryContext()))));
          
        }

        public void SearchCustomer(string searchString)
        {
            CustomerList.Clear();
            var owners = _ownerService.GetOwners().Where(c => c.OwnerName.Contains(searchString) ||
                                                              c.OwnerTypeId.Contains(searchString));
            foreach (var owner in owners)
            {
                var ownerModel = new CustomerViewModel(owner, new ServiceService(new GardenGloryContext()));
                CustomerList.Add(ownerModel);
            }
        
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                SearchCustomer(_searchText);
            }
        }

        public ObservableCollection<CustomerViewModel> CustomerList { get; }

        public CustomerViewModel SelectedCustomer { get; set; }
        
    }
}
