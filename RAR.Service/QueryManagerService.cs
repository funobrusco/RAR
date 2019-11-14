using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using RAR.DAL.Model.CustomModel;
using RAR.DAL.Repository;
using RAR.ViewModel;

namespace RAR.Service
{
    public class QueryManagerService : IQueryManagerService
    {
        #region membri
        private readonly IQueryManagerRepository _queryManagerRepository;
        #endregion membri

        public QueryManagerService(IQueryManagerRepository queryManagerRepository)
        {
            _queryManagerRepository = queryManagerRepository;
        }

        public async Task<IEnumerable<QueryViewModel>> Elenca()
        {
            var result = new List<QueryViewModel>();

            var result1 = await _queryManagerRepository.Elenca();
            result1.ToList().ForEach(query =>
            {
                result.Add(Traslate(query));
            });

            return result;
        }

        public async Task<QueryViewModel> GetQuery(int idQuery)
        {
            var result = new QueryViewModel();

            var result1 = await _queryManagerRepository.GetQuery(idQuery);
            result = Traslate(result1);

            return result;
        }

        #region Translator
        private QueryViewModel Traslate(NewDammiQuery query)
        {
            var result = new QueryViewModel()
            {
                Descrizione = query.Testo,
                IdQuery = query.IdQuery.ToString()
            };
            return result;
        }

        private QueryViewModel Traslate(NewCaricaQuery query)
        {
            var result = new QueryViewModel()
            {
                Utente = query.CodeOp,
                Descrizione = query.DescQuery,
                IdQuery = query.IdQuery.ToString()
            };
            return result;
        }
        #endregion Translator
    }
}
