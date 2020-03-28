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
using GardenGloryWpf.ViewModel.Customer;
using ServiceLayer;
using ServiceLayer.MultipleServices;

namespace GardenGloryWpf.View.Customer
{
    /// <summary>
    /// Interaction logic for AddCustomerView.xaml
    /// </summary>
    public partial class AddCustomerView : Window
    {
        private AddCustomerViewModel _addCustomer;
        public AddCustomerView()
        {
            InitializeComponent();
        }

        public AddCustomerView(CustomerListViewModel customerListViewModel,OwnerOwnerTypeService ownerOwnerTypeService, ServiceServiceTypeService serviceServiceTypeService, PropertyPropertyDescriptionService propertyPropertyDescriptionService, OwnerTypeCmbViewModel ownerTypeCmbViewModel, ServiceTypeCmbViewModel serviceTypeCmbViewModel) : this()
        {
            _addCustomer = new AddCustomerViewModel(customerListViewModel, ownerOwnerTypeService, serviceServiceTypeService,propertyPropertyDescriptionService, serviceTypeCmbViewModel, ownerTypeCmbViewModel);
            DataContext = _addCustomer;
        }
        private void AddCustomerSave_Click(object sender, RoutedEventArgs e)
        {
           var addCustomer =  _addCustomer.Add();
           if (addCustomer!= "Error")
           {
               MessageBox.Show(addCustomer);
               Close();
           }
           else
           {
               MessageBox.Show("Make sure to complete the necessary information provided!");
           }
        }

        private void AddCustomerCancel_Click(object sender, RoutedEventArgs e)
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

        private void CmbServiceType_OnPreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back || e.Key == Key.Space)
            {
                CmbServiceType.IsDropDownOpen = true;
                var cmb = CmbServiceType.GetBindingExpression(ComboBox.TextProperty);
                cmb.UpdateSource();
            }
            if (e.Key == Key.Up && CmbServiceType.IsDropDownOpen)
            {
                if (CmbServiceType.SelectedIndex != -1)
                {
                    CmbServiceType.SelectedIndex = CmbServiceType.SelectedIndex - 1;
                    if (CmbServiceType.SelectedIndex == -1)
                    {
                        var cmb = CmbServiceType.GetBindingExpression(ComboBox.TextProperty);
                        cmb.UpdateSource();
                    }
                }
            }

            if (e.Key == Key.Down && CmbServiceType.IsDropDownOpen)
            {
                if (CmbServiceType.SelectedIndex < CmbServiceType.Items.Count)
                {
                    CmbServiceType.SelectedIndex = CmbServiceType.SelectedIndex + 1;
                }
            }
        }

        private void CmbServiceType_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CmbServiceType.IsDropDownOpen = true;
            var cmb = CmbServiceType.GetBindingExpression(ComboBox.TextProperty);
            cmb.UpdateSource();
        }
    }
}
