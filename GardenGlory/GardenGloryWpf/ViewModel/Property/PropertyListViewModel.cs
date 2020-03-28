using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Principal;
using System.Text;
using GardenGlory.Context;
using GardenGloryWpf.ViewModel.Customer;
using ServiceLayer;

namespace GardenGloryWpf.ViewModel.Property
{
    public class PropertyListViewModel
    {
        private PropertyService _propertyService;
        private string _searchText;

        public PropertyListViewModel(PropertyService propertyService)
        {
            _propertyService = propertyService;

            PropertyList = new ObservableCollection<PropertyViewModel>(_propertyService.GetProperties().Select(c=> 
                new PropertyViewModel(c, new PropertyDescriptionService(new GardenGloryContext()))));

        }

        public void SearchProperty(string searchString)
        {
            PropertyList.Clear();

            var properties = _propertyService.GetProperties().Where(c => c.PropertyName.Contains(searchString) ||
                                                                         c.PropertyId.Contains(searchString) ||
                                                                         c.OwnerLink.OwnerName.Contains(SearchText));
            foreach (var property in properties)
            {
                var propertyModel = new PropertyViewModel(property, new PropertyDescriptionService(new GardenGloryContext()));
                PropertyList.Add(propertyModel);
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                SearchProperty(_searchText);
            }
        }

        public ObservableCollection<PropertyViewModel> PropertyList { get; }
        public PropertyViewModel SelectedProperty { get; set; }
    }
}
