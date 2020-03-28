using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GardenGlory.Context;
using GardenGlory.EfClasses;
using GardenGloryWpf.CmbViewModel;
using GardenGloryWpf.View.Account;
using GardenGloryWpf.View.Customer;
using GardenGloryWpf.View.Employee;
using GardenGloryWpf.View.Equipment;
using GardenGloryWpf.View.Property;
using GardenGloryWpf.View.Service;
using GardenGloryWpf.ViewModel.Account;
using GardenGloryWpf.ViewModel.CmbViewModel;
using GardenGloryWpf.ViewModel.Customer;
using GardenGloryWpf.ViewModel.Employee;
using GardenGloryWpf.ViewModel.Equipment;
using GardenGloryWpf.ViewModel.Home;
using GardenGloryWpf.ViewModel.Property;
using GardenGloryWpf.ViewModel.Service;
using MaterialDesignThemes.Wpf.Converters;
using ServiceLayer;
using ServiceLayer.MultipleServices;

namespace GardenGloryWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CustomerListViewModel _customerListViewModel;
        private OwnerOwnerTypeService _ownerOwnerTypeService;

        private AccountListViewModel _accountListViewModel;
        private AccountRoleService _accountRoleService;

        private EmployeeListViewModel _employeeListViewModel;
        private EmployeeExperienceLevelEmployeeStatusEmployeeTypeService _employeeServices;

        private ServiceListViewModel _serviceListViewModel;
        private ServiceServiceTypeService _serviceServiceTypeService;

        private PropertyListViewModel _propertyListViewModel;
        private PropertyPropertyDescriptionService _propertyPropertyDescriptionService;

        private EquipmentListViewModel _equipmentListViewModel;
        private EquipmentService _equipmentService;
        public MainWindow()
        {
            InitializeComponent();

            TabControlVisibilityCollapsed();

             _ownerOwnerTypeService = new OwnerOwnerTypeService(new GardenGloryContext());
            _customerListViewModel = new CustomerListViewModel(_ownerOwnerTypeService.OwnerService);
            CustomerTab.DataContext = _customerListViewModel;

            _employeeServices = new EmployeeExperienceLevelEmployeeStatusEmployeeTypeService(new GardenGloryContext());
            _employeeListViewModel = new EmployeeListViewModel(_employeeServices.EmployeeService);
            EmployeeTab.DataContext = _employeeListViewModel;

            _accountRoleService = new AccountRoleService(new GardenGloryContext());
            _accountListViewModel = new AccountListViewModel(_accountRoleService.AccountService);
            AccountTab.DataContext = _accountListViewModel;

           _serviceServiceTypeService = new ServiceServiceTypeService(new GardenGloryContext());
            _serviceListViewModel = new ServiceListViewModel(_serviceServiceTypeService.ServiceService);
            ServiceTab.DataContext = _serviceListViewModel;

            _propertyPropertyDescriptionService = new PropertyPropertyDescriptionService(new GardenGloryContext());
            _propertyListViewModel = new PropertyListViewModel(_propertyPropertyDescriptionService.PropertyService);
            PropertyTab.DataContext = _propertyListViewModel;

            _equipmentService = new EquipmentService(new GardenGloryContext());
            _equipmentListViewModel = new EquipmentListViewModel(_equipmentService);
            EquipmentTab.DataContext = _equipmentListViewModel;

        }

        #region Customer

        private void CustomerEdit_Click(object sender, RoutedEventArgs e)
        {
            if (_customerListViewModel.SelectedCustomer == null) return;
            var editWindow = new CustomerEditView(_customerListViewModel.SelectedCustomer, _ownerOwnerTypeService, new OwnerTypeCmbViewModel(_customerListViewModel.SelectedCustomer,_ownerOwnerTypeService.OwnerTypeService));
            editWindow.Show();
        }

        private void CustomerDelete_Click(object sender, RoutedEventArgs e)
        {
            if (_customerListViewModel.SelectedCustomer == null) return;
            _ownerOwnerTypeService.OwnerService.RemoveOwner(_customerListViewModel.SelectedCustomer.OwnerId);
            _customerListViewModel.CustomerList.Remove(_customerListViewModel.SelectedCustomer);
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {

            var addWindow = new AddCustomerView(_customerListViewModel, _ownerOwnerTypeService,_serviceServiceTypeService, _propertyPropertyDescriptionService, new OwnerTypeCmbViewModel(_ownerOwnerTypeService.OwnerTypeService), new ServiceTypeCmbViewModel(_serviceServiceTypeService.ServiceTypeService) );
            addWindow.Show();
        }
        #endregion

        #region Property

        private void PropertyEdit_Click(object sender, RoutedEventArgs e)
        {
            if (_propertyListViewModel.SelectedProperty == null) return;
            var editWindow = new EditPropertyView(_propertyListViewModel.SelectedProperty, _propertyPropertyDescriptionService.PropertyService);
            editWindow.Show();
        }

        private void PropertyDelete_Click(object sender, RoutedEventArgs e)
        {
            if (_propertyListViewModel.SelectedProperty == null) return;
            _propertyPropertyDescriptionService.PropertyService.RemoveProperty(_propertyListViewModel.SelectedProperty.PropertyId);
            _propertyListViewModel.PropertyList.Remove(_propertyListViewModel.SelectedProperty);
        }

        private void AddProperty(object sender, RoutedEventArgs e)
        {

            var addWindow = new AddPropertyView(_propertyListViewModel, _propertyPropertyDescriptionService, new OwnerCmbViewModel(new OwnerService(new GardenGloryContext())));
            addWindow.Show();
        }
        private void AddParentProperty_Click(object sender, RoutedEventArgs e)
        {
            if (_propertyListViewModel.SelectedProperty == null) return;
            var addWindow = new AddPropertyDescriptionView(_propertyListViewModel.SelectedProperty, new PropertyDescriptionService(new GardenGloryContext()));
            addWindow.Show();
        }
        #endregion

        #region Service

        private void ServiceEdit_Click(object sender, RoutedEventArgs e)
        {
            if (_serviceListViewModel.SelectedService == null) return;
            var editWindow = new EditServiceView(_serviceListViewModel.SelectedService, _serviceServiceTypeService, new ServiceTypeCmbViewModel(_serviceListViewModel.SelectedService,_serviceServiceTypeService.ServiceTypeService));
            editWindow.Show();
        }

        private void ServiceDelete_Click(object sender, RoutedEventArgs e)
        {
            if (_serviceListViewModel.SelectedService == null) return;
            _serviceServiceTypeService.ServiceService.RemoveService(_serviceListViewModel.SelectedService.ServiceId);
            _serviceListViewModel.ServiceList.Remove(_serviceListViewModel.SelectedService);
        }
        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            if (_serviceListViewModel.SelectedService == null) return;
            var addWindow = new AddTaskView(_serviceListViewModel.SelectedService ,new TaskService(new GardenGloryContext()),
                new EquipmentCmbViewModel(new EquipmentService(new GardenGloryContext())), 
                new EmployeeDetailCmbViewModel(new EmployeeExperienceLevelEmployeeStatusEmployeeTypeService(new GardenGloryContext())));
            addWindow.Show();
       

        }
        private void AddPayment_Click(object sender, RoutedEventArgs e)
        {
            if (_serviceListViewModel.SelectedService == null) return;
            var addWindow = new AddPaymentView(_serviceListViewModel.SelectedService, new PaymentService(new GardenGloryContext()), new PaymentMethodCmbViewModel(new PaymentMethodService(new GardenGloryContext())));
            addWindow.Show();
        }
        private void AddService_Click(object sender, RoutedEventArgs e)
        {

            var addWindow = new AddServiceView(_serviceListViewModel, _serviceServiceTypeService, new ServiceTypeCmbViewModel(_serviceServiceTypeService.ServiceTypeService), new PropertyCmbViewModel(new PropertyService(new GardenGloryContext())) );
            addWindow.Show();

        }
        #endregion

        #region Equipment

        private void EquipmentEdit_Click(object sender, RoutedEventArgs e)
        {
            if (_equipmentListViewModel.SelectedEquipment == null) return;
            var editWindow = new EditEquipmentView(_equipmentListViewModel.SelectedEquipment, _equipmentService);
            editWindow.Show();
        }

        private void EquipmentDelete_Click(object sender, RoutedEventArgs e)
        {
            if (_equipmentListViewModel.SelectedEquipment == null) return;
            _equipmentService.RemoveEquipment(_equipmentListViewModel.SelectedEquipment.EquipmentId);
            _equipmentListViewModel.EquipmentList.Remove(_equipmentListViewModel.SelectedEquipment);
        }
        private void AddEquipmentRepair_Click(object sender, RoutedEventArgs e)
        {
            if (_equipmentListViewModel.SelectedEquipment == null) return;
            var addWindow = new AddEquipmentRepairView(_equipmentListViewModel.SelectedEquipment, new EquipmentRepairService(new GardenGloryContext()));
            addWindow.Show();
        }
        private void AddTrainedEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (_equipmentListViewModel.SelectedEquipment == null) return;
            var addWindow = new AddTrainedEmployeeView(_equipmentListViewModel.SelectedEquipment,
                new TrainedEmployeeService(new GardenGloryContext()), new EmployeeDetailCmbViewModel(new EmployeeExperienceLevelEmployeeStatusEmployeeTypeService(new GardenGloryContext())));
            addWindow.Show();
        }

        private void AddEquipment_Click(object sender, RoutedEventArgs e)
        {

            var addWindow = new AddEquipmentView(_equipmentListViewModel, _equipmentService);
            addWindow.Show();
        }
        #endregion

        #region Employee
        private void EmployeeEdit_Click(object sender, RoutedEventArgs e)
        {
            if (_employeeListViewModel.SelectedEmployee == null) return;
            var editWindow = new EditEmployeeView(_employeeListViewModel.SelectedEmployee, _employeeServices, new EmployeeDetailCmbViewModel(_employeeListViewModel.SelectedEmployee, _employeeServices), _restrictionType);
            editWindow.Show();
        }

        private void EmployeeDelete_Click(object sender, RoutedEventArgs e)
        {
            if (_employeeListViewModel.SelectedEmployee == null) return;
                _employeeServices.EmployeeService.RemoveEmployee(_employeeListViewModel.SelectedEmployee.EmployeeId);
            _employeeListViewModel.EmployeeList.Remove(_employeeListViewModel.SelectedEmployee);
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {

            var addWindow = new AddEmployeeView(_employeeListViewModel, _employeeServices, new EmployeeDetailCmbViewModel(_employeeServices), _restrictionType);
            addWindow.Show();
        }
        #endregion

        #region Account
        private void AccountEdit_Click(object sender, RoutedEventArgs e)
        {
            if (_accountListViewModel.SelectedAccount == null) return;
            var editWindow = new EditAccountView(_accountListViewModel.SelectedAccount, new RoleCmbViewModel(_accountListViewModel.SelectedAccount, _accountRoleService.RoleService), _accountRoleService,"Account");
            editWindow.Show();
        }

        private void AccountDelete_Click(object sender, RoutedEventArgs e)
        {
            if (_accountListViewModel.SelectedAccount == null) return;
            _accountRoleService.AccountService.RemoveAccount(_accountListViewModel.SelectedAccount.AccountId);
            _accountListViewModel.AccountList.Remove(_accountListViewModel.SelectedAccount);
        }

        private void AddAccount_Click(object sender, RoutedEventArgs e)
        {

            var addWindow = new AddAccountView(_accountListViewModel, _accountRoleService, new RoleCmbViewModel( _accountRoleService.RoleService),new EmployeeDetailCmbViewModel(new EmployeeExperienceLevelEmployeeStatusEmployeeTypeService(new GardenGloryContext())));
            addWindow.Show();
        }
        private void EditAccount_Click(object sender, RoutedEventArgs e)
        {
            var accountViewModel = new AccountViewModel(account);
            var editWindow = new EditAccountHomeView(accountViewModel, new RoleCmbViewModel(accountViewModel, _accountRoleService.RoleService), _accountRoleService, account,"Home");
            editWindow.Show();
        }
        #endregion

        #region Home
        private string _restrictionType;
        private Account account;
        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            if(txtHomePassword == null || txtHomePassword == null) return;
            var context = new GardenGloryContext();
            var usernameSplit = txtHomeUsername.ToString().Split(": ");
            var passwordSplit = txtHomePassword.ToString().Split(": ");
            string username = usernameSplit[1];
            string password = passwordSplit[1];
            var homeModel = new HomeViewModel(context, new AccountService(context), username, password, txtUser, txtUserRole);
            _restrictionType = homeModel.RestrictionType;
            account = homeModel.Account;
            if (_restrictionType == "Error")
            {
                MessageBox.Show("Incorrect Username or Password!");
            }
            else
            {
                AccessRestrictions(homeModel.RestrictionType);
                LogInHomeVisibilityCollapesed();
            }
           

        }
        #endregion

        #region DisplayMethod

        private void AccessRestrictions(string accessChecker)
        {
            switch (accessChecker)
            {
                case "RICD":
                    TabControlVisibilityVisibleWithoutAccountTab();
                    ButtonPerTabVisilibilityVisilble();
                    break;
                case "RIC":
                    TabControlVisibilityVisibleWithoutAccountTab();
                    ButtonPerTabVisilibilityCollapsed();
                    break;
                case "ALL":
                    TabControlVisibilityVisibleWithoutAccountTab();
                    AccountTab.Visibility = Visibility.Visible;

                    ButtonPerTabVisilibilityVisilble();
                    break;
                default:
                    MessageBox.Show(accessChecker);
                    break;

            }
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            TabControlVisibilityCollapsed();

            LabelUsername.Visibility = Visibility.Visible;
            LabelPassword.Visibility = Visibility.Visible;
            txtHomeUsername.Visibility = Visibility.Visible;
            txtHomeUsername.Text = "";
            txtHomePassword.Visibility = Visibility.Visible;
            txtHomePassword.Text = "";
            LogInButton.Visibility = Visibility.Visible;
        }

        public void ButtonPerTabVisilibilityVisilble()
        {
            CustomerDelete.Visibility = Visibility.Visible;
            PropertyDelete.Visibility = Visibility.Visible;
            ServiceDelete.Visibility = Visibility.Visible;
            EquipmentDelete.Visibility = Visibility.Visible;
            EmployeeDelete.Visibility = Visibility.Visible;
        }

        public void ButtonPerTabVisilibilityCollapsed()
        {
            CustomerDelete.Visibility = Visibility.Collapsed;
            PropertyDelete.Visibility = Visibility.Collapsed;
            ServiceDelete.Visibility = Visibility.Collapsed;
            EquipmentDelete.Visibility = Visibility.Collapsed;
            EmployeeDelete.Visibility = Visibility.Collapsed;
        }

        public void TabControlVisibilityCollapsed()
        {
            LogOutButton.Visibility = Visibility.Collapsed;
            LabelUser.Visibility = Visibility.Collapsed;
            LabelUserRole.Visibility = Visibility.Collapsed;
            txtUser.Visibility = Visibility.Collapsed;
            txtUserRole.Visibility = Visibility.Collapsed;
            EditAccount.Visibility = Visibility.Collapsed;


            CustomerTab.Visibility = Visibility.Collapsed;
            PropertyTab.Visibility = Visibility.Collapsed;
            ServiceTab.Visibility = Visibility.Collapsed;
            EquipmentTab.Visibility = Visibility.Collapsed;
            EmployeeTab.Visibility = Visibility.Collapsed;
            AccountTab.Visibility = Visibility.Collapsed;
        }

        public void TabControlVisibilityVisibleWithoutAccountTab()
        {
            CustomerTab.Visibility = Visibility.Visible;
            PropertyTab.Visibility = Visibility.Visible;
            ServiceTab.Visibility = Visibility.Visible;
            EquipmentTab.Visibility = Visibility.Visible;
            EmployeeTab.Visibility = Visibility.Visible;
        }

        public void LogInHomeVisibilityCollapesed()
        {
            LabelUsername.Visibility = Visibility.Collapsed;
            LabelPassword.Visibility = Visibility.Collapsed;
            txtHomeUsername.Visibility = Visibility.Collapsed;
            txtHomePassword.Visibility = Visibility.Collapsed;
            LogInButton.Visibility = Visibility.Collapsed;

            LogOutButton.Visibility = Visibility.Visible;
            LabelUser.Visibility = Visibility.Visible;
            LabelUserRole.Visibility = Visibility.Visible;
            txtUser.Visibility = Visibility.Visible;
            txtUserRole.Visibility = Visibility.Visible;
            EditAccount.Visibility = Visibility.Visible;

        }
        #endregion

        #region Refresh
        private void CustomerRefresh_Click(object sender, RoutedEventArgs e)
        {
            _customerListViewModel = new CustomerListViewModel(new OwnerService(new GardenGloryContext()));
            CustomerTab.DataContext = _customerListViewModel;
        }

        private void EmployeeRefresh_Click(object sender, RoutedEventArgs e)
        {
            _employeeListViewModel = new EmployeeListViewModel(new EmployeeService(new GardenGloryContext()));
            EmployeeTab.DataContext = _employeeListViewModel;
        }

        private void EquipmentRefresh_Click(object sender, RoutedEventArgs e)
        {
            _equipmentListViewModel = new EquipmentListViewModel(new EquipmentService(new GardenGloryContext()));
            EquipmentTab.DataContext = _equipmentListViewModel;
        }

        private void ListViewPropertyDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedIndex = ListViewPropertyDetails.SelectedIndex;
            var editWindow = new EditPropertyDescriptionView(_propertyListViewModel.SelectedProperty, _propertyPropertyDescriptionService.PropertyDescriptionService,selectedIndex);
            if (account.RoleLink.RoleType == "Assistant")
            {
                editWindow.DeletePropertyDescription.Visibility = Visibility.Collapsed;
            }
            else
            {
                editWindow.DeletePropertyDescription.Visibility = Visibility.Visible;
            }
            editWindow.Show();
        }

        #endregion
    }
}
 