using AtikYonetim.Core.Repo;
using AtikYonetim.Core.RepoWrapper;
using AtikYonetim.Models.Data.Context;
using AtikYonetim.Models.Data.Repo;
using Microsoft.EntityFrameworkCore;

namespace AtikYonetim.Models.Data.RepoWrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {

        private WasteDbContext _wasteDbContext;
        public RepositoryWrapper(WasteDbContext wasteDbContext)
        {
            _wasteDbContext = wasteDbContext;
        }



        IWasteOperationRepository _waste;
        public IWasteOperationRepository R_WasteOperation
        {
            get
            {
                if (_waste == null)
                {
                    _waste = new WasteOperationRepository(_wasteDbContext);
                }
                return _waste;
            }
        }

        IDefinitionRepository _definition;
        public IDefinitionRepository R_Definition
        {
            get
            {
                if (_definition == null)
                {
                    _definition = new DefinitionRepository(_wasteDbContext);
                }
                return _definition;
            }
        }

        IStoreRepository _store;
        public IStoreRepository R_Store
        {
            get
            {
                if (_store == null)
                {
                    _store = new StoreRepository(_wasteDbContext);
                }
                return _store;
            }
        }

        ICompanyRepository _company;
        public ICompanyRepository R_Company
        {
            get
            {
                if (_company == null)
                {
                    _company = new CompanyRepository(_wasteDbContext);
                }
                return _company;
            }
        }


        public int SaveChanges()
        {
            return _wasteDbContext.SaveChanges();
        }


        public async Task<int> SaveChangesAsync()
        {
            return await _wasteDbContext.SaveChangesAsync();
        }

        public DbContext GetWasteDbContext()
        {
            return _wasteDbContext;
        }
    }
}
