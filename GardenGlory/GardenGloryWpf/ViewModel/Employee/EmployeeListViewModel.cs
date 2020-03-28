using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using GardenGlory.Context;
using ServiceLayer;

namespace GardenGloryWpf.ViewModel.Employee
{
    public class EmployeeListViewModel
    {
        private EmployeeService _employeeService;

        private string _searchText;

        public EmployeeListViewModel(EmployeeService employeeService)
        {
            _employeeService = employeeService;


            EmployeeList = new ObservableCollection<EmployeeViewModel>(_employeeService.GetEmployees().Select(c=> new EmployeeViewModel(c, new TaskService(new GardenGloryContext()))));

        }

        public void SearchEmployee(string searchString)
        {
            EmployeeList.Clear();
            var employees = _employeeService.GetEmployees().Where(c =>
                (c.LastName.Contains(searchString) ||
                 c.FirstName.Contains(searchString) ||
                 c.EmployeeId.Contains(searchString)) && c.IsDeleted != true);

            foreach (var employee in employees)
            {
                var employeeModel = new EmployeeViewModel(employee,new TaskService(new GardenGloryContext()));
                    EmployeeList.Add(employeeModel);
            }

        }
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                SearchEmployee(_searchText);
            }

        }



        public ObservableCollection<EmployeeViewModel> EmployeeList { get;  }
        public  EmployeeViewModel SelectedEmployee { get; set; }
    }
}
