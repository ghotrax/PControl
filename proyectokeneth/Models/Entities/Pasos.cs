using System;
using System.Collections.Generic;

namespace proyectokeneth.Models.Entities
{
    public partial class Pasos
    {
        public Pasos()
        {
            PlantillasPasosDetalle = new HashSet<PlantillasPasosDetalle>();
        }

        public int IdPaso { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<PlantillasPasosDetalle> PlantillasPasosDetalle { get; set; }
    }
}
