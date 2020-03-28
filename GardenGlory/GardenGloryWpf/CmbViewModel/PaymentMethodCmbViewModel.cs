using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using GardenGlory.EfClasses;
using ServiceLayer;

namespace GardenGloryWpf.CmbViewModel
{
    public class PaymentMethodCmbViewModel
    {
        private string _searchPaymentMethodText;
        private PaymentMethodService _paymentMethodService;

        public PaymentMethodCmbViewModel(PaymentMethodService paymentMethodService)
        {
            _paymentMethodService = paymentMethodService;
            PaymentMethods = new ObservableCollection<PaymentMethod>(_paymentMethodService.GetPaymentMethods());
        }
        public string SearchPaymentMethodText
        {
            get => _searchPaymentMethodText;
            set
            {
                _searchPaymentMethodText = value;
                if (_searchPaymentMethodText == null)
                {
                    _searchPaymentMethodText = "";
                    SearchPaymetMethod(_searchPaymentMethodText);
                }
                else
                {
                    SearchPaymetMethod(_searchPaymentMethodText);
                }
            }
        }
        public void SearchPaymetMethod(string searchText)
        {
            var paymentMethods = _paymentMethodService.GetPaymentMethods().Where(c => c.Method.Contains(searchText));
            PaymentMethods.Clear();
            foreach (var paymentMethod in paymentMethods)
            {
                PaymentMethods.Add(paymentMethod);
            }
        }
        public ObservableCollection<PaymentMethod> PaymentMethods { get; set; }
        public PaymentMethod SelectedPaymentMethod { get; set; }
    }
}
