﻿using System.Collections.Generic;
using System.Linq;
using Isen.DotNet.Library.Data;
using Isen.DotNet.Library.Models.Base;
using Isen.DotNet.Library.Models.Implementation;
using Isen.DotNet.Library.Repositories.Base;
using Isen.DotNet.Library.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Isen.DotNet.Library.Repositories.DbContext
{
    public class DbContextPointOfInterstRepository :
        BaseDbContextRepository<PointOfInterest>, IPointOfInterestRepository
    {
        public DbContextPointOfInterstRepository(
            ILogger<DbContextPointOfInterstRepository> logger, 
            ApplicationDbContext context) 
            : base(logger, context)
        {
        }
        
        
        public override IQueryable<PointOfInterest> Includes(
            IQueryable<PointOfInterest> queryable)
            => queryable.Include(c => c.Adresse).Include(c => c.Adresse.Commune).Include(c=>c.Adresse.Commune.Departement).Include(c => c.Categorie);

    }
}