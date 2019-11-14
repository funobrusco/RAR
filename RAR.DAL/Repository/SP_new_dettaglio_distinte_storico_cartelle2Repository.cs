//using RAR.DAL.Model.CustomModel;
//using RAR.DAL.Model.Tabella;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using RAR.DAL.StoredProcedure;

//namespace RAR.DAL.Repository
//{
//    public class SP_new_dettaglio_distinte_storico_cartelle2Repository : RepositoryBase<NewRaccomandateInDistinta>, ISP_new_dettaglio_distinte_storico_cartelle2Repository
//    {
//        RARContext context;
//        public SP_new_dettaglio_distinte_storico_cartelle2Repository(RARContext context) :
//            base(context)
//        {
//        }
//        public async Task<IEnumerable<NewRaccomandateInDistinta>> ListAsync(string distinta)
//        {
//            return await new SP_new_dettaglio_distinte_storico_cartelle2(context).Get(distinta);
//        }
//    }
//}
