using System;
using System.Collections.Generic;
using System.Net.WebSockets;
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
using GardenGloryWpf.ViewModel.Service;
using ServiceLayer;

namespace GardenGloryWpf.View.Service
{
    /// <summary>
    /// Interaction logic for AddPaymentView.xaml
    /// </summary>
    public partial class AddPaymentView : Window
    {
        public AddPaymentView()
        {
            InitializeComponent();
        }

        private AddPaymentViewModel _addPaymentViewModel;

        public AddPaymentView(ServiceViewModel serviceViewModel, PaymentService paymentService, PaymentMethodCmbViewModel paymentMethodCmbViewModel) :this()
        {
            _addPaymentViewModel= new AddPaymentViewModel(serviceViewModel, paymentService, paymentMethodCmbViewModel);
            DataContext = _addPaymentViewModel;
        }
        private void AddPaymentSave_Click(object sender, RoutedEventArgs e)
        {
            var addPayment = _addPaymentViewModel.Add();
            if (addPayment!="Error")
            {
                MessageBox.Show(addPayment);
                Close();
            }
            else
            {
                MessageBox.Show("Make sure to supply all necessary information provided and amount should be in numerical value!");
            }
        }

        private void AddPaymentCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void CmbPaymentMethod_OnPreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back || e.Key == Key.Space)
            {
                CmbPaymentMethod.IsDropDownOpen = true;
                var cmb = CmbPaymentMethod.GetBindingExpression(ComboBox.TextProperty);
                cmb.UpdateSource();
            }
            if (e.Key == Key.Up && CmbPaymentMethod.IsDropDownOpen)
            {
                if (CmbPaymentMethod.SelectedIndex != -1)
                {
                    CmbPaymentMethod.SelectedIndex = CmbPaymentMethod.SelectedIndex - 1;
                    if (CmbPaymentMethod.SelectedIndex == -1)
                    {
                        var cmb = CmbPaymentMethod.GetBindingExpression(ComboBox.TextProperty);
                        cmb.UpdateSource();
                    }
                }
            }

            if (e.Key == Key.Down && CmbPaymentMethod.IsDropDownOpen)
            {
                if (CmbPaymentMethod.SelectedIndex < CmbPaymentMethod.Items.Count)
                {
                    CmbPaymentMethod.SelectedIndex = CmbPaymentMethod.SelectedIndex + 1;
                }
            }
        }

        private void CmbPaymentMethod_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CmbPaymentMethod.IsDropDownOpen = true;
            var cmb = CmbPaymentMethod.GetBindingExpression(ComboBox.TextProperty);
            cmb.UpdateSource();
        }
    }
}
