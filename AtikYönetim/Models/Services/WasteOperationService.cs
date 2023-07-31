using AtikYonetim.Core.Entities;
using AtikYonetim.Core.RepoWrapper;
using AtikYonetim.Models.Data.Context;
using AtikYonetim.Models.ViewModel;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AtikYonetim.Models.Services
{
    public class WasteOperationService
    {
        private readonly WasteDbContext _context;
        private IRepositoryWrapper _repos;

        public WasteOperationService
        (
          WasteDbContext context,
          IRepositoryWrapper repos
        )
        {
            _context = context;
            _repos = repos;
        }


        public WasteOperationDropdownsVM GetAllDropdowns()
        {
            WasteOperationDropdownsVM dropdowns = new WasteOperationDropdownsVM();
            dropdowns.CompanyList = _repos.R_Company.GetAll().ToList();
            dropdowns.StoreList = _repos.R_Store.GetAll().ToList();
            dropdowns.DefinitionList = _repos.R_Definition.GetAll().ToList();

            return dropdowns;
        }

        public List<WasteOperationVM> GetAllWasteList()
        {
            List<WasteOperationVM> wasteList = new List<WasteOperationVM>();
            wasteList = _context.sp_WasteOperation.FromSqlInterpolated($"exec dbo.sp_WasteOperation").ToList();
            return wasteList;
        }

        public WasteOperationVM GetDetail(int id)
        {
            var entity = _context.sp_WasteOperationDetail.FromSqlInterpolated($"exec dbo.sp_WasteOperationDetail @ID={id}").ToList().FirstOrDefault();

            WasteOperationVM detail = new WasteOperationVM()
            {
                ID = entity.ID,
                Month = entity.Month,
                Store = entity.Store,
                WasteType = entity.WasteType,
                WasteSort = entity.WasteSort,
                Quantity = entity.Quantity,
                Unit = entity.Unit,
                ReceivingCompany = entity.ReceivingCompany,
                WasteDate = entity.WasteDate,
                Content = entity.Content
            };
            return detail;
        }

        public void SaveWaste(WasteOperation wasteOperation)
        {
            _repos.R_WasteOperation.Add(wasteOperation);
            _repos.SaveChanges();
        }

        public void UpdateWaste(WasteOperation wasteOperation)
        {
            _repos.R_WasteOperation.Update(wasteOperation);
            _repos.SaveChanges();
        }

        public void DeleteWaste(int id)
        {
            var entity = _repos.R_WasteOperation.GetById(id);
            _repos.R_WasteOperation.Delete(entity);
            _repos.SaveChanges();
        }
    }
}
