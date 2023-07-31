using AtikYonetim.Core.Entities;
using AtikYonetim.Models;
using AtikYonetim.Models.Services;
using AtikYonetim.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using System.Diagnostics;

namespace AtikYonetim.Controllers
{
    public class HomeController : Controller
    {
        private WasteOperationService _wasteOperationService;

        public HomeController(WasteOperationService wasteOperationService)
        {
            _wasteOperationService = wasteOperationService;
        }

        public ActionResult Index()
        {
            var allWasteList = _wasteOperationService.GetAllWasteList();
            ViewBag.Model = allWasteList;
            return View();
        }

        [HttpPost]
        public ActionResult Detail(int id)
        {
            var wasteDetail = _wasteOperationService.GetDetail(id);
            ViewBag.Detail = wasteDetail;

            var dropdownList = _wasteOperationService.GetAllDropdowns();

            ViewBag.Month = new SelectList(dropdownList.DefinitionList.Where(m => m.Type == 1).ToList(), "ID", "Description", dropdownList.DefinitionList.Where(m => m.Type == 1 && m.Description == wasteDetail.Month).First().ID.ToString());
            ViewBag.Store = new SelectList(dropdownList.StoreList, "ID", "StoreName", dropdownList.StoreList.Where(m => m.StoreName == wasteDetail.Store).First().ID.ToString());
            ViewBag.Company = new SelectList(dropdownList.CompanyList, "ID", "CompanyName", dropdownList.CompanyList.Where(m => m.CompanyName == wasteDetail.ReceivingCompany).First().ID.ToString());
            ViewBag.WasteType = new SelectList(dropdownList.DefinitionList.Where(m => m.Type == 2).ToList(), "ID", "Description", dropdownList.DefinitionList.Where(m => m.Type == 2 && m.Description == wasteDetail.WasteType).First().ID.ToString());
            ViewBag.WasteSort = new SelectList(dropdownList.DefinitionList.Where(m => m.Type == 3).ToList(), "ID", "Description", dropdownList.DefinitionList.Where(m => m.Type == 3 && m.Description == wasteDetail.WasteSort).First().ID.ToString());
            ViewBag.Unit = new SelectList(dropdownList.DefinitionList.Where(m => m.Type == 4).ToList(), "ID", "Description", dropdownList.DefinitionList.Where(m => m.Type == 4 && m.Description == wasteDetail.Unit).First().ID.ToString());

            return PartialView(wasteDetail);
        }


        public ActionResult Update(WasteOperationVM wasteOperationWM)
        {
            WasteOperation waste = new WasteOperation()
            {
                ID = wasteOperationWM.ID,
                MonthId = Convert.ToInt32(wasteOperationWM.Month),
                StoreId = Convert.ToInt32(wasteOperationWM.Store),
                WasteTypeId = Convert.ToInt32(wasteOperationWM.WasteType),
                WasteSortId = Convert.ToInt32(wasteOperationWM.WasteSort),
                Quantity = wasteOperationWM.Quantity,
                UnitId = Convert.ToInt32(wasteOperationWM.Unit),
                ReceivingCompanyId = Convert.ToInt32(wasteOperationWM.ReceivingCompany),
                WasteDate = wasteOperationWM.WasteDate,
                Content = wasteOperationWM.Content
            };

            _wasteOperationService.UpdateWaste(waste);

            Index();
            return View("Index");
        }

        public ActionResult Delete(int id)
        {
            _wasteOperationService.DeleteWaste(id);
            return RedirectToAction("Index", "Home");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}