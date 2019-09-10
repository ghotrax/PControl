using System;
using System.Collections.Generic;

namespace proyectokeneth.Models.Entities
{
    public partial class Acciones
    {
        public Acciones()
        {
            InstanciasPlantillasPasosDetalle = new HashSet<InstanciasPlantillasPasosDetalle>();
        }

        public int IdAccion { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<InstanciasPlantillasPasosDetalle> InstanciasPlantillasPasosDetalle { get; set; }
    }
}
