using Microsoft.AspNetCore.Mvc.Rendering;
using RAR.DAL.Model.Tabella;
using System.Collections.Generic;
using System.Linq;

namespace RAR.ViewModel
{
    public class DispaccioApertoViewModel
    {
        public IEnumerable<CartolinaViewModel> cartolineDispaccio { get; set; }
        public IEnumerable<ConfigTipoConsegna> tipoConsegna { get; set; }
        public DispaccioViewModel dispaccio { get; set; }

        public IEnumerable<SelectListItem> tipoConsegnaSelect
        {
            get
            {
                return tipoConsegna.Select(tipologia => new SelectListItem
                {
                    Value = tipologia.CodiceTipoConsegna,
                    Text = tipologia.Descrizione
                }).ToList();
            }
            private set { }
        }
    }
}
