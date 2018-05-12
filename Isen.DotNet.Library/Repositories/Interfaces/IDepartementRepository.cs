using Isen.DotNet.Library.Models.Implementation;

namespace Isen.DotNet.Library.Repositories.Interfaces
{
    public interface IDepartementRepository: IBaseRepository<Departement>

    {
        Departement Code(int CodeDepartement);
    }
    
}