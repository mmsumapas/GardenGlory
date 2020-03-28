using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GardenGloryWpf.ViewModel.Account;
using GardenGloryWpf.ViewModel.CmbViewModel;
using ServiceLayer.MultipleServices;

namespace GardenGloryWpf.View.Account
{
    /// <summary>
    /// Interaction logic for EditAccountHomeView.xaml
    /// </summary>
    public partial class EditAccountHomeView : Window
    {
        public EditAccountHomeView()
        {
            InitializeComponent();
        }
        private EditAccountViewModel _editAccount;
        private GardenGlory.EfClasses.Account _account;
        public EditAccountHomeView(AccountViewModel accountViewModel,RoleCmbViewModel roleCmbViewModel, AccountRoleService accountRoleService, GardenGlory.EfClasses.Account account,string tab) : this()
        {
            _editAccount = new EditAccountViewModel(accountViewModel, roleCmbViewModel, accountRoleService, tab);
            _account = account;
            DataContext = _editAccount;
        }

        private void EditAccountSave_Click(object sender, RoutedEventArgs e)
        {
            var editAccount = _editAccount.Edit();
            _account.Password = _editAccount.Password;
            _account.Username = _editAccount.Username;
            MessageBox.Show("Account Edit successful!");
            Close();
        }

        private void EditAccountCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
