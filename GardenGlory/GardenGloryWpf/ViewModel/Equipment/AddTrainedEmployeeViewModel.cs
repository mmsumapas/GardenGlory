using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using GardenGlory;
using GardenGlory.Context;
using GardenGlory.DefaultValueGenerator;
using GardenGloryWpf.CmbViewModel;
using ServiceLayer;

namespace GardenGloryWpf.ViewModel.Equipment
{ 
    public class AddTrainedEmployeeViewModel
    {
        public EquipmentViewModel AssociatedEquipmentViewModel { get; set; }
        private TrainedEmployeeService _trainedEmployeeService { get; }
        public EmployeeDetailCmbViewModel AssociatedEmployeeDetailCmbViewModel { get; }
        public AddTrainedEmployeeViewModel(EquipmentViewModel equipmentViewModel, TrainedEmployeeService trainedEmployeeService, EmployeeDetailCmbViewModel employeeDetailCmbView)
        {
            AssociatedEquipmentViewModel = equipmentViewModel;
            _trainedEmployeeService = trainedEmployeeService;
           AssociatedEmployeeDetailCmbViewModel = employeeDetailCmbView;
        }

        public string Add()
        {
            var trainedEmployee = new TrainedEmployee();

            var context = new GardenGloryContext();

            var duplicationCheker = DuplicationChecker(AssociatedEquipmentViewModel.EquipmentTrainedEmployeeDetailList,
                AssociatedEmployeeDetailCmbViewModel.SelectedEmployee.EmployeeId);
            if (duplicationCheker == true)
            {
                return "This Employee is already existing in the database";
            }
            trainedEmployee.TrainedEmployeeId = new TrainedEmployeeDefaultValueGenerator(context).TrainedEmployeePrimaryKeyGenerator();
            trainedEmployee.EquipmentId = AssociatedEquipmentViewModel.EquipmentId;
            trainedEmployee.EmployeeId = AssociatedEmployeeDetailCmbViewModel.SelectedEmployee.EmployeeId;

            _trainedEmployeeService.AddTrainedEmployee(trainedEmployee);

            AssociatedEquipmentViewModel.EquipmentTrainedEmployeeDetailList.Add(new EquipmentTrainedEmployeeDetail(AssociatedEmployeeDetailCmbViewModel.SelectedEmployee.EmployeeId));
            return "New Trained Employee is added successfully!";


        }
       

        public bool DuplicationChecker(ObservableCollection<EquipmentTrainedEmployeeDetail> trainedEmployees,
            string employeeId)
        {
            foreach (var trainedEmployee in trainedEmployees)
            {
                if (trainedEmployee.EmployeeId == employeeId)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
