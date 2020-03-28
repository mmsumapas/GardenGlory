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
using GardenGlory.Context;
using GardenGloryWpf.CmbViewModel;
using GardenGloryWpf.ViewModel.Employee;
using GardenGloryWpf.ViewModel.Equipment;
using GardenGloryWpf.ViewModel.Service;
using ServiceLayer;

namespace GardenGloryWpf.View.Service
{
    /// <summary>
    /// Interaction logic for AddTaskView.xaml
    /// </summary>
    public partial class AddTaskView : Window
    {
        public AddTaskView()
        {
            InitializeComponent();
        }

     
        private AddTaskViewModel _addTaskViewModel;

        public AddTaskView(ServiceViewModel serviceViewModel ,TaskService taskService,EquipmentCmbViewModel equipmentCmbViewModel, EmployeeDetailCmbViewModel employeeDetailCmbView) : this()
        {
            _addTaskViewModel = new AddTaskViewModel(serviceViewModel, taskService, equipmentCmbViewModel, employeeDetailCmbView);
            DataContext = _addTaskViewModel;
        }

        private void AddTaskSave_Click(object sender, RoutedEventArgs e)
        {
            var addTask = _addTaskViewModel.Add();
            if (addTask != "Error")
            {
                MessageBox.Show(addTask);
                Close();
            }
            else
            {
                MessageBox.Show("Make sure to supply all necessary information and that Employee ID is correct and Hours Worked must be numerical value. ");
            }
        }

        private void AddTaskCancel_Click(object sender, RoutedEventArgs e)
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

        private void CmbEquipment_OnPreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back || e.Key == Key.Space)
            {
                CmbEquipment.IsDropDownOpen = true;
                var cmb = CmbEquipment.GetBindingExpression(ComboBox.TextProperty);
                cmb.UpdateSource();
            }
            if (e.Key == Key.Up && CmbEquipment.IsDropDownOpen)
            {
                if (CmbEquipment.SelectedIndex != -1)
                {
                    CmbEquipment.SelectedIndex = CmbEquipment.SelectedIndex - 1;
                    if (CmbEquipment.SelectedIndex == -1)
                    {
                        var cmb = CmbEquipment.GetBindingExpression(ComboBox.TextProperty);
                        cmb.UpdateSource();
                    }
                }
            }

            if (e.Key == Key.Down && CmbEquipment.IsDropDownOpen)
            {
                if (CmbEquipment.SelectedIndex < CmbEquipment.Items.Count)
                {
                    CmbEquipment.SelectedIndex = CmbEquipment.SelectedIndex + 1;
                }
            }
        }

        private void CmbEquipment_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CmbEquipment.IsDropDownOpen = true;
            var cmb = CmbEquipment.GetBindingExpression(ComboBox.TextProperty);
            cmb.UpdateSource();
        }
    }
}
