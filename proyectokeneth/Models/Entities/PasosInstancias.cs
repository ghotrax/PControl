using System;
using System.Collections.Generic;

namespace proyectokeneth.Models.Entities
{
    public partial class PasosInstancias
    {
        public PasosInstancias()
        {
            InstanciasPlantillasPasosDetalle = new HashSet<InstanciasPlantillasPasosDetalle>();
            PasosInstanciasDatosDetalle = new List<PasosInstanciasDatosDetalle>();
        }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdPasoinstancia { get; set; }

        public virtual ICollection<InstanciasPlantillasPasosDetalle> InstanciasPlantillasPasosDetalle { get; set; }
        public virtual List<PasosInstanciasDatosDetalle> PasosInstanciasDatosDetalle { get; set; }
    }
}
