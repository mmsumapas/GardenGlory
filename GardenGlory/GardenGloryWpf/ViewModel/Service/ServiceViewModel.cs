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
using GardenGloryWpf.ViewModel.Customer;
using Microsoft.EntityFrameworkCore;
using ServiceLayer;
using ServiceLayer.MultipleServices;

namespace GardenGloryWpf.ViewModel.Service
{
    public class ServiceViewModel : INotifyPropertyChanged
    {
        private string _serviceId;
        private string _propertyId;
        private string _serviceType;
        private string _requestDate;
        private string _serviceRequest;

        public ServiceViewModel()
        {

        }

        public string ServiceId
        {
            get { return _serviceId; }
            internal set
            {
                _serviceId = value;
                OnPropertyChanged(nameof(ServiceId));
            }
        }

        public string PropertyId
        {
            get { return _propertyId; }
            set
            {
                _propertyId = value;
                OnPropertyChanged(nameof(PropertyId));
            }
        }

        public string ServiceType
        {
            get { return _serviceType; }
            set
            {
                _serviceType = value;
                OnPropertyChanged(nameof(ServiceType));
            }
        }

        public string RequestDate
        {
            get { return _requestDate; }
            set
            {
                _requestDate = value;
                OnPropertyChanged(nameof(RequestDate));
            }
        }

        public string ServiceRequest
        {
            get { return _serviceRequest; }
            set
            {
                _serviceRequest = value;
                OnPropertyChanged(nameof(ServiceRequest));
            }
        }

        public string ServiceTypeId { get; set; }
        public string OwnerName { get; set; }
        public string OwnerId { get; set; }
        public string PropertyName { get; set; }
        private PaymentService _paymentService;
        private TaskService _taskService;
        public ObservableCollection<ServicePaymentDetails> ServicePaymentDetailList { get; set; }
        public ObservableCollection<ServiceTaskDetails> ServiceTaskDetailList { get; set; }

        public ServiceViewModel(GardenGlory.EfClasses.Service service, PaymentService paymentService, TaskService taskService)
        {
            ServiceId = service.ServiceId;
            PropertyId = service.PropertyId;
            ServiceTypeId = service.ServiceTypeId;
            ServiceType = service.ServiceTypeLink.Type;
            RequestDate = service.RequestDate.ToShortDateString();
            ServiceRequest = service.ServiceRequest;
            OwnerName = service.PropertyLink.OwnerLink.OwnerName;
            OwnerId = service.PropertyLink.OwnerId;
            PropertyName = service.PropertyLink.PropertyName;

            _paymentService = paymentService;
            ServicePaymentDetailList = new ObservableCollection<ServicePaymentDetails>(_paymentService.GetPayments(service).Select(c =>
                 new ServicePaymentDetails(c)));

            _taskService = taskService;
            ServiceTaskDetailList = new ObservableCollection<ServiceTaskDetails>(_taskService.GetTasks(service).Select(c => new ServiceTaskDetails(c)));

        }



        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class EditServiceViewModel
    {
        private ServiceServiceTypeService _serviceServiceTypeService;
        public ServiceTypeCmbViewModel AssociatedServiceTypeCmbViewModel { get; }

        public EditServiceViewModel(ServiceViewModel serviceModel, ServiceServiceTypeService serviceServiceTypeService, ServiceTypeCmbViewModel serviceTypeCmbViewModel)
        {
            AssociatedServiceModel = serviceModel;
            AssociatedServiceTypeCmbViewModel = serviceTypeCmbViewModel;
            _serviceServiceTypeService = serviceServiceTypeService;
        }

        public ServiceViewModel AssociatedServiceModel { get; }

        public string Edit()
        {
            if (AssociatedServiceTypeCmbViewModel.SelectedServiceType == null  || AssociatedServiceModel.ServiceRequest == null)
            {
                return "Error";
            }
            
            if (AssociatedServiceTypeCmbViewModel.SelectedServiceType == null)
            {
                _serviceServiceTypeService.ServiceService.UpdateService(AssociatedServiceModel.ServiceId, AssociatedServiceModel.ServiceTypeId, 
                    AssociatedServiceModel.ServiceRequest);
            }
            else
            {
                AssociatedServiceModel.ServiceTypeId = AssociatedServiceTypeCmbViewModel.SelectedServiceType.ServiceTypeId;
                    _serviceServiceTypeService.ServiceService.UpdateService(AssociatedServiceModel.ServiceId, AssociatedServiceModel.ServiceTypeId,
                    AssociatedServiceModel.ServiceRequest);
                AssociatedServiceModel.ServiceType = AssociatedServiceTypeCmbViewModel.SelectedServiceType.Type;

            }

            return "";
        }
    }
    
    public class AddServiceViewModel
    {
        private readonly ServiceListViewModel _serviceListViewModel;
        private ServiceServiceTypeService _serviceServiceTypeService;


        public AddServiceViewModel(ServiceListViewModel serviceListViewModel, ServiceServiceTypeService serviceServiceTypeService,ServiceTypeCmbViewModel serviceTypeCmbViewModel, PropertyCmbViewModel propertyCmbViewModel)
        {
            AssociatedServiceViewModel = new ServiceViewModel();
            AssociatedServiceTypeCmbViewModel = serviceTypeCmbViewModel;
            AssociatedPropertyCmbViewModel = propertyCmbViewModel;
            _serviceListViewModel = serviceListViewModel;
            _serviceServiceTypeService = serviceServiceTypeService;


        }

        public ServiceViewModel AssociatedServiceViewModel { get; }
        public ServiceTypeCmbViewModel AssociatedServiceTypeCmbViewModel { get; }
        public PropertyCmbViewModel AssociatedPropertyCmbViewModel { get; }


        public string Add()
        {
            var service = new GardenGlory.EfClasses.Service();

            if (AssociatedPropertyCmbViewModel.SelectedProperty == null||  AssociatedServiceTypeCmbViewModel.SelectedServiceType == null||
                AssociatedServiceViewModel.RequestDate == null|| AssociatedServiceViewModel.ServiceRequest == null)
            {
                return "Error";
            }

            var context = new GardenGloryContext();

            service.ServiceId = new ServiceDefaultValueGenerator(context).ServicePrimaryKeyGenerator();
            service.PropertyId = AssociatedPropertyCmbViewModel.SelectedProperty.PropertyId;
            service.ServiceTypeId = AssociatedServiceTypeCmbViewModel.SelectedServiceType.ServiceTypeId;
            service.ServiceRequest = AssociatedServiceViewModel.ServiceRequest;

            var requestDate = AssociatedServiceViewModel.RequestDate.Split(new char[] { '/', ' ' });
            AssociatedServiceViewModel.RequestDate = $"{requestDate[0]}/{requestDate[1]}/{requestDate[2]}";
            service.RequestDate = new DateTime(Convert.ToInt32(requestDate[2]), Convert.ToInt32(requestDate[0]), Convert.ToInt32(requestDate[1]));

            service.IsDeleted = false;

            _serviceServiceTypeService.ServiceService.AddService(service);

            AssociatedServiceViewModel.ServiceId = service.ServiceId;
            AssociatedServiceViewModel.ServiceTypeId = service.ServiceTypeId;
            AssociatedServiceViewModel.ServiceType = AssociatedServiceTypeCmbViewModel.SelectedServiceType.Type;
            AssociatedServiceViewModel.OwnerName = AssociatedPropertyCmbViewModel.SelectedProperty.OwnerLink.OwnerName;
            AssociatedServiceViewModel.PropertyName = AssociatedPropertyCmbViewModel.SelectedProperty.PropertyName;
            AssociatedServiceViewModel.PropertyId = AssociatedPropertyCmbViewModel.SelectedProperty.PropertyId;
            AssociatedServiceViewModel.OwnerId = AssociatedPropertyCmbViewModel.SelectedProperty.OwnerLink.OwnerId;
            _serviceListViewModel.ServiceList.Insert(0, AssociatedServiceViewModel);

            AssociatedServiceViewModel.ServicePaymentDetailList = new ObservableCollection<ServicePaymentDetails>(new PaymentService(new GardenGloryContext()).GetPayments(service).Select(c =>
                new ServicePaymentDetails(c)));

            AssociatedServiceViewModel.ServiceTaskDetailList = new ObservableCollection<ServiceTaskDetails>(new TaskService(new GardenGloryContext()).GetTasks(service).Select(c => new ServiceTaskDetails(c)));
            return "New Service is successfully added!";
        }
    }
    public class ServicePaymentDetails
    {
        public ServicePaymentDetails(Payment payment)
        {
            PaymentMethod = payment.PaymentMethodLink.Method;
            PaymentId = payment.PaymentId;
            Amount = payment.Amount.ToString();
        }

        public ServicePaymentDetails(Payment payment, string paymentMethod)
        {
            PaymentMethod = paymentMethod;
            PaymentId = payment.PaymentId;
            Amount = payment.Amount.ToString();
        }

        public string PaymentMethod { get; set; }
        public string PaymentId { get; set; }
        public string Amount { get; set; }

    }

    public class ServiceTaskDetails
    {
        public ServiceTaskDetails(Task task)
        {
            TaskId = task.TaskId;
            Task = task.TaskName;
            DateConducted = task.DateConducted.ToShortDateString();
        }
        public string TaskId { get; set; }
        public string Task { get; set; }
        public string DateConducted { get; set; }
    }


}
