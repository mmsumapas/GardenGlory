﻿using System;
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
using GardenGloryWpf.ViewModel.Employee;
using GardenGloryWpf.ViewModel.Home;
using ServiceLayer;
using ServiceLayer.MultipleServices;

namespace GardenGloryWpf.View.Employee
{
    /// <summary>
    /// Interaction logic for EditEmployeeView.xaml
    /// </summary>
    public partial class EditEmployeeView : Window
    {
        public EditEmployeeView()
        {
            InitializeComponent();
        }

        private EditEmployeeViewModel _editEmployee;

        public EditEmployeeView(EmployeeViewModel employeeViewModel, EmployeeExperienceLevelEmployeeStatusEmployeeTypeService employeeServices, EmployeeDetailCmbViewModel employeeDetailCmbViewModel, string restrictionType) : this()
        {
            _editEmployee = new EditEmployeeViewModel(employeeViewModel, employeeServices, employeeDetailCmbViewModel);
            RestrictionChecker(restrictionType);
            DataContext = _editEmployee; 

        }

        public void RestrictionChecker(string restrictionType)
        {
            if (restrictionType!="ALL")
            {
                CmbSupervisor.Visibility = Visibility.Collapsed;
            }
            else
            {
                CmbSupervisor.Visibility = Visibility.Visible;
            }
        }


        private void EditEmployeeSave_Click(object sender, RoutedEventArgs e)
        { 
            var editEmployee =_editEmployee.Edit();
            if (editEmployee == "Error")
            {
                MessageBox.Show("Make sure to supply all necessary information!");
            }
            else
            {
                Close();
            }
            
        }

        private void EditEmployeeCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CmbEmployeeType_OnPreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back || e.Key == Key.Space)
            {
                CmbEmployeeType.IsDropDownOpen = true;
                var cmb = CmbEmployeeType.GetBindingExpression(ComboBox.TextProperty);
                cmb.UpdateSource();
            }
            if (e.Key == Key.Up && CmbEmployeeType.IsDropDownOpen)
            {
                if (CmbEmployeeType.SelectedIndex != -1)
                {
                    CmbEmployeeType.SelectedIndex = CmbEmployeeType.SelectedIndex - 1;
                    if (CmbEmployeeType.SelectedIndex == -1)
                    {
                        var cmb = CmbEmployeeType.GetBindingExpression(ComboBox.TextProperty);
                        cmb.UpdateSource();
                    }
                }
            }

            if (e.Key == Key.Down && CmbEmployeeType.IsDropDownOpen)
            {
                if (CmbEmployeeType.SelectedIndex < CmbEmployeeType.Items.Count)
                {
                    CmbEmployeeType.SelectedIndex = CmbEmployeeType.SelectedIndex + 1;
                }
            }
        }

        private void CmbEmployeeType_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CmbEmployeeType.IsDropDownOpen = true;
            var cmb = CmbEmployeeType.GetBindingExpression(ComboBox.TextProperty);
            cmb.UpdateSource();
        }

        private void CmbEmployeeStatus_OnPreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back || e.Key == Key.Space)
            {
                CmbEmployeeStatus.IsDropDownOpen = true;
                var cmb = CmbEmployeeStatus.GetBindingExpression(ComboBox.TextProperty);
                cmb.UpdateSource();
            }
            if (e.Key == Key.Up && CmbEmployeeStatus.IsDropDownOpen)
            {
                if (CmbEmployeeStatus.SelectedIndex != -1)
                {
                    CmbEmployeeStatus.SelectedIndex = CmbEmployeeStatus.SelectedIndex - 1;
                    if (CmbEmployeeStatus.SelectedIndex == -1)
                    {
                        var cmb = CmbEmployeeStatus.GetBindingExpression(ComboBox.TextProperty);
                        cmb.UpdateSource();
                    }
                }
            }

            if (e.Key == Key.Down && CmbEmployeeStatus.IsDropDownOpen)
            {
                if (CmbEmployeeStatus.SelectedIndex < CmbEmployeeStatus.Items.Count)
                {
                    CmbEmployeeStatus.SelectedIndex = CmbEmployeeStatus.SelectedIndex + 1;
                }
            }
        }

        private void CmbEmployeeStatus_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CmbEmployeeStatus.IsDropDownOpen = true;
            var cmb = CmbEmployeeStatus.GetBindingExpression(ComboBox.TextProperty);
            cmb.UpdateSource();
        }

        private void CmbExperienceLevel_OnPreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back || e.Key == Key.Space)
            {
                CmbExperienceLevel.IsDropDownOpen = true;
                var cmb = CmbExperienceLevel.GetBindingExpression(ComboBox.TextProperty);
                cmb.UpdateSource();
            }
            if (e.Key == Key.Up && CmbExperienceLevel.IsDropDownOpen)
            {
                if (CmbExperienceLevel.SelectedIndex != -1)
                {
                    CmbExperienceLevel.SelectedIndex = CmbExperienceLevel.SelectedIndex - 1;
                    if (CmbExperienceLevel.SelectedIndex == -1)
                    {
                        var cmb = CmbExperienceLevel.GetBindingExpression(ComboBox.TextProperty);
                        cmb.UpdateSource();
                    }
                }
            }

            if (e.Key == Key.Down && CmbExperienceLevel.IsDropDownOpen)
            {
                if (CmbExperienceLevel.SelectedIndex < CmbExperienceLevel.Items.Count)
                {
                    CmbExperienceLevel.SelectedIndex = CmbExperienceLevel.SelectedIndex + 1;
                }
            }
        }

        private void CmbExperienceLevel_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CmbExperienceLevel.IsDropDownOpen = true;
            var cmb = CmbExperienceLevel.GetBindingExpression(ComboBox.TextProperty);
            cmb.UpdateSource();
        }

        private void CmbSupervisor_OnPreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back || e.Key == Key.Space)
            {
                CmbSupervisor.IsDropDownOpen = true;
                var cmb = CmbSupervisor.GetBindingExpression(ComboBox.TextProperty);
                cmb.UpdateSource();
            }
            if (e.Key == Key.Up && CmbSupervisor.IsDropDownOpen)
            {
                if (CmbSupervisor.SelectedIndex != -1)
                {
                    CmbSupervisor.SelectedIndex = CmbSupervisor.SelectedIndex - 1;
                    if (CmbSupervisor.SelectedIndex == -1)
                    {
                        var cmb = CmbSupervisor.GetBindingExpression(ComboBox.TextProperty);
                        cmb.UpdateSource();
                    }
                }
            }

            if (e.Key == Key.Down && CmbSupervisor.IsDropDownOpen)
            {
                if (CmbSupervisor.SelectedIndex < CmbSupervisor.Items.Count)
                {
                    CmbSupervisor.SelectedIndex = CmbSupervisor.SelectedIndex + 1;
                }
            }
        }

        private void CmbSupervisor_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CmbSupervisor.IsDropDownOpen = true;
            var cmb = CmbSupervisor.GetBindingExpression(ComboBox.TextProperty);
            cmb.UpdateSource();
        }
    }
}