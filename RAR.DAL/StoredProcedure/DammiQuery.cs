using RAR.DAL.Model.CustomModel;
using RAR.DAL.Model.Tabella;
using StoredProcedureEFCore;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAR.DAL.StoredProcedure
{
    public class DammiQuery
    {
        RARContext context;

        public DammiQuery (RARContext _context)
        {
            context = _context;
        }
        public async Task<NewDammiQuery> Get(int ID_QUERY)
        {
            Task<List<NewDammiQuery>> result = null;
            var STORED_DAMMI_QUERY = "sp_QUERY_MANAGER_dammiQuery";
                await context.LoadStoredProc(STORED_DAMMI_QUERY)
                    .AddParam("ID_QUERY", ID_QUERY)
                    .ExecAsync(r => result = r.ToListAsync<NewDammiQuery>());
            
            return result.Result.FirstOrDefault();
        }
    }
}
