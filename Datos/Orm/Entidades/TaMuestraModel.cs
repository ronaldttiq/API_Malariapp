using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.Orm.Entidades
{
    public class TaMuestraModel
    {
        public int Id { get; set; }
        public string SemanaEpidemiologica { get; set; }
        public string Municipio { get; set; }
        public string TipoMuestra { get; set; }
        public string Resultado { get; set; }
        public string FechaRegistro { get; set; }
    }

}
