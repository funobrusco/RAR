using RAR.DAL.Model.Tabella;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAR.DAL.Repository
{
    public interface ISP_controlla_esiti_scartatiRepository
    {
        Task<IEnumerable<CodiciSmarriti>> ListAsync(string dataOggi);
    }
}