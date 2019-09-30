using System;
using System.Collections.Generic;

namespace proyectokeneth.Models.Entities
{
    public partial class InstanciasPlantillasDatosDetalle
    {
        public InstanciasPlantillasDatosDetalle()
        {
            PasosInstanciasDatosDetalle = new HashSet<PasosInstanciasDatosDetalle>();
        }

        public int IdInstanciaPlantillaDato { get; set; }
        public int Instanciaplantilla { get; set; }
        public int IdDatoTipo { get; set; }
        public string NombreCampo { get; set; }
        public string DatoTexto { get; set; }
        public DateTime? DatoFecha { get; set; }
        public long? DatoNumerico { get; set; }
        public decimal? DatoDecimal { get; set; }

        public virtual InstanciasPlantillas InstanciaplantillaNavigation { get; set; }
        public virtual DatoTipo IdDatoTipoNavigation { get; set; }
        public virtual ICollection<PasosInstanciasDatosDetalle> PasosInstanciasDatosDetalle { get; set; }
    }
}
