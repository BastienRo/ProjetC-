using Isen.DotNet.Library.Models.Base;

namespace Isen.DotNet.Library.Models.Implementation
{
    public class Commune : BaseModel
    {
        public string Nom  { get;set;}
        public Departement Departement { get; set; }
        public float Latitude  { get;set;}
        public float Longitude  { get;set;}
        
        public override dynamic ToDynamic()
        {
            var response = base.ToDynamic();
            response.nom = Nom;
            response.latitude = Latitude;
            response.longitude = Longitude;
            return response;
        }

    }
}