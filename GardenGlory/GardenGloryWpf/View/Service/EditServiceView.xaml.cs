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
using GardenGloryWpf.ViewModel.Service;
using ServiceLayer;
using ServiceLayer.MultipleServices;

namespace GardenGloryWpf.View.Service
{
    /// <summary>
    /// Interaction logic for EditServiceView.xaml
    /// </summary>
    public partial class EditServiceView : Window
    {
        public EditServiceView()
        {
            InitializeComponent();
        }

        private EditServiceViewModel _editService;

        public EditServiceView(ServiceViewModel serviceViewModel, ServiceServiceTypeService serviceServiceTypeService, ServiceTypeCmbViewModel serviceTypeCmbViewModel) : this()
        {
            _editService = new EditServiceViewModel(serviceViewModel, serviceServiceTypeService, serviceTypeCmbViewModel);
            DataContext = _editService;
        }

        private void ServiceSave_Click(object sender, RoutedEventArgs e)
        {
            var editService = _editService.Edit();
            if (editService == "Error")
            {
                MessageBox.Show("Make sure to supply all the necessary information provided!");
            }
            else
            {
                Close();
            }
            
        }

        private void ServiceCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
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
