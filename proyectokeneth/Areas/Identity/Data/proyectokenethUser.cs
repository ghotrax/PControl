using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using proyectokeneth.Models.Entities;

namespace proyectokeneth.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the proyectokenethUser class
    public class proyectokenethUser : IdentityUser
    {
        public proyectokenethUser()
        {
            InstanciasPlantillas = new HashSet<InstanciasPlantillas>();
            InstanciasPlantillasPasosDetalle = new HashSet<InstanciasPlantillasPasosDetalle>();
            PasosUsuariosDetalle = new HashSet<PasosUsuariosDetalle>();
            PlantillasPasosUsuariosDetalle = new HashSet<PlantillasPasosUsuariosDetalle>();
        }
        public virtual ICollection<InstanciasPlantillas> InstanciasPlantillas { get; set; }
        public virtual ICollection<InstanciasPlantillasPasosDetalle> InstanciasPlantillasPasosDetalle { get; set; }
        public virtual ICollection<PasosUsuariosDetalle> PasosUsuariosDetalle { get; set; }
        public virtual ICollection<PlantillasPasosUsuariosDetalle> PlantillasPasosUsuariosDetalle { get; set; }
    }
}
