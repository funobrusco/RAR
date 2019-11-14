using RAR.DAL.Model.Tabella;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAR.Service
{
    public interface ILookupService
    {
        Task<IEnumerable<ConfigTipoConsegna>> Elenca();
    }
}
