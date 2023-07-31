using AtikYonetim.Core.Entities;
using AtikYonetim.Core.Repo;
using AtikYonetim.Models.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AtikYonetim.Models.Data.Repo
{
    public class DefinitionRepository : Repository<Definition, WasteDbContext>, IDefinitionRepository
    {
        public DefinitionRepository(DbContext context) : base(context)
        {
        }
    }
}
