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
using GardenGloryWpf.ViewModel.Property;
using ServiceLayer;

namespace GardenGloryWpf.View.Property
{
    /// <summary>
    /// Interaction logic for AddPropertyDescriptionView.xaml
    /// </summary>
    public partial class AddPropertyDescriptionView : Window
    {
        public AddPropertyDescriptionView()
        {
            InitializeComponent();
        }
 
        private AddPropertyDescriptionViewModel _addPropertyDescription;
        public AddPropertyDescriptionView(PropertyViewModel propertyViewModel, PropertyDescriptionService propertyDescriptionService ) : this()
        {
            _addPropertyDescription = new AddPropertyDescriptionViewModel(propertyViewModel, propertyDescriptionService );
            DataContext = _addPropertyDescription;
        }

        private void AddPropertyDescriptionSave_Click(object sender, RoutedEventArgs e)
        {
           var addPropertyDescription =  _addPropertyDescription.Add();
           if (addPropertyDescription =="Error")
           {
               MessageBox.Show("Please supply all the necessary information!");
           }
           else
           {
               MessageBox.Show(addPropertyDescription);
           }
            Close();
        }

        private void EditPropertyDescriptionCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
