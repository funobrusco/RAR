using Microsoft.EntityFrameworkCore;
using RAR.DAL.Model.Tabella;
using System;

namespace RAR.DAL.StoredProcedure
{
    public class SP_new_dettaglio_racc_storico_cartelle
    {
        RARContext context;

        public SP_new_dettaglio_racc_storico_cartelle(RARContext _context)
        {
            context = _context;
        }

        private int _result;
        public int Set(string codiceRaccomandata)
        {
            try
            {
                _result = context.Database.ExecuteSqlCommand("new_dettaglio_racc_storico_cartelle @p0", parameters: new[] { codiceRaccomandata });
            }
            catch (Exception ex)
            {
                return -1;
            }
            return _result;
        }
    }
}
