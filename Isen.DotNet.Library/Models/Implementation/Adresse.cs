using System.Collections.Generic;
using Isen.DotNet.Library.Models.Base;

namespace Isen.DotNet.Library.Models.Implementation
{
    public class Adresse : BaseModel
    {
        public string LigneTxt  { get;set;}
        public int CodePostal { get; set; }
        public Departement Departement { get; set; }
        public Commune Commune  { get;set;}
        public float Latitude  { get;set;}
        public float Longitude  { get;set;}
        
        public override dynamic ToDynamic()
        {
            var response = base.ToDynamic();
            response.lignetxt = LigneTxt;
            response.codepostal = CodePostal;
            response.departement = Departement;
            response.commune = Commune;
            response.latitude = Latitude;
            response.longitude = Longitude;
            return response;
        }
    }
}