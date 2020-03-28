using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using GardenGlory.Context;
using GardenGlory.DefaultValueGenerator;
using GardenGlory.EfClasses;
using GardenGloryWpf.Annotations;
using GardenGloryWpf.CmbViewModel;
using GardenGloryWpf.ViewModel.CmbViewModel;
using GardenGloryWpf.ViewModel.Customer;
using ServiceLayer;
using ServiceLayer.MultipleServices;

namespace GardenGloryWpf.ViewModel.Account
{
    public class AccountViewModel : INotifyPropertyChanged
    {
        private string _accouuntId;
        private string _employeeId;
        private string _role;
        private string _username;
        private string _password;
        private string _employeeFirstName;
        private string _employeeLastName;

        public AccountViewModel()
        {

        }

        public string AccountId
        {
            get { return _accouuntId; }
            set
            {
                _accouuntId = value;
                OnPropertyChanged(nameof(AccountId));
            }
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

        public string Role
        {
            get { return _role; }
            set
            {
                _role = value;
                OnPropertyChanged(nameof(Role));
            }
        }

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string EmployeeFirstName
        {
            get { return _employeeFirstName; }
            set
            {
                _employeeFirstName = value;
                OnPropertyChanged(nameof(EmployeeFirstName));
            }
        }

        public string EmployeeLastName
        {
            get { return _employeeLastName; }
            set
            {
                _employeeLastName = value;
                OnPropertyChanged(nameof(EmployeeLastName));
            }
        }
        public string RoleId { get; set; }

        public AccountViewModel(GardenGlory.EfClasses.Account account)
        {
            AccountId = account.AccountId;
            EmployeeId = account.EmployeeId;
            RoleId = account.RoleLink.RoleId;
            Role = account.EmployeeLink.EmployeeTypeLink.Type;
            Username = account.Username;
            Password = account.Password;
            var context = new GardenGloryContext();

            var employee = context.Employees.Find(account.EmployeeId);
            EmployeeFirstName = employee.FirstName;
            EmployeeLastName = employee.LastName;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class EditAccountViewModel
    {
        private AccountRoleService _accountRoleService;
        private string _tab;

        public EditAccountViewModel(AccountViewModel accountViewModel, RoleCmbViewModel roleCmbViewModel,AccountRoleService accountRoleService, string tab)
        {
            AssociatedAccountViewModel = accountViewModel;
            AssociatedRoleCmbViewModel = roleCmbViewModel;
            _tab = tab;
            _accountRoleService = accountRoleService;
            if (_tab == "Home")
            {
                EditableFields(accountViewModel);
            }
        }
       
        private void EditableFields(AccountViewModel accountModel)
        {
            Username = accountModel.Username;
            Password = accountModel.Password;
        }


        public AccountViewModel AssociatedAccountViewModel { get; }
        public RoleCmbViewModel AssociatedRoleCmbViewModel { get; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string Edit()
        {

            if (_tab == "Home")
            {
                AssociatedAccountViewModel.Username = Username;
                AssociatedAccountViewModel.Password = Password;
            }

            if (AssociatedRoleCmbViewModel.SelectedRole == null)
            {

                _accountRoleService.AccountService.UpdateAccount(AssociatedAccountViewModel.AccountId, AssociatedAccountViewModel.RoleId,
                    AssociatedAccountViewModel.Username, AssociatedAccountViewModel.Password);
            }
            else
            {
                AssociatedAccountViewModel.Role = AssociatedRoleCmbViewModel.SelectedRole.RoleType;
                AssociatedAccountViewModel.RoleId = AssociatedRoleCmbViewModel.SelectedRole.RoleId;

                _accountRoleService.AccountService.UpdateAccount(AssociatedAccountViewModel.AccountId, AssociatedAccountViewModel.RoleId,
                    AssociatedAccountViewModel.Username, AssociatedAccountViewModel.Password);

            }

            return "";
        }
    }
    public class AddAcccountViewModel
    {
        private readonly AccountListViewModel _accountListViewModel;
        private AccountRoleService _accountRoleService;
        
        public AddAcccountViewModel(AccountListViewModel accountListViewModel, AccountRoleService accountRoleService, RoleCmbViewModel roleCmbViewModel, EmployeeDetailCmbViewModel employeeDetailCmbView)
        {
            AssociatedAccountViewModel = new AccountViewModel();
            _accountListViewModel = accountListViewModel;
            _accountRoleService = accountRoleService;
            AssociatedEmployeeDetailCmbViewModel= employeeDetailCmbView;
            AssociatedRoleCmbViewModel = roleCmbViewModel;


        }
        public AccountViewModel AssociatedAccountViewModel { get; set; }
        public RoleCmbViewModel AssociatedRoleCmbViewModel { get;  }
        public EmployeeDetailCmbViewModel AssociatedEmployeeDetailCmbViewModel { get;  }
       
        

        public string Add()
        {
            var account = new GardenGlory.EfClasses.Account();

            var context = new GardenGloryContext();
            

            if (AssociatedEmployeeDetailCmbViewModel.SelectedEmployee !=null && AssociatedRoleCmbViewModel.SelectedRole !=null)
            {
                var accountPrimaryKey = new AccountDefaultValueGenerator(context).PrimaryKeyGenerator();
                var username = new AccountDefaultValueGenerator(context).UsernameGenerator(AssociatedEmployeeDetailCmbViewModel.SelectedEmployee.EmployeeId);
                var password = new AccountDefaultValueGenerator(context).PasswordGenerator(AssociatedEmployeeDetailCmbViewModel.SelectedEmployee.EmployeeId);

                account.AccountId = accountPrimaryKey;
                account.EmployeeId = AssociatedEmployeeDetailCmbViewModel.SelectedEmployee.EmployeeId;
                account.RoleId = AssociatedRoleCmbViewModel.SelectedRole.RoleId;
                account.Username = username;
                account.Password = password;
                account.IsDeleted = false;

                _accountRoleService.AccountService.AddAccount(account);


                _accountListViewModel.AccountList.Insert(0, AssociatedAccountViewModel);
                AssociatedAccountViewModel.AccountId = account.AccountId;
                AssociatedAccountViewModel.RoleId = account.RoleId;
                AssociatedAccountViewModel.Username = username;
                AssociatedAccountViewModel.Password = password;
                AssociatedAccountViewModel.Role = AssociatedRoleCmbViewModel.SelectedRole.RoleType;
                AssociatedAccountViewModel.EmployeeFirstName = AssociatedEmployeeDetailCmbViewModel.SelectedEmployee.FirstName;
                AssociatedAccountViewModel.EmployeeLastName = AssociatedEmployeeDetailCmbViewModel.SelectedEmployee.LastName;
                AssociatedAccountViewModel.EmployeeId = AssociatedEmployeeDetailCmbViewModel.SelectedEmployee.EmployeeId;
                return "New account is added successfully! \n" +
                       $"username: {username} \n"+
                    $"password: {password}";
            }
            else
            {
                return "Error";
            }


        }


    }

}
