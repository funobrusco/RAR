using RAR.DAL.Model.CustomModel;
using RAR.DAL.Model.Tabella;
using StoredProcedureEFCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAR.DAL.StoredProcedure
{
    public class CaricaQuery
    {
        RARContext context;

        public CaricaQuery(RARContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<NewCaricaQuery>> GetAll()
        {
            Task<List<NewCaricaQuery>> result = null;
            var STORED_CARICA_QUERY = "sp_QUERY_MANAGER_caricaQuery";

            await context.LoadStoredProc(STORED_CARICA_QUERY)
                .ExecAsync(r => result = r.ToListAsync<NewCaricaQuery>());

            return await result;
        }
    }
}
