using Microsoft.EntityFrameworkCore;
using RAR.DAL.Model.Tabella;
using System;

namespace RAR.DAL.StoredProcedure
{
    public class SP_aggiorna_esa_racc
    {
        RARContext context;

        public SP_aggiorna_esa_racc(RARContext _context)
        {
            context = _context;
        }

        private int _result;
        public int Set(string dataOggi)
        {

            try
            {
               _result = context.Database.ExecuteSqlCommand("SP_aggiorna_esa_racc @p0", parameters: new object[] { dataOggi });
            }
            catch (Exception)
            {
                // ignored - log here
            }

            return _result;
        }
    }
}
