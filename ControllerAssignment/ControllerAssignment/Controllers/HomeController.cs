using Microsoft.AspNetCore.Mvc;
using ControllerAssignment.Models;
using System;

namespace ControllerAssignment.Controllers
{
    public class HomeController : Controller
    {
        public BankDetails bankDetails = new BankDetails()
        {
            accountNumber = 1001, accountHolderName = "Example Name", currentBalance = 5000
        };
        [HttpGet]
        [Route("home")]
        [Route("/")]
        public IActionResult Index()
        {
            return Content("<center><h1>Welcome to the Best Bank</h1></center>", "text/html");
        }

        [HttpGet]
        [Route("/account-details")]
        public IActionResult AccountDetails()
        {
            return Json(bankDetails);
        }

        [HttpGet]
        [Route("/account-statement")]
        public IActionResult AccountStatement()
        {
            return File("sample.pdf", "application/pdf");
        }

        [HttpGet]
        [Route("/get-current-balance/")]
        public IActionResult CurrentBalanceNoParameter()
        {
            return NotFound("Account Number should be supplied");
        }

        [HttpGet]
        [Route("/get-current-balance/{accountNumber:int}")]
        public IActionResult CurrentBalance()
        {
            int accountNumber = Convert.ToInt32(RouteData.Values["accountNumber"].ToString());
            if (accountNumber != 1001)
            {
                return BadRequest("Account Number should be 1001");
            }

            return Content(bankDetails.currentBalance.ToString());
        }
    }
}
