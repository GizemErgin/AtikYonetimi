using AtikYonetim.Core.Entities;
using AtikYonetim.Core.Repo;
using AtikYonetim.Models.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AtikYonetim.Models.Data.Repo
{
    public class StoreRepository : Repository<Store, WasteDbContext>, IStoreRepository
    {
        public StoreRepository(DbContext context) : base(context)
        {
        }
    }
}
