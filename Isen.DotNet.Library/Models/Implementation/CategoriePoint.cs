using Isen.DotNet.Library.Models.Base;

namespace Isen.DotNet.Library.Models.Implementation
{
    public class CategoriePoint : BaseModel
    {
        public string _nom  { get;set;}
        public string _descriptif  { get;set;}

        public int? CategorieId { get; set; }

        public CategoriePoint()
        {
            
        }
        

    }
}