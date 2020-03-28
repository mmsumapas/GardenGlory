using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using GardenGlory.Context;
using GardenGlory.DefaultValueGenerator;
using GardenGlory.EfClasses;
using GardenGloryWpf.ViewModel.Customer;
using ServiceLayer;

namespace GardenGloryWpf.ViewModel.Property
{
    public class AddPropertyDescriptionViewModel
    {
        public PropertyViewModel AssociPropertyViewModel { get; set; }
        private PropertyDescriptionService _propertyDescriptionService;

        public AddPropertyDescriptionViewModel(PropertyViewModel propertyViewModel,
            PropertyDescriptionService propertyDescriptionService)
        {
            AssociPropertyViewModel = propertyViewModel;
            _propertyDescriptionService = propertyDescriptionService;
        }

        public string Add()
        {
            if (Description == null)
            {
                return "Error";
            }
            var propertyDescription = new PropertyDescription();
           
            propertyDescription.PropertyDescriptionId = new PropertyDescriptionDefaultValueGenerator(new GardenGloryContext()).PropertyDescriptionPrimaryKeyGenerator();
            propertyDescription.PropertyId = AssociPropertyViewModel.PropertyId;
            propertyDescription.Description = Description;
            propertyDescription.IsDeleted = false;
            _propertyDescriptionService.AddPropertyDescription(propertyDescription);
            AssociPropertyViewModel.PropertyDescriptions.Add(propertyDescription);
            return "New Property Description is added successfully!";
        }
        public string Description { get; set; }

    }

}
