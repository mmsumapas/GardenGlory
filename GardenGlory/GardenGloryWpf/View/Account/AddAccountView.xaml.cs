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
using GardenGloryWpf.CmbViewModel;
using GardenGloryWpf.ViewModel.Account;
using GardenGloryWpf.ViewModel.CmbViewModel;
using ServiceLayer;
using ServiceLayer.MultipleServices;

namespace GardenGloryWpf.View.Account
{
    /// <summary>
    /// Interaction logic for AddAccountView.xaml
    /// </summary>
    public partial class AddAccountView : Window
    {
        public AddAccountView()
        {
            InitializeComponent();
        }
        private AddAcccountViewModel _addAcccount;
        public AddAccountView(AccountListViewModel accountListViewModel, AccountRoleService accountRoleService, RoleCmbViewModel roleCmbViewModel, EmployeeDetailCmbViewModel employeeDetailCmbView) : this()
        {
            _addAcccount = new AddAcccountViewModel(accountListViewModel, accountRoleService, roleCmbViewModel, employeeDetailCmbView);
            DataContext = _addAcccount;
        }

        private void AddAccountSave_Click(object sender, RoutedEventArgs e)
        {
            var account = _addAcccount.Add();
            if (account != "Error")
            {
                MessageBox.Show(account);
                Close();
            }
            else
            {
                MessageBox.Show("Make sure that Employee ID is existing and select Employee Role Type!");
            }
        }

        private void AddAccountCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CmbEmployee_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CmbEmployee.IsDropDownOpen = true;
            var cmb = CmbEmployee.GetBindingExpression(ComboBox.TextProperty);
            cmb.UpdateSource();
        }

        private void CmbEmployee_OnPreviewKeyUp(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Back || e.Key == Key.Space)
            {
                CmbEmployee.IsDropDownOpen = true;
                var cmb = CmbEmployee.GetBindingExpression(ComboBox.TextProperty);
                cmb.UpdateSource();
            }
            if (e.Key == Key.Up && CmbEmployee.IsDropDownOpen)
            {
                if (CmbEmployee.SelectedIndex != -1)
                {
                    CmbEmployee.SelectedIndex = CmbEmployee.SelectedIndex - 1;
                    if (CmbEmployee.SelectedIndex == -1)
                    {
                        var cmb = CmbEmployee.GetBindingExpression(ComboBox.TextProperty);
                        cmb.UpdateSource();
                    }
                }
            }

            if (e.Key == Key.Down && CmbEmployee.IsDropDownOpen)
            {
                if (CmbEmployee.SelectedIndex < CmbEmployee.Items.Count)
                {
                    CmbEmployee.SelectedIndex = CmbEmployee.SelectedIndex + 1;
                }
            }
        }

        private void CmbRole_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CmbRole.IsDropDownOpen = true;
            var cmb = CmbRole.GetBindingExpression(ComboBox.TextProperty);
            cmb.UpdateSource();
        }

        private void CmbRole_OnPreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back || e.Key == Key.Space)
            {
                CmbRole.IsDropDownOpen = true;
                var cmb = CmbRole.GetBindingExpression(ComboBox.TextProperty);
                cmb.UpdateSource();
            }
            if (e.Key == Key.Up && CmbRole.IsDropDownOpen)
            {
                if (CmbRole.SelectedIndex != -1)
                {
                    CmbRole.SelectedIndex = CmbRole.SelectedIndex - 1;
                    if (CmbRole.SelectedIndex == -1)
                    {
                        var cmb = CmbRole.GetBindingExpression(ComboBox.TextProperty);
                        cmb.UpdateSource();
                    }
                }
            }

            if (e.Key == Key.Down && CmbRole.IsDropDownOpen)
            {
                if (CmbRole.SelectedIndex < CmbRole.Items.Count)
                {
                    CmbRole.SelectedIndex = CmbRole.SelectedIndex + 1;
                }
            }
        }
    }
}
