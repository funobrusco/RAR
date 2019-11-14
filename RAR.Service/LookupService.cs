using System.Collections.Generic;
using System.Threading.Tasks;
using RAR.DAL.Model.Tabella;
using RAR.DAL.Repository;

namespace RAR.Service
{
    public class LookupService : ILookupService
    {
        private readonly IRepositoryBase<ConfigTipoConsegna> _configTipoConsegnaRepository;

        public LookupService(IRepositoryBase<ConfigTipoConsegna> configTipoConsegnaRepository)
        {
            _configTipoConsegnaRepository = configTipoConsegnaRepository;
        }

        public async Task<IEnumerable<ConfigTipoConsegna>> Elenca()
        {
            return await _configTipoConsegnaRepository.FindAllAsync();
        }
    }
}
