
using proyectokeneth.Areas.Identity.Data;
using System;
using System.Collections.Generic;

namespace proyectokeneth.Models.Entities
{
    public partial class InstanciasPlantillasPasosDetalle
    {
        public InstanciasPlantillasPasosDetalle()
        {
            PasosUsuariosDetalle = new HashSet<PasosUsuariosDetalle>();
        }

        public int InstanciaPlantilla { get; set; }
        public int Paso { get; set; }
        public int? Estado { get; set; }
        public int IdPlantillaPasoDetalle { get; set; }
        public string AspNetUser { get; set; }

        public virtual Acciones EstadoNavigation { get; set; }
        public virtual InstanciasPlantillas InstanciaPlantillaNavigation { get; set; }
        public virtual PasosInstancias PasoNavigation { get; set; }
        public virtual proyectokenethUser AspNetUserNavigation { get; set; }
        public virtual ICollection<PasosUsuariosDetalle> PasosUsuariosDetalle { get; set; }

      
    }
}
