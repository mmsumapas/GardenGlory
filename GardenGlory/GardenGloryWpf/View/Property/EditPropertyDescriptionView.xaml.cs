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
    /// Interaction logic for EditPropertyDescriptionView.xaml
    /// </summary>
    public partial class EditPropertyDescriptionView : Window
    {
        public EditPropertyDescriptionView()
        {
            InitializeComponent();
        }

        private EditPropertyDescriptionViewModel _editPropertyDescriptionViewModel;
        private PropertyDescriptionService _propertyDescriptionService;
        private PropertyViewModel _propertyViewModel;
        private int _selectedIndex;
        public EditPropertyDescriptionView(PropertyViewModel propertyViewModel, PropertyDescriptionService propertyDescriptionService,int selectedIndex) :this()
        {
            _propertyViewModel = propertyViewModel;
            _selectedIndex = selectedIndex;
            _propertyDescriptionService = propertyDescriptionService;
            _editPropertyDescriptionViewModel = new EditPropertyDescriptionViewModel(propertyViewModel, propertyDescriptionService, selectedIndex);
            DataContext = _editPropertyDescriptionViewModel;
        }
        private void EditPropertyDescriptionSave_Click(object sender, RoutedEventArgs e)
        {
            _editPropertyDescriptionViewModel.Edit();
            MessageBox.Show("Edit successful!");
            Close();

        }

        private void EditPropertyDescriptionCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DeletePropertyDescriptionCancel_Click(object sender, RoutedEventArgs e)
        {
           
            _propertyDescriptionService.RemovePropertyDescription(_propertyViewModel.PropertyDescriptions[_selectedIndex].PropertyDescriptionId);
            _propertyViewModel.PropertyDescriptions.Remove(_propertyViewModel.PropertyDescriptions[_selectedIndex]);
            Close();
        }
    }
}
