using AtikYonetim.Core.Entities;
using AtikYonetim.Core.Repo;
using AtikYonetim.Models.Data.Context;
using System.Linq.Expressions;

namespace AtikYonetim.Models.Data.Repo
{
    public class WasteOperationRepository : Repository<WasteOperation, WasteDbContext>, IWasteOperationRepository

    {
        public WasteOperationRepository(WasteDbContext context) : base(context)
        {

        }
    }
}
