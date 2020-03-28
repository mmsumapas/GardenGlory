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
using GardenGloryWpf.ViewModel.Property;
using ServiceLayer;
using ServiceLayer.MultipleServices;

namespace GardenGloryWpf.View.Property
{
    /// <summary>
    /// Interaction logic for AddPropertyView.xaml
    /// </summary>
    public partial class AddPropertyView : Window
    {
        public AddPropertyView()
        {
            InitializeComponent();
        }

        private AddPropertyViewModel _addProperty;

        public AddPropertyView(PropertyListViewModel propertyListViewModel, PropertyPropertyDescriptionService propertyPropertyDescriptionService, OwnerCmbViewModel ownerCmbViewModel): this()
        {
            _addProperty = new AddPropertyViewModel(propertyListViewModel, propertyPropertyDescriptionService, ownerCmbViewModel);
            DataContext = _addProperty;
        }


        private void PropertySave_Click(object sender, RoutedEventArgs e)
        {
            var propertyReturn = _addProperty.Add();
            if (propertyReturn =="Error")
            {
                MessageBox.Show($"Make sure that Parent Property ID or Owner ID is correct and to supply all necessary information provided!");
            }
            else
            {
                MessageBox.Show(propertyReturn);
                Close();
            }
            
        }

        private void PropertyCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CmbOwner_OnPreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back || e.Key == Key.Space)
            {
                CmbOwner.IsDropDownOpen = true;
                var cmb = CmbOwner.GetBindingExpression(ComboBox.TextProperty);
                cmb.UpdateSource();
            }
            if (e.Key == Key.Up && CmbOwner.IsDropDownOpen)
            {
                if (CmbOwner.SelectedIndex != -1)
                {
                    CmbOwner.SelectedIndex = CmbOwner.SelectedIndex - 1;
                    if (CmbOwner.SelectedIndex == -1)
                    {
                        var cmb = CmbOwner.GetBindingExpression(ComboBox.TextProperty);
                        cmb.UpdateSource();
                    }
                }
            }

            if (e.Key == Key.Down && CmbOwner.IsDropDownOpen)
            {
                if (CmbOwner.SelectedIndex < CmbOwner.Items.Count)
                {
                    CmbOwner.SelectedIndex = CmbOwner.SelectedIndex + 1;
                }
            }
        }

        private void CmbOwner_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CmbOwner.IsDropDownOpen = true;
            var cmb = CmbOwner.GetBindingExpression(ComboBox.TextProperty);
            cmb.UpdateSource();
        }
    }
}
