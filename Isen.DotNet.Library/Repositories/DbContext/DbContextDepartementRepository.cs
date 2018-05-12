using System.Linq;
using Isen.DotNet.Library.Data;
using Isen.DotNet.Library.Models.Implementation;
using Isen.DotNet.Library.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Isen.DotNet.Library.Repositories.DbContext
{
    public class DbContextDepartementRepository :
        BaseDbContextRepository<Departement>, IDepartementRepository
    {
        public DbContextDepartementRepository(
            ILogger<DbContextDepartementRepository> logger,
            ApplicationDbContext context)
            : base(logger, context)
        {
        }

        public Departement Code(int CodeDepartement)
        {
            var queryable = ModelCollection;
            queryable = Includes(queryable);
            return queryable.SingleOrDefault(c => c.CodeDepartement == CodeDepartement);
        }
        
        public override IQueryable<Departement> Includes(
            IQueryable<Departement> queryable)
            => queryable.Include(c => c.CommuneCollection);
    }
}