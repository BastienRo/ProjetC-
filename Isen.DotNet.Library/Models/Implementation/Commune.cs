using Isen.DotNet.Library.Models.Base;

namespace Isen.DotNet.Library.Models.Implementation
{
    public class Commune : BaseModel
    {
        public string _nom  { get;set;}
        public float _latitude  { get;set;}
        public float _longitute  { get;set;}
        
        public int? CommuneId { get; set; }

        public Commune()
        {
            
        }

    }
}