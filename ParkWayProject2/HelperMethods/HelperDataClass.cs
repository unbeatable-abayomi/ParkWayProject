using Newtonsoft.Json;
using ParkWayProject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ParkWayProject2.HelperMethods
{
    public class HelperDataClass
    {
        public PaymentData GetPaymentData(decimal transferAmount)
        {

            var webClient = new WebClient();
            var json = webClient.DownloadString(@"C:\Users\Limbot Express\source\repos\ParkWayProject2\ParkWayProject2\wwwroot\feeJson\fees.config.json");


            var allPayments = JsonConvert.DeserializeObject<AllPayments>(json);
           
            PaymentData allPaymentsData = new PaymentData();
            foreach (var item in allPayments.fees)
            {
                if (transferAmount >= item.minAmount && transferAmount <= item.maxAmount)
                {
                    PaymentDataViewModel paymentDataViewModel = new PaymentDataViewModel()
                    {
                        feeAmount = item.feeAmount,
                        minAmount = item.minAmount,
                        maxAmount = item.maxAmount,
                        totalAmount = item.feeAmount + transferAmount,
                        transferAmount = transferAmount
                    };

                    

                    allPaymentsData.feeAmount = paymentDataViewModel.feeAmount;
                    allPaymentsData.minAmount = paymentDataViewModel.minAmount;
                    allPaymentsData.maxAmount = paymentDataViewModel.maxAmount;
                    allPaymentsData.totalAmount = paymentDataViewModel.totalAmount;
                    allPaymentsData.transferAmount = paymentDataViewModel.transferAmount;

                    return allPaymentsData;
                }
               // return 
            }
            return allPaymentsData;
        }
        public PaymentData GetPaymentDataV2(decimal transferAmount)
        {

            var webClient = new WebClient();
            var json = webClient.DownloadString(@"C:\Users\Limbot Express\source\repos\ParkWayProject2\ParkWayProject2\wwwroot\feeJson\fees.config.json");


            decimal deuction = 0.0m;
            var allPayments = JsonConvert.DeserializeObject<AllPayments>(json);

            PaymentData allPaymentsData = new PaymentData();
            foreach (var item in allPayments.fees)
            {
                if (transferAmount >= item.minAmount && transferAmount <= item.maxAmount)
                {
                    deuction = transferAmount - item.feeAmount;
                    PaymentDataViewModel paymentDataViewModel = new PaymentDataViewModel()
                    {

                        feeAmount = item.feeAmount,
                        minAmount = item.minAmount,
                        maxAmount = item.maxAmount,
                        totalAmount = (transferAmount - item.feeAmount),
                        transferAmount = deuction + item.feeAmount,
                    };



                    allPaymentsData.feeAmount = paymentDataViewModel.feeAmount;
                    allPaymentsData.minAmount = paymentDataViewModel.minAmount;
                    allPaymentsData.maxAmount = paymentDataViewModel.maxAmount;
                    allPaymentsData.totalAmount = paymentDataViewModel.totalAmount;
                    allPaymentsData.transferAmount = paymentDataViewModel.transferAmount;

                    return allPaymentsData;
                }
                // return 
            }
            return allPaymentsData;
        }
    }
}
