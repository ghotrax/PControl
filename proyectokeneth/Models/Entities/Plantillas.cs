using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace proyectokeneth.Models.Entities
{
    public partial class Plantillas
    {
        public Plantillas()
        {
            PlantillasCamposDetalle = new HashSet<PlantillasCamposDetalle>();
            PlantillasPasosDetalle = new HashSet<PlantillasPasosDetalle>();
        }

        public int IdPlantilla { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }

        public virtual ICollection<PlantillasCamposDetalle> PlantillasCamposDetalle { get; set; }
        public virtual ICollection<PlantillasPasosDetalle> PlantillasPasosDetalle { get; set; }
    }
}
