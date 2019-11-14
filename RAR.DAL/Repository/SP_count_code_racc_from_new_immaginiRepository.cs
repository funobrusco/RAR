using RAR.DAL.Model.CustomModel;
using RAR.DAL.Model.Tabella;
using System.Collections.Generic;
using System.Threading.Tasks;
using RAR.DAL.StoredProcedure;

namespace RAR.DAL.Repository
{
    public class SP_count_code_racc_from_new_immaginiRepository : RepositoryBase<NewCountCodeRacc>, ISP_count_code_racc_from_new_immaginiRepository
    {
        RARContext context;
        public SP_count_code_racc_from_new_immaginiRepository(RARContext context) :
            base(context)
        {
        }
        public async Task<IEnumerable<NewCountCodeRacc>> ListAsync(string code_racc)
        {
            return await new SP_count_code_racc_from_new_immagini(context).Get(code_racc);
        }
    }
}
