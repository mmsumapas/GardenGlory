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
using ServiceLayer;
using ServiceLayer.MultipleServices;

namespace GardenGloryWpf.View.Customer
{
    /// <summary>
    /// Interaction logic for CustomerEditView.xaml
    /// </summary>
    public partial class CustomerEditView : Window
    {
        public CustomerEditView()
        {
            InitializeComponent();
        }

        private EditCustomerViewModel _editCustomer;

        public CustomerEditView(CustomerViewModel editCutstomer, OwnerOwnerTypeService ownerOwnerTypeService, OwnerTypeCmbViewModel ownerTypeCmbViewModel): this()
        {
            _editCustomer = new EditCustomerViewModel(editCutstomer, ownerOwnerTypeService, ownerTypeCmbViewModel);
            DataContext = _editCustomer;
        }

        private void CSave_Click(object sender, RoutedEventArgs e)
        {
           var editCustomer = _editCustomer.Edit();
           if (editCustomer == "Error")
           {
               MessageBox.Show("Make sure to supply all necessary information provided!");
           }
           else
           {
               Close();
           }
           
        }

        private void CCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CmbOwnerType_OnPreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back || e.Key == Key.Space)
            {
                CmbOwnerType.IsDropDownOpen = true;
                var cmb = CmbOwnerType.GetBindingExpression(ComboBox.TextProperty);
                cmb.UpdateSource();
            }
            if (e.Key == Key.Up && CmbOwnerType.IsDropDownOpen)
            {
                if (CmbOwnerType.SelectedIndex != -1)
                {
                    CmbOwnerType.SelectedIndex = CmbOwnerType.SelectedIndex - 1;
                    if (CmbOwnerType.SelectedIndex == -1)
                    {
                        var cmb = CmbOwnerType.GetBindingExpression(ComboBox.TextProperty);
                        cmb.UpdateSource();
                    }
                }
            }

            if (e.Key == Key.Down && CmbOwnerType.IsDropDownOpen)
            {
                if (CmbOwnerType.SelectedIndex < CmbOwnerType.Items.Count)
                {
                    CmbOwnerType.SelectedIndex = CmbOwnerType.SelectedIndex + 1;
                }
            }
        }

        private void CmbOwnerType_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CmbOwnerType.IsDropDownOpen = true;
            var cmb = CmbOwnerType.GetBindingExpression(ComboBox.TextProperty);
            cmb.UpdateSource();
        }
    }
}
