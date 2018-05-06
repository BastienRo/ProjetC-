using System.Collections.Generic;
using Isen.DotNet.Library.Models.Base;

namespace Isen.DotNet.Library.Models.Implementation
{
    public class Adresse : BaseModel
    {
        public string _lignetxt  { get;set;}
        public int _codePostal { get; set; }
        public Departement _departement { get; set; }
        public Commune _commune  { get;set;}
        public float _latitude  { get;set;}
        public float _longitude  { get;set;}
        
        public int? AdresseId { get; set; }

        public Adresse()
        {
            
        }
    }
}