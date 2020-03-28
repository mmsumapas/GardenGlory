using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using GardenGlory.Context;
using ServiceLayer;

namespace GardenGloryWpf.ViewModel.Service
{
    public class ServiceListViewModel
    {
        private ServiceService _serviceService;
        private string _searchText;
      

        public ServiceListViewModel(ServiceService serviceService)
        {
            _serviceService = serviceService;
            ServiceList =
                new ObservableCollection<ServiceViewModel>(_serviceService.GetServices()
                    .Select(c => new ServiceViewModel(c, new PaymentService(new GardenGloryContext()), new TaskService(new GardenGloryContext()))));
            
        }

        public void SearchService(string searchString)
        {
            ServiceList.Clear();

            var services = _serviceService.GetServices().Where(c =>
                c.ServiceId.Contains(searchString) || c.PropertyLink.PropertyId.Contains(searchString) ||
                c.PropertyLink.OwnerLink.OwnerName.Contains(searchString) || c.PropertyLink.PropertyName.Contains(searchString)||
                c.RequestDate.ToString().Contains(SearchText) ||c.ServiceTypeLink.Type.Contains(searchString) ||
                c.ServiceRequest.Contains(searchString));
            var context = new GardenGloryContext();

            foreach (var service in services)
            {
                var serviceModel = new ServiceViewModel(service, new PaymentService(context), new TaskService(context));
                ServiceList.Add(serviceModel);
            }

        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                SearchService(_searchText);
            }
        }

        public ObservableCollection<ServiceViewModel> ServiceList { get; }
        public ServiceViewModel SelectedService { get; set; }
    }
}
