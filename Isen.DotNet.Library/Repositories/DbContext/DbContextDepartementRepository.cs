namespace Isen.DotNet.Library.Repositories.DbContext
{
    public class DbContextDepartementRepository
    {
        public class DbContextCityRepository :
            BaseDbContextRepository<City>, ICityRepository
        {
            public DbContextCityRepository(
                ILogger<DbContextCityRepository> logger, 
                ApplicationDbContext context) 
                : base(logger, context)
            {
            }

            public override IQueryable<City> Includes(
                IQueryable<City> queryable)
                => queryable.Include(c => c.PersonCollection);
        }
    }
}