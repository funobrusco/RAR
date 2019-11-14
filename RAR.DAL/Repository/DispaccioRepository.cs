using RAR.DAL.Model.CustomModel;
using RAR.DAL.Model.Tabella;
using RAR.DAL.StoredProcedure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAR.DAL.Repository
{
    public class DispaccioRepository : RepositoryBase<NewDispaccioInStored>, IDispaccioRepository
    {
        
        public DispaccioRepository(RARContext context) : 
            base(context)
        {
        }

        public async Task<OutputStored<DateTime>> Apri(string usrApertura, long idDispaccio)
        {
            return await new New_Dispaccio_In_Apertura(RepositoryContext).Execute(usrApertura, idDispaccio);
        }

        public async Task<OutputStored<NewDispaccioIn>> Chiudi(string usrChiusura, long idDispaccio)
        {
            return await new New_Dispaccio_In_Chiusura(RepositoryContext).Execute(idDispaccio, usrChiusura);
        }

        public async Task<IEnumerable<NewCartolineDispaccioInFromIdDispaccioStored>> Cartoline(long idDispaccio)
        {
            return await new New_Cartoline_Dispaccio_In_From_Id_Dispaccio(RepositoryContext).Execute(idDispaccio);
        }

        public async Task<NewDispaccioInStored> DettaglioDispaccioAperto(long idDispaccio)
        {
            return await FindByIdAsync(dispaccio => dispaccio.Id == idDispaccio);
        }

        public async Task<IEnumerable<NewDispaccioInStored>> Elenca(string userTracciatura)
        {
            return await new New_Dispaccio_In_All(RepositoryContext).Execute(userTracciatura);
        }

        async public Task<OutputStored<NewDispaccioIn>> Nuovo(NewDispaccioIn nuovoDispaccio)
        {
            return await new New_Dispaccio_In_Arrivo(RepositoryContext).Execute(nuovoDispaccio);
        }
    }
}
