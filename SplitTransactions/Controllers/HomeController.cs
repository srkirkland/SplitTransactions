using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SplitTransactions.Services;

namespace SplitTransactions.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private readonly TransactionAllocationManager _allocationManager;

        public HomeController()
        {
            _allocationManager = new TransactionAllocationManager("123456789", 28);    
        }

        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult AllocateTwo()
        {
            _allocationManager.AddAllocation("ABC", "L", "AARGAAD", string.Empty, string.Empty, string.Empty, 25, AllocationType.Amount);
            _allocationManager.AddAllocation("ABC", "3", "ABBABBA", string.Empty, string.Empty, string.Empty, 75, AllocationType.Amount);
            
            return View(_allocationManager.GetAllocations());
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
