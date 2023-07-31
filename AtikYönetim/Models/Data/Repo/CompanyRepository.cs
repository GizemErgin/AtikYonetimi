using AtikYonetim.Core.Entities;
using AtikYonetim.Core.Repo;
using AtikYonetim.Models.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AtikYonetim.Models.Data.Repo
{
    public class CompanyRepository : Repository<Company, WasteDbContext>, ICompanyRepository
    {
        public CompanyRepository(DbContext context) : base(context)
        {
        }
    }
}
