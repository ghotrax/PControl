using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace proyectokeneth.Models
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel(){
            Users = new List<string>();

}

        public String id { get; set; }

    [Required(ErrorMessage ="Nombre del rol es requerido")]
        public String RoleName { get; set; }

        public List<string> Users { get; set; }
    }
}
