using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Fecha Inicio")]
        public DateTime? FechaInicio { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Fecha Fin")]
        public DateTime? FechaFin { get; set; }
        [NotMapped]
        [DisplayName("Fecha Fin")]
        public string FechaFinString { get; set; }

        [NotMapped]
        [DisplayName("Fecha Inicio")]
        public string FechaInicioString { get; set; }

        public virtual ICollection<PlantillasPasosDetalle> PlantillasPasosDetalle { get; set; }
    }
}
