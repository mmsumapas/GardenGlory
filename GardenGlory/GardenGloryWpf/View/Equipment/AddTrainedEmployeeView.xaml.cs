using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Dataflow;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GardenGloryWpf.CmbViewModel;
using GardenGloryWpf.ViewModel.Equipment;
using ServiceLayer;

namespace GardenGloryWpf.View.Equipment
{
    /// <summary>
    /// Interaction logic for AddTrainedEmployeeView.xaml
    /// </summary>
    public partial class AddTrainedEmployeeView : Window
    {
        public AddTrainedEmployeeView()
        {
            InitializeComponent();
        }

        private AddTrainedEmployeeViewModel _addTrainedEmployee;

        public AddTrainedEmployeeView(EquipmentViewModel equipmentViewModel, TrainedEmployeeService trainedEmployeeService, EmployeeDetailCmbViewModel employeeDetailCmbView): this()
        {
            _addTrainedEmployee = new AddTrainedEmployeeViewModel(equipmentViewModel, trainedEmployeeService, employeeDetailCmbView);
            DataContext = _addTrainedEmployee;
        }

        private void AddTrainedEmployeeSave_Click(object sender, RoutedEventArgs e)
        {
            var addTrainedEmployee = _addTrainedEmployee.Add();
            if (addTrainedEmployee !="Error")
            {
                MessageBox.Show(addTrainedEmployee);
                Close();
            }
            else
            {
                MessageBox.Show("Make sure that Employee ID is correct!");
            }
        }

        private void AddTrainedEmployeeCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CmbEmployee_OnPreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back || e.Key == Key.Space)
            {
                CmbEmployee.IsDropDownOpen = true;
                var cmb = CmbEmployee.GetBindingExpression(ComboBox.TextProperty);
                cmb.UpdateSource();
            }
            if (e.Key == Key.Up && CmbEmployee.IsDropDownOpen)
            {
                if (CmbEmployee.SelectedIndex != -1)
                {
                    CmbEmployee.SelectedIndex = CmbEmployee.SelectedIndex - 1;
                    if (CmbEmployee.SelectedIndex == -1)
                    {
                        var cmb = CmbEmployee.GetBindingExpression(ComboBox.TextProperty);
                        cmb.UpdateSource();
                    }
                }
            }

            if (e.Key == Key.Down && CmbEmployee.IsDropDownOpen)
            {
                if (CmbEmployee.SelectedIndex < CmbEmployee.Items.Count)
                {
                    CmbEmployee.SelectedIndex = CmbEmployee.SelectedIndex + 1;
                }
            }
        }

        private void CmbEmployee_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CmbEmployee.IsDropDownOpen = true;
            var cmb = CmbEmployee.GetBindingExpression(ComboBox.TextProperty);
            cmb.UpdateSource();
        }
    }
}
