﻿using RAR.DAL.Model.CustomModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAR.DAL.Repository
{
    public interface ISP_new_dettaglio_distinte_storico_cartelleRepository
    {
        //Task<IEnumerable<NewDistinta_Postel>> ListAsync(DateTime dalGiorno, DateTime alGiorno);
        Task<IEnumerable<NewStoricoCartelle.Elenco_Distinte>> ListAsync(NewStoricoCartelle filtro);
    }
}
