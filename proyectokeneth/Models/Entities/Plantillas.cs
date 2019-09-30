using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace proyectokeneth.Models.Entities
{
    public partial class Plantillas
    {
        public Plantillas()
        {
            PlantillasCamposDetalle = new List<PlantillasCamposDetalle>();
            PlantillasPasosDetalle = new List<PlantillasPasosDetalle>();
        }

        public int IdPlantilla { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }

        public virtual List<PlantillasCamposDetalle> PlantillasCamposDetalle { get; set; }
        public virtual List<PlantillasPasosDetalle> PlantillasPasosDetalle { get; set; }
    }
}
