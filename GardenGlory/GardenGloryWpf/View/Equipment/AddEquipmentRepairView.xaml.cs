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
    /// Interaction logic for AddEquipmentRepairView.xaml
    /// </summary>
    public partial class AddEquipmentRepairView : Window
    {
        public AddEquipmentRepairView()
        {
            InitializeComponent();
        }
        private AddEquipmentRepairViewModel _addEquipmentRepair;
         
        public AddEquipmentRepairView(EquipmentViewModel equipmentViewModel, EquipmentRepairService equipmentRepairService): this()
        {
            _addEquipmentRepair = new AddEquipmentRepairViewModel(equipmentViewModel, equipmentRepairService);
            DataContext = _addEquipmentRepair;
        }

        private void AddEquipmentRepairSave_Click(object sender, RoutedEventArgs e)
        {
            var addEquipmentRepair = _addEquipmentRepair.Add();
            if (addEquipmentRepair!="Error")
            {
                MessageBox.Show(addEquipmentRepair);
                Close();
            }
            else
            {
                MessageBox.Show("Make sure to supply all the necessary information. Amount must be numerical value!");
            }
        }

        private void AddEquipmentRepairCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
