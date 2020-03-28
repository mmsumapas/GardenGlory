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
using GardenGloryWpf.ViewModel.Equipment;
using ServiceLayer;

namespace GardenGloryWpf.View.Equipment
{
    /// <summary>
    /// Interaction logic for AddEquipmentView.xaml
    /// </summary>
    public partial class AddEquipmentView : Window
    {
        public AddEquipmentView()
        {
            InitializeComponent();
        }

        private AddEquipmentViewModel _addEquipment;

        public AddEquipmentView(EquipmentListViewModel equipmentListViewModel, EquipmentService equipmentService) :this()
        {
            _addEquipment = new AddEquipmentViewModel(equipmentListViewModel, equipmentService);
            DataContext = _addEquipment;
        }
        private void AddEquipmentSave_Click(object sender, RoutedEventArgs e)
        {
            var addEquipmentMessage = _addEquipment.Add();
            if (addEquipmentMessage != "Error")
            {
                MessageBox.Show(addEquipmentMessage);
                Close();
            }
            else
            {
                MessageBox.Show("Equipment is already existing in the Database or supply the necessary information provided!");
            }
           
        }

        private void AddEquipmentCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
