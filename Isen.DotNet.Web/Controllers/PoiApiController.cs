using System.Collections.Generic;
using Isen.DotNet.Library.Models.Implementation;
using Isen.DotNet.Library.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Isen.DotNet.Web.Controllers
{
    public class PoiApiController : Controller
    {
        private readonly IPointOfInterestRepository _pointOfInterestRepository;

        public PoiApiController(IPointOfInterestRepository pointOfInterestRepository)
        {
            _pointOfInterestRepository = pointOfInterestRepository;
        }
        
        [Route("api/Poi/all")]
        public JsonResult getAllAction()
        {
            IEnumerable<PointOfInterest> pointOfInterests = _pointOfInterestRepository.GetAll();
            return Json(pointOfInterests);
        }
        
        [Route("api/Poi/departement/{codeDepartement}")]
        public JsonResult getByDepartementAction(int codeDepartement)
        {
            IEnumerable<PointOfInterest> pointOfInterests = _pointOfInterestRepository.GetAll();
            List<PointOfInterest> pointOfInterestsD = new List<PointOfInterest>();
            foreach (var i in pointOfInterests)
            {
                if (i.Adresse.Commune.Departement.CodeDepartement == codeDepartement)
                {
                    pointOfInterestsD.Add(i);   
                }
            }
            return Json(pointOfInterestsD);
        }
        
        [Route("api/Poi/commune/{name}")]
        public JsonResult getByCommuneAction(string name)
        {
            IEnumerable<PointOfInterest> pointOfInterests = _pointOfInterestRepository.GetAll();
            List<PointOfInterest> pointOfInterestsC = new List<PointOfInterest>();
            foreach (var i in pointOfInterests)
            {
                if (i.Adresse.Commune.Name == name)
                {
                    pointOfInterestsC.Add(i);   
                }
            }
            return Json(pointOfInterestsC);
        }
        
    }
}