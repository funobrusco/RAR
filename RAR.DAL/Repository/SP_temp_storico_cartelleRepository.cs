using RAR.DAL.Model.CustomModel;
using RAR.DAL.Model.Tabella;
using RAR.DAL.StoredProcedure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAR.DAL.Repository
{
    public class SP_temp_storico_cartelleRepository : RepositoryBase<NewTempStoricoCartelle>, ISP_temp_storico_cartelleRepository
    {
        public SP_temp_storico_cartelleRepository(RARContext context) :
            base(context)
        {
        }
        public async Task<IEnumerable<NewTempStoricoCartelle>> ListAsync()
        {
            return await new SP_temp_storico_cartelle(RepositoryContext).Get();
        }
    }
}
