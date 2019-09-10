using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyectokeneth.Models.Entities
{
    public class DatoTipo
    {
        public DatoTipo()
        {
            InstanciasPlantillasDatosDetalle = new HashSet<InstanciasPlantillasDatosDetalle>();
            PlantillasCamposDetalle = new HashSet<PlantillasCamposDetalle>();
        }

        public int IdDatoTipo { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<InstanciasPlantillasDatosDetalle> InstanciasPlantillasDatosDetalle { get; set; }
        public virtual ICollection<PlantillasCamposDetalle> PlantillasCamposDetalle { get; set; }
    }
}
