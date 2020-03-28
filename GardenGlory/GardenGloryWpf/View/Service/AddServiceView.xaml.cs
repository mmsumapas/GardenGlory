using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GardenGlory.Context;
using GardenGloryWpf.CmbViewModel;
using GardenGloryWpf.ViewModel.Customer;
using GardenGloryWpf.ViewModel.Service;
using ServiceLayer;
using ServiceLayer.MultipleServices;

namespace GardenGloryWpf.View.Service
{
    /// <summary>
    /// Interaction logic for AddServiceView.xaml
    /// </summary>
    public partial class AddServiceView : Window
    {
        public AddServiceView()
        {
            InitializeComponent();
        }

        private AddServiceViewModel _addService;
        public AddServiceView(ServiceListViewModel serviceListViewModel,ServiceServiceTypeService serviceServiceTypeService, ServiceTypeCmbViewModel serviceTypeCmbViewModel, PropertyCmbViewModel propertyCmbViewModel): this()
        {
            _addService = new AddServiceViewModel(serviceListViewModel,serviceServiceTypeService, serviceTypeCmbViewModel, propertyCmbViewModel);
            DataContext = _addService;
            
        }

        private void AddServiceSave_Click(object sender, RoutedEventArgs e)
        {
            var serviceReturn = _addService.Add();
            if (serviceReturn == "Error")
            {
                MessageBox.Show($"Make sure that Property ID and Owner Id is correct. Owner must already have the property " +
                                $"and to supply all necessary information in order to successfully add a new service.");
            }
            else
            {
                MessageBox.Show(serviceReturn);
                Close();

            }
            
        }

        private void AddServiceCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CmbProperty_OnPreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back || e.Key == Key.Space)
            {
                CmbProperty.IsDropDownOpen = true;
                var cmb = CmbProperty.GetBindingExpression(ComboBox.TextProperty);
                cmb.UpdateSource();
            }
            if (e.Key == Key.Up && CmbProperty.IsDropDownOpen)
            {
                if (CmbProperty.SelectedIndex != -1)
                {
                    CmbProperty.SelectedIndex = CmbProperty.SelectedIndex - 1;
                    if (CmbProperty.SelectedIndex == -1)
                    {
                        var cmb = CmbProperty.GetBindingExpression(ComboBox.TextProperty);
                        cmb.UpdateSource();
                    }
                }
            }

            if (e.Key == Key.Down && CmbProperty.IsDropDownOpen)
            {
                if (CmbProperty.SelectedIndex < CmbProperty.Items.Count)
                {
                    CmbProperty.SelectedIndex = CmbProperty.SelectedIndex + 1;
                }
            }
        }

        private void CmbProperty_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CmbProperty.IsDropDownOpen = true;
            var cmb = CmbProperty.GetBindingExpression(ComboBox.TextProperty);
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
