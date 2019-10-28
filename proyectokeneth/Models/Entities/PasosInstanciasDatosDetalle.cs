using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace proyectokeneth.Models.Entities
{
    public partial class PasosInstanciasDatosDetalle
    {
        [DisplayName("Dato")]
        public int InstanciaPlantillaDato { get; set; }
        public int Paso { get; set; }
        public string SoloLectura { get; set; }
        public int IdPasosInstanciasDatos { get; set; }

        public virtual InstanciasPlantillasDatosDetalle InstanciaPlantillaDatoNavigation { get; set; }
        public virtual PasosInstancias PasoNavigation { get; set; }
    }
}
