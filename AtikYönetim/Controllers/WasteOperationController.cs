using AtikYonetim.Core.Entities;
using AtikYonetim.Models.Services;
using AtikYonetim.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AtikYonetim.Controllers
{
    public class WasteOperationController : Controller
    {
        private WasteOperationService _wasteOperationService;

        public WasteOperationController(WasteOperationService wasteOperationService)
        {
            _wasteOperationService = wasteOperationService;
        }



        public ActionResult Index()
        {
            FillViewBag();
            return View();
        }


        public ActionResult Save(WasteOperationVM wasteOperationWM)
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

            _wasteOperationService.SaveWaste(waste);
            return RedirectToAction("Index","Home");
        }


        public void FillViewBag()
        {
            var dropdownList = _wasteOperationService.GetAllDropdowns();

            List<SelectListItem> monthItems = new List<SelectListItem>();
            List<SelectListItem> storeItems = new List<SelectListItem>();
            List<SelectListItem> wasteTypeItems = new List<SelectListItem>();
            List<SelectListItem> wasteSortItems = new List<SelectListItem>();
            List<SelectListItem> unitItems = new List<SelectListItem>();
            List<SelectListItem> companyItems = new List<SelectListItem>();

            //Aylar
            foreach (var item in dropdownList.DefinitionList.Where(m => m.Type == 1).ToList())
            {
                monthItems.Add(new SelectListItem { Text = item.Description.ToString(), Value = item.ID.ToString() });
            }

            //Mağaza
            foreach (var item in dropdownList.StoreList)
            {
                storeItems.Add(new SelectListItem { Text = item.StoreName, Value = item.ID.ToString() });
            }

            //Firma
            foreach (var item in dropdownList.CompanyList)
            {
                companyItems.Add(new SelectListItem { Text = item.CompanyName, Value = item.ID.ToString() });
            }

            //Atık tipi
            foreach (var item in dropdownList.DefinitionList.Where(m => m.Type == 2).ToList())
            {
                wasteTypeItems.Add(new SelectListItem { Text = item.Description.ToString(), Value = item.ID.ToString() });
            }

            //Atık Çeşiti
            foreach (var item in dropdownList.DefinitionList.Where(m => m.Type == 3).ToList())
            {
                wasteSortItems.Add(new SelectListItem { Text = item.Description.ToString(), Value = item.ID.ToString() });
            }

            //Birim
            foreach (var item in dropdownList.DefinitionList.Where(m => m.Type == 4).ToList())
            {
                unitItems.Add(new SelectListItem { Text = item.Description.ToString(), Value = item.ID.ToString() });
            }



            ViewBag.Month = monthItems;
            ViewBag.Store = storeItems;
            ViewBag.Company = companyItems;
            ViewBag.WasteType = wasteTypeItems;
            ViewBag.WasteSort = wasteSortItems;
            ViewBag.Unit = unitItems;
        }
    }
}