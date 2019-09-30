using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace proyectokeneth.Models.Entities
{
    public partial class PlantillasCamposDetalle
    {
        public int IdPlantillaCampo { get; set; }
        public int Plantilla { get; set; }
        [DisplayName("Tipo de Dato")]
        public int IdDatoTipo { get; set; }
        [DisplayName("Nombre")]
        public string NombreCampo { get; set; }

        public virtual DatoTipo IdDatoTipoNavigation { get; set; }
        public virtual Plantillas PlantillaNavigation { get; set; }
    }
}
