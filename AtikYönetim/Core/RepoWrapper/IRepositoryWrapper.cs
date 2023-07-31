using AtikYonetim.Core.Repo;
using Microsoft.EntityFrameworkCore;

namespace AtikYonetim.Core.RepoWrapper
{
    public interface IRepositoryWrapper
    {
        IWasteOperationRepository R_WasteOperation { get; }
        IDefinitionRepository R_Definition { get; }

        IStoreRepository R_Store { get; }

        ICompanyRepository R_Company { get; }

        int SaveChanges();
        DbContext GetWasteDbContext();
    }
}
