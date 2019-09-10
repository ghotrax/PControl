
using proyectokeneth.Areas.Identity.Data;
using System;
using System.Collections.Generic;

namespace proyectokeneth.Models.Entities
{
    public partial class PasosUsuariosDetalle
    {
        public int PlantillaPasoDetalle { get; set; }
        public int Usuario { get; set; }
        public string AspNetUser { get; set; }
        public int IdPasosUsuarios { get; set; }

        public virtual InstanciasPlantillasPasosDetalle PlantillaPasoDetalleNavigation { get; set; }
       
        public virtual proyectokenethUser AspNetUserNavigation { get; set; }
    }
}
