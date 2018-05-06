using System.Collections.Generic;
using Isen.DotNet.Library.Models.Base;

namespace Isen.DotNet.Library.Models.Implementation
{
    public class Departement : BaseModel
    {
        public string _nom { get; set; }
        public int _codeDepartement { get; set; }
        public List<Commune> _communeCollection { get; set; }
        
        public int? DepartementId { get; set; }

        public Departement()
        {
            
        }
        
    }
}