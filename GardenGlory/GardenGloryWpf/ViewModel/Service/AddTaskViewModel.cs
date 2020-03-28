using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using GardenGlory.Context;
using GardenGlory.DefaultValueGenerator;
using GardenGlory.EfClasses;
using GardenGloryWpf.CmbViewModel;
using GardenGloryWpf.ViewModel.Employee;
using GardenGloryWpf.ViewModel.Equipment;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using ServiceLayer;

namespace GardenGloryWpf.ViewModel.Service
{
    public class AddTaskViewModel
    {
        public ServiceViewModel AssociatedServiceViewModel { get; set; }

        private TaskService _taskService { get;  }

        public AddTaskViewModel(ServiceViewModel serviceViewModel, TaskService taskService,EquipmentCmbViewModel equipmentCmbViewModel, EmployeeDetailCmbViewModel employeeDetailCmbView)
        {
            AssociatedServiceViewModel = serviceViewModel;
            AssociatedEquipmentCmbViewModel = equipmentCmbViewModel;
            AssociatedEmployeeDetailCmbViewModel = employeeDetailCmbView;
            _taskService = taskService;
            
        }
        public EquipmentCmbViewModel AssociatedEquipmentCmbViewModel { get; }
        public EmployeeDetailCmbViewModel AssociatedEmployeeDetailCmbViewModel { get; }
        public string Add()
        {

            if (AssociatedEmployeeDetailCmbViewModel.SelectedEmployee== null || DateConducted == null || HoursWorked == null || TaskName == null ||
                AssociatedEquipmentCmbViewModel.SelectedEquipment == null|| UsageDescription == null || UsageDescription == "")
            {
                return "Error";
            }
        
            var task = new Task();
            
           var trained = new EquipmentService(new GardenGloryContext()).IsTrained(AssociatedEquipmentCmbViewModel.SelectedEquipment, AssociatedEmployeeDetailCmbViewModel.SelectedEmployee.EmployeeId);
            var hoursChecker = HoursWorked.Any(c => char.IsLetter(c));
            if (trained == false)
            {
                return "The task is not permitted. Selected employee is not trained to use the equipment";
            }
            if (hoursChecker != true ) 
            {
               task.TaskId = new TaskDefaultValueGenerator(new GardenGloryContext()).TaskPrimaryKeyGenerator();
               task.ServiceId = AssociatedServiceViewModel.ServiceId;

               var dateConducted = DateConducted.Split(new char[] {'/', ' '});

               task.DateConducted = new DateTime(Convert.ToInt32(dateConducted[2]), Convert.ToInt32(dateConducted[0]),
                   Convert.ToInt32(dateConducted[1]));
               task.EmployeeId = AssociatedEmployeeDetailCmbViewModel.SelectedEmployee.EmployeeId;
               task.TaskName = TaskName;
               task.HoursWorked = Convert.ToDouble(HoursWorked);

               _taskService.AddTask(task);
               var equipmentUsageService = new EquipmentUsageService(new GardenGloryContext());
               var equipmentUsage = new EquipmentUsage();

               equipmentUsage.EquipmentUsageId = new EquipmentUsageDefaultValueGenerator(new GardenGloryContext()).EquipmentUsagePrimaryKeyGenerator();
                equipmentUsage.EquipmentId = AssociatedEquipmentCmbViewModel.SelectedEquipment.EquipmentId;
               equipmentUsage.TaskId = task.TaskId;
               equipmentUsage.UsageDescription = UsageDescription;

              
               equipmentUsageService.AddEquipmentUsage(equipmentUsage);
               AssociatedServiceViewModel.ServiceTaskDetailList.Add(new ServiceTaskDetails(task));


                return "New task is added successfully";
            }
            else
            {
               return "Error";
            }
        


        }

        public string DateConducted { get; set; }
        public string HoursWorked { get; set; }
        public string TaskName { get; set; }
        public string UsageDescription { get; set; }

       

    }
}
