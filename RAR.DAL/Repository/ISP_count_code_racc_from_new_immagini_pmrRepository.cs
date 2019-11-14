using RAR.DAL.Model.CustomModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAR.DAL.Repository
{
    public interface ISP_count_code_racc_from_new_immagini_pmrRepository
    {
        Task<IEnumerable<NewCountCodeRacc>> ListAsync(string code_racc);
    }
}
