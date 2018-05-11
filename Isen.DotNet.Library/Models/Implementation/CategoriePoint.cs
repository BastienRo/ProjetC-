using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.CompilerServices;
using Isen.DotNet.Library.Models.Base;

namespace Isen.DotNet.Library.Models.Implementation
{
    public class CategoriePoint : BaseModel
    {
        public string Nom { get; set; }
        public string Description  { get;set;}

        public List<PointOfInterest> PointOfInterestCollection { get; set; }
        

        public override dynamic ToDynamic()
        {
            var response = base.ToDynamic();
            response.descriptif = Description;
            return response;
        }
    }
}