using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using GardenGlory;
using GardenGlory.Context;
using GardenGlory.DefaultValueGenerator;
using GardenGlory.EfClasses;
using GardenGloryWpf.Annotations;
using GardenGloryWpf.ViewModel.Customer;
using ServiceLayer;

namespace GardenGloryWpf.ViewModel.Equipment
{
    public class EquipmentViewModel : INotifyPropertyChanged
    {
        private string _equipmentId;
        private string _equipmentName;

        public EquipmentViewModel()
        {
            
        }

        public string EquipmentId
        {
            get { return _equipmentId; }
            set
            {
                _equipmentId = value;
                OnPropertyChanged(nameof(EquipmentId));
            }
        }

        public string EquipmentName
        {
            get { return _equipmentName; }
            set
            {
                _equipmentName = value;
                OnPropertyChanged(nameof(EquipmentName));
            }
        }

        private EquipmentRepairService _equipmentRepairService;
        private TrainedEmployeeService _trainedEmployeeService;
        private EquipmentUsageService _equipmentUsageService;
        public ObservableCollection<EquipmentRepairDetail> EquipmentRepairDetailList { get; set; }
        public ObservableCollection<EquipmentTrainedEmployeeDetail> EquipmentTrainedEmployeeDetailList { get; set; }
        public ObservableCollection<EquipmentTaskDetail> EquipmentTaskDetailList { get; set; }
        public EquipmentViewModel(GardenGlory.EfClasses.Equipment equipment, EquipmentRepairService equipmentRepairService, TrainedEmployeeService trainedEmployeeService,
            EquipmentUsageService equipmentUsageService)
        {
            EquipmentId = equipment.EquipmentId;
            EquipmentName = equipment.EquipmentName;

            _equipmentRepairService = equipmentRepairService;
            EquipmentRepairDetailList = new ObservableCollection<EquipmentRepairDetail>(_equipmentRepairService.GetEquipmentRepairs(equipment).Select(c =>
                new EquipmentRepairDetail(c)));

            _trainedEmployeeService = trainedEmployeeService;
            EquipmentTrainedEmployeeDetailList = new ObservableCollection<EquipmentTrainedEmployeeDetail>(_trainedEmployeeService.GetTrainedEmployees(equipment).Select(c =>
                new EquipmentTrainedEmployeeDetail(c)));

            _equipmentUsageService = equipmentUsageService;
            EquipmentTaskDetailList = new ObservableCollection<EquipmentTaskDetail>(_equipmentUsageService.GetEquipmentUsages(equipment).Select(c =>
                new EquipmentTaskDetail(c)));

        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class EditEquipmentViewModel
    {
        private EquipmentService _equipmentService;
        public EditEquipmentViewModel(EquipmentViewModel equipmentViewModel, EquipmentService equipmentService)
        {
            AssociatedEquipmentViewModel = equipmentViewModel;
            _equipmentService = equipmentService;
            EditableFields(equipmentViewModel);
        }

        public void EditableFields(EquipmentViewModel equipmentViewModel)
        {
            EquipmentName = equipmentViewModel.EquipmentName;
        }
        public EquipmentViewModel AssociatedEquipmentViewModel { get; }
        public string EquipmentName { get; set; }

        public string Edit()
        {
            if (EquipmentName == "")
            {
                return "Error";
            }
            AssociatedEquipmentViewModel.EquipmentName = EquipmentName;
            _equipmentService.UpdateEquipment(AssociatedEquipmentViewModel.EquipmentId, AssociatedEquipmentViewModel.EquipmentName);
            return "";
        }
    }
    public class AddEquipmentViewModel
    {
        private EquipmentListViewModel _equipmentListViewModel;
        private EquipmentService _equipmentService;

        public AddEquipmentViewModel(EquipmentListViewModel equipmentListViewModel, EquipmentService equipmentService)
        {
            AssociatedEquipmentViewModel = new EquipmentViewModel();
            _equipmentListViewModel = equipmentListViewModel;
            _equipmentService = equipmentService;
        }

        public EquipmentViewModel AssociatedEquipmentViewModel { get; }

        public string Add()
        {
            if (AssociatedEquipmentViewModel.EquipmentName == null)
            {
                return "Error";
            }
            var equipment = new GardenGlory.EfClasses.Equipment();

            var context = new GardenGloryContext();


            var equipmentChecker = context.Equipments.Where(c => c.EquipmentName == AssociatedEquipmentViewModel.EquipmentName && c.IsDeleted != true).Count();

            if (equipmentChecker != 0)
            {

                return "Error";
            }
            else
            {
                equipment.EquipmentId = new EquipmentDefaultValueGenerator(context).EquipmentPrimaryKeyValueGenerator();
                equipment.EquipmentName = AssociatedEquipmentViewModel.EquipmentName;
                equipment.IsDeleted = false;

                _equipmentService.AddEquipment(equipment);
                AssociatedEquipmentViewModel.EquipmentId = equipment.EquipmentId;
                _equipmentListViewModel.EquipmentList.Insert(0, AssociatedEquipmentViewModel);


                    AssociatedEquipmentViewModel.EquipmentRepairDetailList = new ObservableCollection<EquipmentRepairDetail>(new EquipmentRepairService(new GardenGloryContext())
                        .GetEquipmentRepairs(equipment).Select(c =>
                    new EquipmentRepairDetail(c)));

                AssociatedEquipmentViewModel.EquipmentTrainedEmployeeDetailList = new ObservableCollection<EquipmentTrainedEmployeeDetail>(new TrainedEmployeeService(new GardenGloryContext())
                    .GetTrainedEmployees(equipment).Select(c =>
                    new EquipmentTrainedEmployeeDetail(c)));

                AssociatedEquipmentViewModel.EquipmentTaskDetailList = new ObservableCollection<EquipmentTaskDetail>(new EquipmentUsageService(new GardenGloryContext())
                    .GetEquipmentUsages(equipment).Select(c =>
                    new EquipmentTaskDetail(c)));

                return "New equipment is successfully added into the database!";
            }

        }
    }

    public class EquipmentRepairDetail
    {
        public EquipmentRepairDetail(EquipmentRepair equipmentRepair)
        {
            DateOfRepair = equipmentRepair.DateOfRepair.ToShortDateString();
            Amount = equipmentRepair.Amount.ToString();
            Remarks = equipmentRepair.Remarks;
        }
        public string DateOfRepair { get; set; }
        public string Amount { get; set; }
        public string Remarks { get; set; }

    }

    public class EquipmentTrainedEmployeeDetail
    {
        public EquipmentTrainedEmployeeDetail(TrainedEmployee trainedEmployee)
        {
            EmployeeId = trainedEmployee.EmployeeId;
            FirstName = trainedEmployee.EmployeeLink.FirstName;
            LastName = trainedEmployee.EmployeeLink.LastName;
            ContactNumber = trainedEmployee.EmployeeLink.CellPhone;
        }

        public EquipmentTrainedEmployeeDetail(string employeeId)
        {
            var employee = new GardenGloryContext().Employees.Find(employeeId);
            EmployeeId = employee.EmployeeId;
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            ContactNumber = employee.CellPhone;
        }
        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
    }

    public class EquipmentTaskDetail
    {
        public EquipmentTaskDetail(EquipmentUsage equipmentUsage)
        {
            TaskName = equipmentUsage.TaskLink.TaskName;
            DateConducted = equipmentUsage.TaskLink.DateConducted.ToShortDateString();
            Description = equipmentUsage.UsageDescription;
        }
        public string TaskName { get; set; }
        public string DateConducted { get; set; }
        public string Description { get; set; }
    }

}
