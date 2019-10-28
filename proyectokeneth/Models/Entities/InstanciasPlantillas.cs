//using PMStudio.Areas.Identity.Data;
using proyectokeneth.Areas.Identity.Data;
using System;
using System.Collections.Generic;

namespace proyectokeneth.Models.Entities
{
    public partial class InstanciasPlantillas
    {
        public InstanciasPlantillas()
        {
            InstanciasPlantillasDatosDetalle = new HashSet<InstanciasPlantillasDatosDetalle>();
            InstanciasPlantillasPasosDetalle = new HashSet<InstanciasPlantillasPasosDetalle>();
        }

        public int IdInstanciaPlantilla { get; set; }
        public string Nombre { get; set; }
        public string AspNetUser { get; set; }
        public string Estado { get; set; }
        public string Iniciada { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }


        public virtual proyectokenethUser AspNetUserNavigation { get; set; }
        public virtual ICollection<InstanciasPlantillasDatosDetalle> InstanciasPlantillasDatosDetalle { get; set; }
        public virtual ICollection<InstanciasPlantillasPasosDetalle> InstanciasPlantillasPasosDetalle { get; set; }
    }
}
