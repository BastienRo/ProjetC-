using System.Linq;
using Isen.DotNet.Library.Data;
using Isen.DotNet.Library.Models.Implementation;
using Isen.DotNet.Library.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Isen.DotNet.Library.Repositories.DbContext
{
    public class DbContextCategoriePointRepository :
        BaseDbContextRepository<CategoriePoint>, ICategoriePointRepository
    {
        public DbContextCategoriePointRepository(
            ILogger<DbContextCategoriePointRepository> logger,
            ApplicationDbContext context)
            : base(logger, context)
        {
        }
        
        public override IQueryable<CategoriePoint> Includes(
            IQueryable<CategoriePoint> queryable)
            => queryable.Include(c => c.PointOfInterestCollection);
    }
}