using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GardenGloryWpf.ViewModel.Equipment;
using GardenGloryWpf.ViewModel.Home;
using ServiceLayer;

namespace GardenGloryWpf.View.Equipment
{
    /// <summary>
    /// Interaction logic for EditEquipmentView.xaml
    /// </summary>
    public partial class EditEquipmentView : Window
    {
        public EditEquipmentView()
        {
            InitializeComponent();
        }

        private EditEquipmentViewModel _editEquipment;
        public EditEquipmentView(EquipmentViewModel equipmentViewModel, EquipmentService equipmentService): this()
        {
            _editEquipment = new EditEquipmentViewModel(equipmentViewModel,equipmentService);
            DataContext = _editEquipment;
        }

        private void EditEquipmentSave_Click(object sender, RoutedEventArgs e)
        {
           var editEquipment =  _editEquipment.Edit();
           if (editEquipment == "Error")
           {
               MessageBox.Show("Make sure to supply the necessary information!");
           }
           else
           {
               Close();
           }
           
        }

        private void EditEquipmentCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
