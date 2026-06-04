using Comun.Enumeracion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comun.Dto
{
    public class RespuestaDto<T>
    {
        public RespuestaDto(EstadoOperacion _codigo, string mensaje)
        {
            Codigo = _codigo;
            Mensaje = mensaje; 

        }

        public RespuestaDto(EstadoOperacion _codigo, string mensaje, T _respuesta)
        {
            Codigo = _codigo;
            Mensaje = mensaje;
            Respuesta = _respuesta;
        }

        public EstadoOperacion Codigo { get; set; }
        public string Mensaje { get; set; }
        public bool Estado { get => Codigo == EstadoOperacion.Bueno ? true : false; }

        private T respuesta;
        public T Respuesta
        {
            get
            {
                if(typeof(T) == typeof(bool))
                {
                    return (T)Convert.ChangeType(Estado, typeof(bool));
                }
                else
                {
                    return respuesta;
                }

            }
            set
            {
                respuesta = value;
            }
        }

    }
}
