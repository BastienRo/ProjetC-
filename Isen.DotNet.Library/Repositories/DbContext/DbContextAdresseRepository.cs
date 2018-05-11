﻿using System.Linq;
using Isen.DotNet.Library.Data;
using Isen.DotNet.Library.Models.Implementation;
using Isen.DotNet.Library.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Isen.DotNet.Library.Repositories.DbContext
{
    public class DbContextAdresseRepository :
        BaseDbContextRepository<Adresse>, IAdresseRepository
    {
        public DbContextAdresseRepository(
            ILogger<DbContextAdresseRepository> logger,
            ApplicationDbContext context)
            : base(logger, context)
        {
        }

        public override IQueryable<Adresse> Includes(
            IQueryable<Adresse> queryable)
            => queryable.Include(c => c.PointOfInterest).Include(c => c.Commune).Include(c=>c.PointOfInterest.Adresse.Commune);
    }
}