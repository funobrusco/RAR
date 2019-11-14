using RAR.DAL.Model.CustomModel;
using RAR.DAL.Model.Tabella;
using System.Collections.Generic;
using System.Threading.Tasks;
using RAR.DAL.StoredProcedure;
using System;

namespace RAR.DAL.Repository
{
    public class SP_new_dettaglio_distinte_storico_cartelleRepository : RepositoryBase<NewStoricoCartelle>, ISP_new_dettaglio_distinte_storico_cartelleRepository
    {

        public SP_new_dettaglio_distinte_storico_cartelleRepository(RARContext context) :
            base(context)
        {
        }
        public async Task<IEnumerable<NewStoricoCartelle.Elenco_Distinte>> ListAsync(NewStoricoCartelle filtro)
        {
            return await new SP_new_dettaglio_distinte_storico_cartelle(RepositoryContext).Get(Convert.ToDateTime(filtro.DalGiorno), Convert.ToDateTime(filtro.AlGiorno));
        }
    }
}
