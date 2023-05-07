using DAL.IServices;
using DAL.Services;
using Microsoft.AspNetCore.Mvc;

using Models;

namespace InvoicePos.Controllers
{
    public class InvoiceController : Controller
    {
        public InvoiceController(IItemService itemService, IBillService billService)
        {
            _itemService = itemService;
            _billService = billService;
        }
        
        private readonly IItemService _itemService;
        private readonly IBillService _billService;

        public IActionResult Index()
        {
            ViewBag.Items = _itemService.GetItems();
            ViewBag.Date = DateOnly.FromDateTime(DateTime.Now).ToString("dd/MM/yyyy");
            ViewBag.Time = TimeOnly.FromDateTime(DateTime.Now).ToString();
            return View();
        }

        public IActionResult SaveBill(OrderBillMaster orderBillMaster)
        {
            try
            {
                ViewBag.Items = _itemService.GetItems();
                ViewBag.Date = DateOnly.FromDateTime(DateTime.Now).ToString("dd/MM/yyyy");
                ViewBag.Time = TimeOnly.FromDateTime(DateTime.Now).ToString();
               ViewBag.Msg = _billService.SaveBillMaster(orderBillMaster);
                return View("Index");
            }
            catch (Exception e)
            {

                throw;
            }
            
        }
        
    }
}
