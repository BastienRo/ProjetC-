using Isen.DotNet.Library.Models.Base;

namespace Isen.DotNet.Library.Models.Implementation
{
    public class PointOfInterest : BaseModel
    {
        public string _nom { get; set; }
        public string _descriptif { get; set; }
        public CategoriePoint _categorie { get; set; }
        public Adresse _adresse { get; set; }
        
        public int? AdresseId { get; set; }
        public int? PointOfInterestId { get; set; }

        public PointOfInterest()
        {

        }
    }
}