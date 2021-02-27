using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nancy.Json;
using Newtonsoft.Json;
using ParkWayProject2.HelperMethods;
using ParkWayProject2.Models;

namespace ParkWayProject2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        HelperDataClass helperDataClass = new HelperDataClass();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            
            
        }

        public IActionResult Index()
        {
            var webClient = new WebClient();
            var json = webClient.DownloadString(@"C:\Users\Limbot Express\source\repos\ParkWayProject2\ParkWayProject2\wwwroot\feeJson\fees.config.json");
         
            
            var allPayments = JsonConvert.DeserializeObject<AllPayments>(json);
            decimal charge = 0.0m;
            decimal payment = 0.0m;

            foreach (var item in allPayments.fees)
            {
                if( payment >= item.minAmount && payment <= item.maxAmount)
                {
                    PaymentDataViewModel paymentDataViewModel = new PaymentDataViewModel()
                    {
                        feeAmount = item.feeAmount,
                        minAmount =item.minAmount,
                        maxAmount = item.maxAmount,
                        totalAmount = item.feeAmount + payment,
                    };

                    PaymentData allPaymentsData = new PaymentData();

                    allPaymentsData.feeAmount = paymentDataViewModel.feeAmount;
                    allPaymentsData.minAmount = paymentDataViewModel.minAmount;
                    allPaymentsData.maxAmount = paymentDataViewModel.maxAmount;
                    allPaymentsData.totalAmount = paymentDataViewModel.totalAmount;

                    return View(allPaymentsData);
                }
                charge = item.feeAmount;
            }


            return View(allPayments);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TransferFunds()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TransferFunds(TransferModel transferModel)
        {
            PaymentData paymentData = helperDataClass.GetPaymentData(transferModel.TransferAmount);
            return RedirectToAction("TransactionDetails", paymentData);
        }

        [HttpGet]
        public IActionResult TransferFundsV2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TransferFundsV2(TransferModel transferModel)
        {
            PaymentData paymentData = helperDataClass.GetPaymentDataV2(transferModel.TransferAmount);
            return RedirectToAction("TransactionDetailsV2", paymentData);
            
        }


        [HttpGet]
        public IActionResult TransactionDetails(PaymentData paymentData)
        {
            return View(paymentData);
        }

        [HttpGet]
        public IActionResult TransactionDetailsV2(PaymentData paymentData)
        {
            return View(paymentData);
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
