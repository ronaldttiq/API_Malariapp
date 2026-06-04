using Comun.Dto;
using Negocio.Contrato.Crud;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Contrato
{
    public interface IMuestra: IGuardar, IConsulta, IActualizar, IEliminar
    {
        Task<RespuestaDto<TReturn>> ConsultaListabyIdAsync<TParam, TReturn>(TParam _param);
            }
}
