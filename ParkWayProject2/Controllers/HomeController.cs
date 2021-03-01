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
  

            return View();
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
