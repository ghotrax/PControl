using System;
using System.Collections.Generic;

namespace proyectokeneth.Models.Entities
{
    public partial class PlantillasPasosDetalle
    {
        public int IdPlantillaPaso { get; set; }
        public int Plantilla { get; set; }
        public int Paso { get; set; }

        public virtual Pasos PasoNavigation { get; set; }
        public virtual Plantillas PlantillaNavigation { get; set; }
        public virtual List<PlantillasPasosUsuariosDetalle> PlantillasPasosUsuariosDetalle { get; set; }
    }
}
