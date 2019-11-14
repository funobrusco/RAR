using Microsoft.EntityFrameworkCore;
using RAR.DAL.Model.Tabella;
using System.Linq;
using System.Threading.Tasks;

namespace RAR.DAL.Repository
{
    public class NewDispaccioInRepository : RepositoryBase<NewDispaccioIn>, INewDispaccioInRepository
    {
        public NewDispaccioInRepository(RARContext context) : 
            base(context)
        {
        }
        public async Task<NewDispaccioIn> GetByIdAsync(long idDispaccio)
        {
            return await FindByCondition(d => d.Id.Equals(idDispaccio))
                .DefaultIfEmpty(new NewDispaccioIn())
                .SingleAsync();
        }
    }
}
