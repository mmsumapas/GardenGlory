using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using GardenGlory.Context;
using GardenGlory.DefaultValueGenerator;
using GardenGlory.EfClasses;
using GardenGloryWpf.CmbViewModel;
using Microsoft.EntityFrameworkCore.Internal;
using ServiceLayer;

namespace GardenGloryWpf.ViewModel.Service
{
    public class AddPaymentViewModel
    {
        private PaymentService _paymentService { get; }

        public AddPaymentViewModel(ServiceViewModel serviceViewModel, PaymentService paymentService, PaymentMethodCmbViewModel paymentMethodCmbViewModel)
        {
            AssociatedServiceViewModel = serviceViewModel;
            AssociatedPaymentMethodCmbViewModel = paymentMethodCmbViewModel;
            _paymentService = paymentService;
        }
        public ServiceViewModel AssociatedServiceViewModel { get; set; }
        public PaymentMethodCmbViewModel AssociatedPaymentMethodCmbViewModel { get; set; }

        public string Add()
        {
            var payment = new Payment();
            if (AssociatedPaymentMethodCmbViewModel.SelectedPaymentMethod == null || Amount == null || Amount=="")
            {
                return "Error";
            }

            var amountChecker = Amount.Any(c => char.IsLetter(c));
            if (amountChecker!=true)
            {
                payment.PaymentId = new PaymentDefaultValueGenerator(new GardenGloryContext()).PaymentPrimaryKeyGenerator();
                payment.ServiceId = AssociatedServiceViewModel.ServiceId;
                payment.PaymentMethodId = AssociatedPaymentMethodCmbViewModel.SelectedPaymentMethod.PaymentMethodId;
                payment.Date = DateTime.Today.Date;
                payment.Amount = Convert.ToDouble(Amount);

                _paymentService.AddPayment(payment);

                AssociatedServiceViewModel.ServicePaymentDetailList.Add(new ServicePaymentDetails(payment, AssociatedPaymentMethodCmbViewModel.SelectedPaymentMethod.Method));
                return "Payment is successfully added";
            }
            else
            {
                return "Error";
            }
        }
        public string Amount { get; set; }
      
    }
}
