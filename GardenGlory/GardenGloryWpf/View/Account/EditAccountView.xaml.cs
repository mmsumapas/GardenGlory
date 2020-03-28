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
using ServiceLayer;
using ServiceLayer.MultipleServices;

namespace GardenGloryWpf.View.Account
{
    /// <summary>
    /// Interaction logic for EditAccountView.xaml
    /// </summary>
    public partial class EditAccountView : Window
    {
        public EditAccountView()
        {
            InitializeComponent();
        }
        private EditAccountViewModel _editAccount;
        public EditAccountView(AccountViewModel accountViewModel, RoleCmbViewModel roleCmbViewModel, AccountRoleService accountRoleService, string tab) : this()
        {
            _editAccount = new EditAccountViewModel(accountViewModel, roleCmbViewModel, accountRoleService, tab);
            DataContext = _editAccount;
        }

        private void EditAccountSave_Click(object sender, RoutedEventArgs e)
        {
            var editAccount =_editAccount.Edit();
            if (editAccount == "Error")
            {
                MessageBox.Show("Make sure to provide all the necessary information provided!");
            }
            else
            {
                Close();
            }
            
        }

        private void EditAccountCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
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

        private void CmbRole_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CmbRole.IsDropDownOpen = true;
            var cmb = CmbRole.GetBindingExpression(ComboBox.TextProperty);
            cmb.UpdateSource();
        }
    }
}
