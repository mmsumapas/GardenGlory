using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using GardenGlory.EfClasses;
using GardenGloryWpf.ViewModel.Account;
using GardenGloryWpf.ViewModel.Service;
using ServiceLayer;

namespace GardenGloryWpf.CmbViewModel
{
    public class ServiceTypeCmbViewModel
    {
        private string _searchServiceTypeText;
        private ServiceTypeService _serviceTypeService;
        public ServiceViewModel AssociatedServiceViewModel { get; }

        public ServiceTypeCmbViewModel(ServiceViewModel serviceViewModel, ServiceTypeService serviceTypeService)
        {
            AssociatedServiceViewModel = serviceViewModel;
            _serviceTypeService = serviceTypeService;
            ServiceTypes = new ObservableCollection<ServiceType>(_serviceTypeService.GetServiceTypes());
            SelectedServiceType = ServiceTypes.First(c => c.ServiceTypeId==AssociatedServiceViewModel.ServiceTypeId);
        }
        public ServiceTypeCmbViewModel(ServiceTypeService serviceTypeService)
        {
            _serviceTypeService = serviceTypeService;
            ServiceTypes = new ObservableCollection<ServiceType>(_serviceTypeService.GetServiceTypes());

        }

        public string SearchServiceTypeText
        {
            get => _searchServiceTypeText;
            set
            {
                _searchServiceTypeText = value;
                if (_searchServiceTypeText == null)
                {
                    _searchServiceTypeText = "";
                    SearchServiceType(_searchServiceTypeText);
                }
                else
                {
                    SearchServiceType(_searchServiceTypeText);
                }
            }

        }
        public void SearchServiceType(string searchText)
        {
          
            var serviceTypes = _serviceTypeService.GetServiceTypes()
                .Where(c => c.Type.Contains(searchText));
            ServiceTypes.Clear();
            foreach (var serviceType in serviceTypes)
            {
                ServiceTypes.Add(serviceType);
            }
        }

        public ObservableCollection<ServiceType> ServiceTypes{ get; set; }
        public ServiceType SelectedServiceType { get; set; }
    }
}
