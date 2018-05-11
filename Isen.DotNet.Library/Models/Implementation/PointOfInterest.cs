using System.Net;
using Isen.DotNet.Library.Models.Base;

namespace Isen.DotNet.Library.Models.Implementation
{
    public class PointOfInterest : BaseModel
    {
        public string Nom { get; set; }
        public string Description { get; set; }
        public CategoriePoint Categorie { get; set; }
        public Adresse Adresse { get; set; }
        
        public int? AdresseId { get; set; }
        public int? CategorieId { get; set; }
        
        public override dynamic ToDynamic()
        {
            var response = base.ToDynamic();
            response.description = Description;
            response.categoriePoint = Categorie;
            response.adresse = Adresse?.ToDynamic();
            return response;
        }
    }
}