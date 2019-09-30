using proyectokeneth.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace proyectokeneth.Models.Entities
{
    public partial class PlantillasPasosUsuariosDetalle
    {
        public int IdPlantillaPasosUsuarios { get; set; }
        public int PlantillaPasoDetalle { get; set; }
        [DisplayName("Usuario")]
        public string AspNetUser { get; set; }

        public virtual PlantillasPasosDetalle PlantillaPasoDetalleNavigation { get; set; }
        public virtual proyectokenethUser AspNetUserNavigation { get; set; }
    }
}
