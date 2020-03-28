using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using GardenGlory.EfClasses;
using GardenGloryWpf.ViewModel.Employee;
using ServiceLayer.MultipleServices;

namespace GardenGloryWpf.CmbViewModel
{
    public class EmployeeDetailCmbViewModel
    {
        private string _searchEmployeeStatusText;
        private string _searchEmployeeTypeText;
        private string _searchExperienceLevelText;
        private string _searchEmployeeText;

        private EmployeeExperienceLevelEmployeeStatusEmployeeTypeService _employeeServices;
        public EmployeeViewModel AssociatedEmployeeViewModel { get; }
        private string _restriction { get; set; }

        public EmployeeDetailCmbViewModel(EmployeeViewModel employeeViewModel,EmployeeExperienceLevelEmployeeStatusEmployeeTypeService employeeServices )
        {
            AssociatedEmployeeViewModel = employeeViewModel;
            _employeeServices = employeeServices;
            ExperienceLevels = new ObservableCollection<ExperienceLevel>(_employeeServices.ExperienceLevelService.GetExperienceLevels());
            EmployeeStatuses = new ObservableCollection<EmployeeStatus>(_employeeServices.EmployeeStatusService.GetEmployeeStatuses());
            EmployeeTypes = new ObservableCollection<EmployeeType>(_employeeServices.EmployeeTypeService.GetEmployeeTypes());
            Employees = new ObservableCollection<Employee>(_employeeServices.EmployeeService.GetEmployees());

            SelectedExperienceLevel =
                ExperienceLevels.First(c => c.ExperienceLevelId == AssociatedEmployeeViewModel.ExperienceLevelId);
            SelectedEmployeeStatus =
                EmployeeStatuses.First(c => c.EmployeeStatusId == AssociatedEmployeeViewModel.EmployeeStatusId);
            SelectedEmployeeType =
                EmployeeTypes.First(c => c.EmployeeTypeId == AssociatedEmployeeViewModel.EmployeeTypeId);
            SelectedEmployee = Employees.First(c => c.EmployeeId == AssociatedEmployeeViewModel.EmployeeId);
        }
        //public EmployeeDetailCmbViewModel(EmployeeViewModel employeeViewModel, EmployeeExperienceLevelEmployeeStatusEmployeeTypeService employeeServices, string restriction)
        //{
        //    AssociatedEmployeeViewModel = employeeViewModel;
        //    _employeeServices = employeeServices;
        //    _restriction = restriction;
        //    ExperienceLevels = new ObservableCollection<ExperienceLevel>(_employeeServices.ExperienceLevelService.GetExperienceLevels());
        //    EmployeeStatuses = new ObservableCollection<EmployeeStatus>(_employeeServices.EmployeeStatusService.GetEmployeeStatuses());
        //    EmployeeTypes = new ObservableCollection<EmployeeType>(_employeeServices.EmployeeTypeService.GetEmployeeTypesWithRestriction(_restriction));
        //    Employees = new ObservableCollection<Employee>(_employeeServices.EmployeeService.GetEmployees());

        //    SelectedExperienceLevel =
        //        ExperienceLevels.First(c => c.ExperienceLevelId == AssociatedEmployeeViewModel.ExperienceLevelId);
        //    SelectedEmployeeStatus =
        //        EmployeeStatuses.First(c => c.EmployeeStatusId == AssociatedEmployeeViewModel.EmployeeStatusId);
        //    SelectedEmployeeType =
        //        EmployeeTypes.First(c => c.EmployeeTypeId == AssociatedEmployeeViewModel.EmployeeTypeId);
        //    SelectedEmployee = Employees.First(c => c.EmployeeId == AssociatedEmployeeViewModel.EmployeeId);
        //}
        public EmployeeDetailCmbViewModel(EmployeeExperienceLevelEmployeeStatusEmployeeTypeService employeeServices)
        {
            _employeeServices = employeeServices;
            ExperienceLevels = new ObservableCollection<ExperienceLevel>(_employeeServices.ExperienceLevelService.GetExperienceLevels());
            EmployeeStatuses = new ObservableCollection<EmployeeStatus>(_employeeServices.EmployeeStatusService.GetEmployeeStatuses());
            EmployeeTypes = new ObservableCollection<EmployeeType>(_employeeServices.EmployeeTypeService.GetEmployeeTypes());
            Employees = new ObservableCollection<Employee>(_employeeServices.EmployeeService.GetEmployees());
        }
        //public EmployeeDetailCmbViewModel(EmployeeExperienceLevelEmployeeStatusEmployeeTypeService employeeServices, string restriction)
        //{
        //    _employeeServices = employeeServices;
        //    _restriction = restriction;
        //    ExperienceLevels = new ObservableCollection<ExperienceLevel>(_employeeServices.ExperienceLevelService.GetExperienceLevels());
        //    EmployeeStatuses = new ObservableCollection<EmployeeStatus>(_employeeServices.EmployeeStatusService.GetEmployeeStatuses());
        //    EmployeeTypes= new ObservableCollection<EmployeeType>(_employeeServices.EmployeeTypeService.GetEmployeeTypes());
        //       // EmployeeTypesGenerator(EmployeeTypes,_restriction);
                
        //    Employees = new ObservableCollection<Employee>(_employeeServices.EmployeeService.GetEmployees());
        //}
        public string SearchExperienceLevelText
        {
            get => _searchExperienceLevelText;
            set
            {
                _searchExperienceLevelText = value;
                if (_searchExperienceLevelText == null)
                {
                    _searchExperienceLevelText = "";
                    SearchExperienceLevel(_searchExperienceLevelText);
                }
                else
                {
                    SearchExperienceLevel(_searchExperienceLevelText);
                }

            }
        }
        public string SearchEmployeeTypeText
        {
            get => _searchEmployeeTypeText;
            set
            {
                _searchEmployeeTypeText = value;
                if (_searchEmployeeTypeText == null)
                {
                    _searchEmployeeTypeText = "";
                    SearchEmployeeType(_searchEmployeeTypeText);
                }
                else
                {
                    SearchEmployeeType(_searchEmployeeTypeText);
                }
            }
        }
        public string SearchEmployeeStatusText
        {
            get => _searchEmployeeStatusText;
            set
            {
                _searchEmployeeStatusText = value;
                if (_searchEmployeeStatusText == null)
                {
                    _searchEmployeeStatusText = "";
                    SearchEmployeeStatus(_searchEmployeeStatusText);
                }
                else
                {
                    SearchEmployeeStatus(_searchEmployeeStatusText);
                }
            }
        }
        public string SearchEmployeeText
        {
            get => _searchEmployeeText;
            set
            {
                _searchEmployeeText = value;
                if (_searchEmployeeText == null)
                {
                    _searchEmployeeText = "";
                    SearchEmployee(_searchEmployeeText);
                }
                else
                {
                    SearchEmployee(_searchEmployeeText);
                }
            }
        }


        public void SearchEmployee(string searchText)
        {
            var employees = _employeeServices.EmployeeService.GetEmployees().Where(c =>
                (c.LastName.Contains(searchText) || c.FirstName.Contains(searchText))
                && c.IsDeleted != true);
            Employees.Clear();
            foreach (var employee in employees)
            {
                Employees.Add(employee);

            }
        }
        public void SearchExperienceLevel(string searchText)
        {
            var experienceLevels = _employeeServices.ExperienceLevelService.GetExperienceLevels().Where(c =>
                c.Level.Contains(searchText));
            ExperienceLevels.Clear();
            foreach (var experienceLevel in experienceLevels)
            {
                ExperienceLevels.Add(experienceLevel);
            }
        }
        public void SearchEmployeeStatus(string searchText)
        {
            var employeeStatuses = _employeeServices.EmployeeStatusService.GetEmployeeStatuses().Where(c =>
                c.Status.Contains(searchText) );
            EmployeeStatuses.Clear();
            foreach (var employeeStatus in employeeStatuses)
            {
                EmployeeStatuses.Add(employeeStatus);
            }
        }
        public void SearchEmployeeType(string searchText)
        {
            var employeeTypes = _employeeServices.EmployeeTypeService.GetEmployeeTypes()
                .Where(c => c.Type.Contains(searchText));
            EmployeeTypes.Clear();
            foreach (var employeeType in employeeTypes)
            {
                EmployeeTypes.Add(employeeType);
            }
        }

        public ObservableCollection<ExperienceLevel> ExperienceLevels { get; set; }
        public ObservableCollection<EmployeeStatus> EmployeeStatuses { get; set; }
        public ObservableCollection<EmployeeType> EmployeeTypes { get; set; }
        public ObservableCollection<GardenGlory.EfClasses.Employee> Employees { get; set; }
        public GardenGlory.EfClasses.Employee SelectedEmployee { get; set; }
        public ExperienceLevel SelectedExperienceLevel { get; set; }
        public EmployeeStatus SelectedEmployeeStatus { get; set; }

        public EmployeeType SelectedEmployeeType { get; set; }
    }
}
