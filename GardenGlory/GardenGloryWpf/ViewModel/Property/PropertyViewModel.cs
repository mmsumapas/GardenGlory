using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using GardenGlory.Context;
using GardenGlory.DefaultValueGenerator;
using GardenGlory.EfClasses;
using GardenGloryWpf.Annotations;
using GardenGloryWpf.CmbViewModel;
using GardenGloryWpf.ViewModel.Property;
using ServiceLayer;
using ServiceLayer.MultipleServices;

namespace GardenGloryWpf.ViewModel.Customer
{
    public class PropertyViewModel : INotifyPropertyChanged
    {
        private string _propertyId;
        private string _ownerId;
        private string _propertyName;
        private string _street;
        private string _city;
        private string _zip;

        public PropertyViewModel()
        {

        }

        public string PropertyId
        {
            get { return _propertyId; }
            internal set
            {
                _propertyId = value;
                OnPropertyChanged(nameof(PropertyId));
            }
        }


        public string OwnerId
        {
            get { return _ownerId; }
            set
            {
                _ownerId = value;
                OnPropertyChanged(nameof(OwnerId));
            }
        }

        public string PropertyName
        {
            get { return _propertyName; }
            set
            {
                _propertyName = value;
                OnPropertyChanged(nameof(PropertyName));
            }
        }

        public string Street
        {
            get { return _street; }
            set
            {
                _street = value;
                OnPropertyChanged(nameof(Street));
            }
        }

        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                OnPropertyChanged(nameof(City));
            }
        }

        public string Zip
        {
            get { return _zip; }
            set
            {
                _zip = value;
                OnPropertyChanged(nameof(Zip));
            }
        }
        public string OwnerName { get; set; }
        public string Description { get; set; }
        private PropertyDescriptionService _propertyDescriptionService { get; }
        //public ObservableCollection<PropertyDetails> PropertyDetailsList { get; }
        public ObservableCollection<PropertyDescription> PropertyDescriptions { get; }
        public PropertyViewModel(GardenGlory.EfClasses.Property property, PropertyDescriptionService propertyDescriptionService)
        {
            PropertyId = property.PropertyId;
            OwnerId = property.OwnerId;
            PropertyName = property.PropertyName;
            Street = property.Street;
            City = property.City;
            Zip = property.Zip;
            OwnerName = property.OwnerLink.OwnerName;

            _propertyDescriptionService = propertyDescriptionService;
            PropertyDescriptions = new ObservableCollection<PropertyDescription>(_propertyDescriptionService.GetDescriptions(property.PropertyId));
         //   PropertyDetailsList = new ObservableCollection<PropertyDetails>(_propertyDescriptionService.GetDescriptions(PropertyId).Select(c =>
            //    new PropertyDetails(c)));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class EditPropertyViewModel
    {
        private PropertyService _propertyService;

        public EditPropertyViewModel(PropertyViewModel propertyModel, PropertyService propertyService)
        {
            AssociatedPropertyModel = propertyModel;
            _propertyService = propertyService;

            EditableFields(propertyModel);
        }
        private void EditableFields(PropertyViewModel propertyModel)
        {
            PropertyName = propertyModel.PropertyName;
            Street = propertyModel.Street;
            City = propertyModel.City;
            Zip = propertyModel.Zip;
        }
        public PropertyViewModel AssociatedPropertyModel { get; }
        public string PropertyName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }

        public string Edit()
        {
            if (PropertyName == "" || Street == "" || City == "" || Zip == "")
            {
                return "Error";
            }
            AssociatedPropertyModel.PropertyName = PropertyName;
            AssociatedPropertyModel.Street = Street;
            AssociatedPropertyModel.City = City;
            AssociatedPropertyModel.Zip = Zip;

            _propertyService.UpdateProperty(AssociatedPropertyModel.PropertyId,
                    AssociatedPropertyModel.PropertyName, AssociatedPropertyModel.Street, AssociatedPropertyModel.City, AssociatedPropertyModel.Zip);
            return "";

        }
    }
    public class AddPropertyViewModel
    {
        private readonly PropertyListViewModel _propertyListViewModel;
        private PropertyPropertyDescriptionService _propertyPropertyDescriptionService;

        public AddPropertyViewModel(PropertyListViewModel propertyListViewModel, PropertyPropertyDescriptionService propertyPropertyDescriptionService, OwnerCmbViewModel ownerCmbViewModel)
        {
            AssociatedPropertyModel = new PropertyViewModel();

            AssociatedOwnerCmbViewModel = ownerCmbViewModel;
            _propertyListViewModel = propertyListViewModel;
            _propertyPropertyDescriptionService = propertyPropertyDescriptionService;

        }
        public PropertyViewModel AssociatedPropertyModel { get; set; }
        public OwnerCmbViewModel AssociatedOwnerCmbViewModel { get; set; }

        public string Add()
        {
            if (AssociatedOwnerCmbViewModel.SelectedOwner.OwnerId == null|| AssociatedPropertyModel.PropertyName == null|| AssociatedPropertyModel.Street==null||
                AssociatedPropertyModel.City == null || AssociatedPropertyModel.Zip == null || AssociatedPropertyModel.Description == null)
            {
                return "Error";
            }
            var property = new GardenGlory.EfClasses.Property();

            var context = new GardenGloryContext();

            property.PropertyId = new PropertyDefaultValueGenerator(context).PropertyPrimaryKeyGenerator();
            property.ParentPropertyId = null;
            property.OwnerId = AssociatedOwnerCmbViewModel.SelectedOwner.OwnerId;
            property.PropertyName = AssociatedPropertyModel.PropertyName;
            property.Street = AssociatedPropertyModel.Street;
            property.City = AssociatedPropertyModel.City;
            property.Zip = AssociatedPropertyModel.Zip;
            property.IsDeleted = false;

            _propertyPropertyDescriptionService.PropertyService.AddProperty(property);

            var propertyDescription = new PropertyDescription();

            propertyDescription.PropertyDescriptionId =
                new PropertyDescriptionDefaultValueGenerator(new GardenGloryContext())
                    .PropertyDescriptionPrimaryKeyGenerator();
            propertyDescription.Description = AssociatedPropertyModel.Description;
            propertyDescription.IsDeleted = false;

            _propertyPropertyDescriptionService.PropertyDescriptionService.AddPropertyDescription(propertyDescription);

            AssociatedPropertyModel = new PropertyViewModel(property, new PropertyDescriptionService(new GardenGloryContext()));
            AssociatedPropertyModel.PropertyDescriptions.Add(propertyDescription);

            _propertyListViewModel.PropertyList.Insert(0, AssociatedPropertyModel);
            AssociatedPropertyModel.PropertyId = property.PropertyId;
            return "New Property is added successfully!";
        }

    }


}
