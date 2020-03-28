using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using GardenGlory.EfClasses;
using ServiceLayer;

namespace GardenGloryWpf.CmbViewModel
{
    public class PropertyCmbViewModel
    {
        private string _searchPropertyText;
        private PropertyService _propertyService;

        public PropertyCmbViewModel(PropertyService propertyService)
        {
            _propertyService = propertyService;
            Properties = new ObservableCollection<Property>(_propertyService.GetProperties());
        }

        public string SearchPropertyText
        {
            get => _searchPropertyText;
            set
            {
                _searchPropertyText = value;
                if (_searchPropertyText == null)
                {
                    _searchPropertyText = "";
                    SearchProperty(_searchPropertyText);
                }
                else
                {
                    SearchProperty(_searchPropertyText);
                }
            }
        }
        public void SearchProperty (string searchText)
        {
            var properties = _propertyService.GetProperties().Where(c => c.PropertyName.Contains(searchText));
            Properties.Clear();
            foreach (var property in properties)
            {
                Properties.Add(property);
            }
        }
        public ObservableCollection<Property> Properties { get; set; }
        public Property SelectedProperty { get; set; }
    }
}
