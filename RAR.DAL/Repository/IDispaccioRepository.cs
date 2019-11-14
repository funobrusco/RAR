using RAR.DAL.Model.CustomModel;
using RAR.DAL.Model.Tabella;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAR.DAL.Repository
{
    public interface IDispaccioRepository
    {
        Task<IEnumerable<NewCartolineDispaccioInFromIdDispaccioStored>> Cartoline(long idDispaccio);
        Task<IEnumerable<NewDispaccioInStored>> Elenca(string userTracciatura);
        Task<OutputStored<NewDispaccioIn>> Nuovo(NewDispaccioIn nuovoDispaccio);
        Task<OutputStored<NewDispaccioIn>> Chiudi(string usrChiusura, long idDispaccio);

        Task<OutputStored<DateTime>> Apri(string usrApertura, long idDispaccio);
    }
}
