using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Navigation;
using GardenGlory.Context;
using GardenGlory.DefaultValueGenerator;
using GardenGlory.EfClasses;
using GardenGloryWpf.Annotations;
using GardenGloryWpf.CmbViewModel;
using GardenGloryWpf.ViewModel.Customer;
using ServiceLayer;
using ServiceLayer.MultipleServices;

namespace GardenGloryWpf.ViewModel.Employee
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        private string _employeeId;
        private string _experienceLevel;
        private string _employeeStatus;
        private string _supervisorId;
        private string _employeeType;
        private string _lastNama;
        private string _firstName;
        private string _cellPhone;
        private string _totalHoursWorked;

        public EmployeeViewModel()
        {

        }
        public string EmployeeId
        {
            get { return _employeeId; }
            set
            {
                _employeeId = value;
                OnPropertyChanged(nameof(EmployeeId));
            }
        }

        public string ExperienceLevel
        {
            get { return _experienceLevel; }
            set
            {
                _experienceLevel = value;
                OnPropertyChanged(nameof(ExperienceLevel));
            }
        }

        public string EmployeeStatus
        {
            get { return _employeeStatus; }
            set
            {
                _employeeStatus = value;
                OnPropertyChanged(nameof(EmployeeStatus));
            }
        }
        public string SupervisorId
        {
            get { return _supervisorId; }
            set
            {
                _supervisorId = value;
                OnPropertyChanged(SupervisorId);
            }
        }

        public string EmployeeType
        {
            get { return _employeeType; }
            set
            {
                _employeeType = value;
                OnPropertyChanged(nameof(EmployeeType));
            }
        }

        public string LastName
        {
            get { return _lastNama; }
            set
            {
                _lastNama = value;
                OnPropertyChanged(LastName);
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged(FirstName);
            }
        }

        public string CellPhone
        {
            get { return _cellPhone; }
            set
            {
                _cellPhone = value;
                OnPropertyChanged(CellPhone);
            }
        }

        public string TotalHoursWorked
        {
            get { return _totalHoursWorked; }
            set
            {
                _totalHoursWorked = value;
                OnPropertyChanged(TotalHoursWorked);
            }
        }

        public EmployeeViewModel(GardenGlory.EfClasses.Employee employee, TaskService taskService)
        {
            EmployeeId = employee.EmployeeId;
            ExperienceLevelId = employee.ExperienceLevelId;
            ExperienceLevel = employee.ExperienceLevelLink.Level;
            EmployeeStatusId = employee.EmployeeStatusId;
            EmployeeStatus = employee.EmployeeStatusLink.Status;
            SupervisorId = employee.SupervisorId;
            EmployeeTypeId = employee.EmployeeTypeId;
            EmployeeType = employee.EmployeeTypeLink.Type;
            LastName = employee.LastName;
            FirstName = employee.FirstName;
            CellPhone = employee.CellPhone;

            double totalHourWorked = 0;
            var context = new GardenGloryContext();
            var tasks = context.Tasks.Where(c => c.EmployeeId == EmployeeId).ToList();
            foreach (var task in tasks)
            {
                totalHourWorked = totalHourWorked + task.HoursWorked;
            }

            totalHourWorked = Math.Round(totalHourWorked, 2);
            TotalHoursWorked = totalHourWorked.ToString();
            _taskService = taskService;

            EmployeeDetailList = new ObservableCollection<EmployeeDetails>(_taskService.GetTasks(employee).Select(c => new EmployeeDetails(c)));
        }

        public ObservableCollection<EmployeeDetails> EmployeeDetailList { get; set; }
        private TaskService _taskService { get;  }
        public string ExperienceLevelId { get; set; }
        public string EmployeeStatusId { get; set; }
        public string EmployeeTypeId { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class EditEmployeeViewModel
    {
        private EmployeeExperienceLevelEmployeeStatusEmployeeTypeService _employeeServices;
        public EmployeeDetailCmbViewModel AssociatedEmployeeDetailCmbViewModel { get; }
        public EditEmployeeViewModel(EmployeeViewModel employeeViewModel, EmployeeExperienceLevelEmployeeStatusEmployeeTypeService employeeServices, EmployeeDetailCmbViewModel employeeDetailCmbViewModel)
        {
            AssociatedEmployeeViewModel = employeeViewModel;
            AssociatedEmployeeDetailCmbViewModel = employeeDetailCmbViewModel;

            _employeeServices = employeeServices;

         
            EditableField(employeeViewModel);

        }
        private void EditableField(EmployeeViewModel employeeViewModel)
        {
            LastName = employeeViewModel.LastName;
            FirstName = employeeViewModel.FirstName;
            CellPhone = employeeViewModel.CellPhone;
            TotalHoursWorked = employeeViewModel.TotalHoursWorked;
        }

        public EmployeeViewModel AssociatedEmployeeViewModel { get; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string CellPhone { get; set; }
        public string TotalHoursWorked { get; set; }

        public string Edit()
        {
            if (FirstName == "" || LastName == "" || CellPhone == "" ||
                AssociatedEmployeeDetailCmbViewModel.SelectedEmployeeType == null || AssociatedEmployeeDetailCmbViewModel.SelectedEmployeeStatus == null || AssociatedEmployeeDetailCmbViewModel.SelectedExperienceLevel == null)
            {
                return "Error";
            }
            AssociatedEmployeeViewModel.LastName = LastName;
            AssociatedEmployeeViewModel.FirstName = FirstName;
            AssociatedEmployeeViewModel.CellPhone = CellPhone;
            AssociatedEmployeeViewModel.TotalHoursWorked = TotalHoursWorked;
            
            if (AssociatedEmployeeDetailCmbViewModel.SelectedEmployee != null)
                AssociatedEmployeeViewModel.SupervisorId = AssociatedEmployeeDetailCmbViewModel.SelectedEmployee.EmployeeId;
            else
                AssociatedEmployeeViewModel.SupervisorId = null;


            if (AssociatedEmployeeDetailCmbViewModel.SelectedExperienceLevel == null && AssociatedEmployeeDetailCmbViewModel.SelectedEmployeeStatus == null && AssociatedEmployeeDetailCmbViewModel.SelectedEmployeeType == null)
            {
                _employeeServices.EmployeeService.UpdateEmployee(AssociatedEmployeeViewModel.EmployeeId, AssociatedEmployeeViewModel.ExperienceLevelId,
                    AssociatedEmployeeViewModel.EmployeeStatusId, AssociatedEmployeeViewModel.SupervisorId, AssociatedEmployeeViewModel.EmployeeTypeId,
                    AssociatedEmployeeViewModel.LastName, AssociatedEmployeeViewModel.FirstName, AssociatedEmployeeViewModel.CellPhone);
            }
            else
            {

                AssociatedEmployeeViewModel.ExperienceLevel = AssociatedEmployeeDetailCmbViewModel.SelectedExperienceLevel.Level;
                AssociatedEmployeeViewModel.ExperienceLevelId = AssociatedEmployeeDetailCmbViewModel.SelectedExperienceLevel.ExperienceLevelId;

                AssociatedEmployeeViewModel.EmployeeStatus = AssociatedEmployeeDetailCmbViewModel.SelectedEmployeeStatus.Status;
                AssociatedEmployeeViewModel.EmployeeStatusId = AssociatedEmployeeDetailCmbViewModel.SelectedEmployeeStatus.EmployeeStatusId;

                AssociatedEmployeeViewModel.EmployeeType = AssociatedEmployeeDetailCmbViewModel.SelectedEmployeeType.Type;
                AssociatedEmployeeViewModel.EmployeeTypeId = AssociatedEmployeeDetailCmbViewModel.SelectedEmployeeType.EmployeeTypeId;

                    _employeeServices.EmployeeService.UpdateEmployee(AssociatedEmployeeViewModel.EmployeeId, AssociatedEmployeeViewModel.ExperienceLevelId,
                    AssociatedEmployeeViewModel.EmployeeStatusId, AssociatedEmployeeViewModel.SupervisorId, AssociatedEmployeeViewModel.EmployeeTypeId,
                    AssociatedEmployeeViewModel.LastName, AssociatedEmployeeViewModel.FirstName, AssociatedEmployeeViewModel.CellPhone);


            }

            return "";
        }

    }

    public class AddEmployeeViewModel
    {
        private readonly EmployeeListViewModel _employeeListViewModel;
        private EmployeeExperienceLevelEmployeeStatusEmployeeTypeService _employeeServices;
        public EmployeeDetailCmbViewModel AssociatedEmployeeDetailCmbViewModel { get; }

        public AddEmployeeViewModel(EmployeeListViewModel employeeListViewModel, EmployeeExperienceLevelEmployeeStatusEmployeeTypeService employeeServices, EmployeeDetailCmbViewModel employeeDetailCmbViewModel)
        {
            AssociatedEmployeeViewModel = new EmployeeViewModel();
            AssociatedEmployeeDetailCmbViewModel = employeeDetailCmbViewModel;
            _employeeListViewModel = employeeListViewModel;
            _employeeServices = employeeServices;



        }
        public EmployeeViewModel AssociatedEmployeeViewModel { get; set; }

        public string Add()
        {
            if (AssociatedEmployeeViewModel.FirstName == null || AssociatedEmployeeViewModel.LastName == null ||
                AssociatedEmployeeViewModel.CellPhone == null ||
                AssociatedEmployeeDetailCmbViewModel.SelectedEmployeeType == null ||
                AssociatedEmployeeDetailCmbViewModel.SelectedEmployeeStatus == null ||
                AssociatedEmployeeDetailCmbViewModel.SelectedExperienceLevel == null)
            {
                return "Error";
            }

            var employee = new GardenGlory.EfClasses.Employee();
            employee.EmployeeId = new EmployeeDefaultValueGenerator(new GardenGloryContext())
                      .EmployeePrimaryKeyGenerator();
            employee.ExperienceLevelId = AssociatedEmployeeDetailCmbViewModel.SelectedExperienceLevel.ExperienceLevelId;
            employee.EmployeeStatusId = AssociatedEmployeeDetailCmbViewModel.SelectedEmployeeStatus.EmployeeStatusId;
            if (AssociatedEmployeeDetailCmbViewModel.SelectedEmployee !=null)
            {
                employee.SupervisorId = AssociatedEmployeeDetailCmbViewModel.SelectedEmployee.EmployeeId;
                AssociatedEmployeeViewModel.SupervisorId = AssociatedEmployeeDetailCmbViewModel.SelectedEmployee.EmployeeId;
            }
            else
            {
                employee.SupervisorId = null;
                AssociatedEmployeeViewModel.SupervisorId = null;
            }
           
            employee.EmployeeTypeId = AssociatedEmployeeDetailCmbViewModel.SelectedEmployeeType.EmployeeTypeId;
            employee.LastName = AssociatedEmployeeViewModel.LastName;
            employee.FirstName = AssociatedEmployeeViewModel.FirstName;
            employee.CellPhone = AssociatedEmployeeViewModel.CellPhone;
            employee.TotalHourrsWorked = Convert.ToDouble(AssociatedEmployeeViewModel.TotalHoursWorked);
            employee.IsDeleted = false;

            AssociatedEmployeeViewModel.EmployeeId = employee.EmployeeId;
            AssociatedEmployeeViewModel.ExperienceLevelId = employee.ExperienceLevelId;
            AssociatedEmployeeViewModel.EmployeeStatusId = employee.EmployeeStatusId;
            AssociatedEmployeeViewModel.EmployeeTypeId = employee.EmployeeTypeId;

            AssociatedEmployeeViewModel.ExperienceLevel = AssociatedEmployeeDetailCmbViewModel.SelectedExperienceLevel.Level;
            AssociatedEmployeeViewModel.EmployeeStatus = AssociatedEmployeeDetailCmbViewModel.SelectedEmployeeStatus.Status;
            AssociatedEmployeeViewModel.EmployeeType = AssociatedEmployeeDetailCmbViewModel.SelectedEmployeeType.Type;


            _employeeServices.EmployeeService.AddEmployee(employee);

            _employeeListViewModel.EmployeeList.Insert(0, AssociatedEmployeeViewModel);
            return "New Employee is added successfully";

        }

    }


    public class EmployeeDetails
    {
        public EmployeeDetails(Task task)
        {
            ServiceId = task.ServiceId;
            TaskName = task.TaskName;
            DateConducted = task.DateConducted.ToShortDateString();
            HoursWorked = task.HoursWorked.ToString();
        }
        public string ServiceId { get; set; }
        public string TaskName { get; set; }
        public string DateConducted { get; set; }
        public string HoursWorked { get; set; }
    }

}
