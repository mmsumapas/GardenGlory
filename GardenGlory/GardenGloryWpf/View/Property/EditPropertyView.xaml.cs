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
using GardenGloryWpf.ViewModel.Customer;
using ServiceLayer;

namespace GardenGloryWpf.View.Property
{
    /// <summary>
    /// Interaction logic for EditPropertyView.xaml
    /// </summary>
    public partial class EditPropertyView : Window
    {
        private EditPropertyViewModel _editProperty;
        public EditPropertyView(PropertyViewModel editProperty, PropertyService propertyService)
        {
            InitializeComponent();
            _editProperty = new EditPropertyViewModel(editProperty, propertyService);
            DataContext = _editProperty;
        }


        private void PropertyEditSave_Click(object sender, RoutedEventArgs e)
        {
            var editProperty = _editProperty.Edit();
            if (editProperty == "Error")
            {
                MessageBox.Show("Please supply the necessary information!");
            }
            else
            {
                Close();
            }
            
        }

        private void PropertyEditCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
