using System;
using System.Collections.Generic;
using System.Text;
using GardenGlory.Context;
using GardenGloryWpf.ViewModel.Customer;
using ServiceLayer;

namespace GardenGloryWpf.ViewModel.Property
{
    public class EditPropertyDescriptionViewModel
    {
        public PropertyViewModel AssociatedPropertyViewModel { get; set; }
        private PropertyDescriptionService _propertyDescriptionService;
        private int _selectedIndex { get;}

        public EditPropertyDescriptionViewModel(PropertyViewModel propertyViewModel, PropertyDescriptionService propertyDescriptionService, int selectedIndex)
        {
            AssociatedPropertyViewModel = propertyViewModel;
            _propertyDescriptionService = propertyDescriptionService;
            _selectedIndex = selectedIndex;

        }
        public void Edit()
        {
            var editPropertyDescription = AssociatedPropertyViewModel.PropertyDescriptions[_selectedIndex];
            _propertyDescriptionService.UpdatePropertyDescription(editPropertyDescription.PropertyDescriptionId, Description);
            var edited =
                _propertyDescriptionService.GetPropertyDescription(editPropertyDescription.PropertyDescriptionId);
            AssociatedPropertyViewModel.PropertyDescriptions.Remove(editPropertyDescription);
            AssociatedPropertyViewModel.PropertyDescriptions.Insert(_selectedIndex, edited);

        }
        public string Description { get; set; }
    }
}
