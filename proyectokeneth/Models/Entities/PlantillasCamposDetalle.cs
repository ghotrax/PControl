using System;
using System.Collections.Generic;

namespace proyectokeneth.Models.Entities
{
    public partial class PlantillasCamposDetalle
    {
        public int IdPlantillaCampo { get; set; }
        public int Plantilla { get; set; }
        public int IdDatoTipo { get; set; }
        public string NombreCampo { get; set; }

        public virtual DatoTipo IdDatoTipoNavigation { get; set; }
        public virtual Plantillas PlantillaNavigation { get; set; }
    }
}
