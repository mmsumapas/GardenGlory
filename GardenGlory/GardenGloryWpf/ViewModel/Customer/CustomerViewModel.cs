using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Controls;
using Accessibility;
using GardenGlory.Context;
using GardenGlory.DefaultValueGenerator;
using GardenGlory.EfClasses;
using GardenGloryWpf.Annotations;
using GardenGloryWpf.CmbViewModel;
using GardenGloryWpf.ViewModel.Customer;
using Microsoft.EntityFrameworkCore;
using ServiceLayer;
using ServiceLayer.MultipleServices;

namespace GardenGloryWpf
{
    public class CustomerViewModel : INotifyPropertyChanged
    {
        private string _ownerId;
        private string _name;
        private string _email;
        private string _contactNumber;
        private string _ownerType;

        public CustomerViewModel()
        {

        }

        public string OwnerId
        {
            get { return _ownerId; }
            internal set
            {
                _ownerId = value;
                OnPropertyChanged(nameof(OwnerId));
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }

        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string ContactNumber
        {
            get { return _contactNumber; }
            set
            {
                _contactNumber = value;
                OnPropertyChanged(nameof(ContactNumber));
            }
        }

        public string OwnerType
        {
            get { return _ownerType; }
            set
            {
                _ownerType = value;
                OnPropertyChanged(nameof(OwnerType));
            }
        }
        public string OwnerTypeId { get; set; }
        private ServiceService _serviceService;
        public ObservableCollection<CustomerDetials> CustomerDetialList { get; }
        public CustomerViewModel(Owner owner, ServiceService serviceService)
        {
            OwnerId = owner.OwnerId;
            Name = owner.OwnerName;
            Email = owner.OwnerEmail;
            ContactNumber = owner.ContactNumber;
            OwnerType = owner.OwnerTypeLink.Type;
            OwnerTypeId = owner.OwnerTypeId;
            _serviceService = serviceService;

            CustomerDetialList = new ObservableCollection<CustomerDetials>(_serviceService.GetServices(owner.OwnerId).Select(c =>
                new CustomerDetials(c)));

        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class EditCustomerViewModel
    {
        private OwnerOwnerTypeService _ownerOwnerTypeService;
        public OwnerTypeCmbViewModel AssociatedOwnerTypeCmbViewModel { get; }
        public EditCustomerViewModel(CustomerViewModel customerModel, OwnerOwnerTypeService ownerOwnerTypeService, OwnerTypeCmbViewModel ownerTypeCmbViewModel)
        {
            AssociatedCustomerModel = customerModel;
            AssociatedOwnerTypeCmbViewModel = ownerTypeCmbViewModel;
            _ownerOwnerTypeService = ownerOwnerTypeService;

            EditableFields(customerModel);
        }
        private void EditableFields(CustomerViewModel customerModel)
        {
            Name = customerModel.Name;
            Email = customerModel.Email;
            ContactNumber = customerModel.ContactNumber;
        }
        public CustomerViewModel AssociatedCustomerModel { get; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }



        public string Edit()
        {
            if (Name == "" || Email == "" || ContactNumber == "" || AssociatedOwnerTypeCmbViewModel.SelectedOwnerType == null)
            {
                return "Error";
            }
            AssociatedCustomerModel.Name = Name;
            AssociatedCustomerModel.Email = Email;
            AssociatedCustomerModel.ContactNumber = ContactNumber;
            if (AssociatedOwnerTypeCmbViewModel.SelectedOwnerType == null)
            {
                _ownerOwnerTypeService.OwnerService.UpdateOwner(AssociatedCustomerModel.OwnerId, AssociatedCustomerModel.OwnerTypeId,
                    AssociatedCustomerModel.Name, AssociatedCustomerModel.Email, AssociatedCustomerModel.ContactNumber);
            }
            else
            {
                AssociatedCustomerModel.OwnerType = AssociatedOwnerTypeCmbViewModel.SelectedOwnerType.Type;
                AssociatedCustomerModel.OwnerTypeId = AssociatedOwnerTypeCmbViewModel.SelectedOwnerType.OwnerTypeId;

                _ownerOwnerTypeService.OwnerService.UpdateOwner(AssociatedCustomerModel.OwnerId, AssociatedCustomerModel.OwnerTypeId,
                    AssociatedCustomerModel.Name, AssociatedCustomerModel.Email, AssociatedCustomerModel.ContactNumber);


            }

            return "";
        }
    }

    public class AddCustomerViewModel
    {
        private readonly CustomerListViewModel _customerListViewModel;

        private OwnerOwnerTypeService _ownerOwnerTypeService;

        private ServiceServiceTypeService _serviceServiceTypeService;

        private PropertyPropertyDescriptionService _propertyPropertyDescriptionService;

        public ServiceTypeCmbViewModel AssociatedServiceTypeCmbViewModel { get; }
        public OwnerTypeCmbViewModel AssociatedOwnerTypeCmbViewModel { get; }

        public AddCustomerViewModel(CustomerListViewModel customerListViewModel,OwnerOwnerTypeService ownerOwnerTypeService, ServiceServiceTypeService serviceServiceTypeService, PropertyPropertyDescriptionService propertyPropertyDescriptionService, ServiceTypeCmbViewModel serviceTypeCmbViewModel, OwnerTypeCmbViewModel owenTypeCmbViewModel)
        {
            AssociatedCustomerModel = new CustomerViewModel();
            _customerListViewModel = customerListViewModel;

            _ownerOwnerTypeService = ownerOwnerTypeService;
            _serviceServiceTypeService = serviceServiceTypeService;

            _propertyPropertyDescriptionService = propertyPropertyDescriptionService;
            AssociatedServiceTypeCmbViewModel = serviceTypeCmbViewModel;
            AssociatedOwnerTypeCmbViewModel = owenTypeCmbViewModel;


        }
        public CustomerViewModel AssociatedCustomerModel { get; set; }
        public string ServiceRequest { get; set; }
        public string PropertyName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Description { get; set; }


        public string Add()
        {
            var customer = new Owner();

            var context = new GardenGloryContext();
            if (AssociatedOwnerTypeCmbViewModel.SelectedOwnerType == null || AssociatedServiceTypeCmbViewModel.SelectedServiceType == null|| ServiceRequest == ""|| ServiceRequest == null|| PropertyName == null|| Street == null||
                City == null|| Zip == null|| AssociatedCustomerModel.ContactNumber == null|| AssociatedCustomerModel.Email==null|| AssociatedCustomerModel.Name== null)
            {
                return "Error";
            }

            customer.OwnerId = new CustomerDefaultValueGenerator(context).CustomerPrimaryKeyGenerator();
            customer.OwnerName = AssociatedCustomerModel.Name;
            customer.OwnerEmail = AssociatedCustomerModel.Email;
            customer.ContactNumber = AssociatedCustomerModel.ContactNumber;
            customer.OwnerTypeId = AssociatedOwnerTypeCmbViewModel.SelectedOwnerType.OwnerTypeId;
            customer.IsDeleted = false;

            _ownerOwnerTypeService.OwnerService.AddOwner(customer);

            var property = new Property();
            property.PropertyId = new PropertyDefaultValueGenerator(new GardenGloryContext()).PropertyPrimaryKeyGenerator();
            property.PropertyName = PropertyName;
            property.Street = Street;
            property.City = City;
            property.Zip = Zip;
            property.IsDeleted = false;
            property.OwnerId = customer.OwnerId;
            _propertyPropertyDescriptionService.PropertyService.AddProperty(property);


            var service = new Service();
            service.ServiceId = new ServiceDefaultValueGenerator(new GardenGloryContext()).ServicePrimaryKeyGenerator();
            service.PropertyId = property.PropertyId;
            service.ServiceTypeId = AssociatedServiceTypeCmbViewModel.SelectedServiceType.ServiceTypeId;
            service.RequestDate = DateTime.Today.Date;
            service.ServiceRequest = ServiceRequest;
            service.IsDeleted = false;
                _serviceServiceTypeService.ServiceService.AddService(service);

            if (Description != null || Description == "")
            {
                var propertyDescription = new PropertyDescription();
                propertyDescription.PropertyDescriptionId = new PropertyDescriptionDefaultValueGenerator(new GardenGloryContext()).PropertyDescriptionPrimaryKeyGenerator();
                propertyDescription.PropertyId = property.PropertyId;
                propertyDescription.Description = Description;
                _propertyPropertyDescriptionService.PropertyDescriptionService.AddPropertyDescription(propertyDescription);
            }

            AssociatedCustomerModel = new CustomerViewModel(customer, new ServiceService(new GardenGloryContext()));

            _customerListViewModel.CustomerList.Insert(0, AssociatedCustomerModel);
            AssociatedCustomerModel.OwnerId = customer.OwnerId;
            AssociatedCustomerModel.OwnerTypeId = customer.OwnerTypeId;
            AssociatedCustomerModel.OwnerType = AssociatedOwnerTypeCmbViewModel.SelectedOwnerType.Type;

            return "New customer is successfully added!";
        }
    }

    public class CustomerDetials
    {
        public CustomerDetials(Service service)
        {
            PropertyName = service.PropertyLink.PropertyName;
            ServiceId = service.ServiceId;
            ServiceType = service.ServiceTypeLink.Type;
            RequestDate = service.RequestDate.ToShortDateString();
        }
        public CustomerDetials(string serviceId)
        {
            var service = new ServiceService(new GardenGloryContext()).GetService(serviceId);
            PropertyName = service.PropertyLink.PropertyName;
            ServiceId = service.ServiceId;
            ServiceType = service.ServiceTypeLink.Type;
            RequestDate = service.RequestDate.ToShortDateString();
        }


        public string PropertyName { get; set; }
        public string ServiceId { get; set; }
        public string ServiceType { get; set; }
        public string RequestDate { get; set; }
    }


}
