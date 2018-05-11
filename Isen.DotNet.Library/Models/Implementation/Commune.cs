using System.Collections.Generic;
using Isen.DotNet.Library.Models.Base;

namespace Isen.DotNet.Library.Models.Implementation
{
    public class Commune : BaseModel
    {
        public Departement Departement { get; set; }
        public List<Adresse> AdresseCollection { get; set; }
        public float Latitude  { get;set;}
        public float Longitude  { get;set;}
        
        public int? DepartementId { get;set; }
        
        public override dynamic ToDynamic()
        {
            var response = base.ToDynamic();
            response.departement = Departement;
            response.latitude = Latitude;
            response.longitude = Longitude;
            return response;
        }

    }
} 