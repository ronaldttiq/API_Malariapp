using Comun.Dto;
using Comun.Enumeracion;
using Datos.Orm.Contexto;
using Datos.Orm.Entidades;
using Microsoft.EntityFrameworkCore;
using Negocio.Contrato;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Gestion
{
    public class MuestraLogica : IMuestra
    {

        private readonly ContextoDb db;


        public MuestraLogica(ContextoDb _db)
        {
            db = _db;
            
        }

        public async Task<RespuestaDto<TReturn>> GuardarAsync<TParam, TReturn>(TParam _param)
        {
            var muestra = _param as MuestraDto;

            if (muestra == null)
                return new RespuestaDto<TReturn>(EstadoOperacion.Malo, "Parámetro inválido");

            db.TaMuestraModel.Add(new TaMuestraModel
            {
                SemanaEpidemiologica = muestra.SemanaEpidemiologica,
                Municipio = muestra.Municipio,
                TipoMuestra = muestra.TipoMuestra,
                Resultado = muestra.Resultado,
                FechaRegistro = muestra.FechaRegistro
            });

            if (await db.SaveChangesAsync() > 0)
                return new RespuestaDto<TReturn>(EstadoOperacion.Bueno, "Operación exitosa");

            return new RespuestaDto<TReturn>(EstadoOperacion.Malo, "No fue posible guardar");
        }



        public async Task<RespuestaDto<TReturn>> ActualizarAsync<TParam, TReturn>(TParam _param)
        {
            var muestra = _param as MuestraDto;

            if (muestra == null)
                return new RespuestaDto<TReturn>(EstadoOperacion.Malo, "Parámetro inválido");

            var model = await db.TaMuestraModel
                .FirstOrDefaultAsync(x => x.Id == muestra.Id);

            if (model == null)
                return new RespuestaDto<TReturn>(EstadoOperacion.Malo, "Registro no encontrado");

            model.SemanaEpidemiologica = muestra.SemanaEpidemiologica;
            model.Municipio = muestra.Municipio;
            model.TipoMuestra = muestra.TipoMuestra;
            model.Resultado = muestra.Resultado;
            model.FechaRegistro = muestra.FechaRegistro;

            await db.SaveChangesAsync();

            return new RespuestaDto<TReturn>(EstadoOperacion.Bueno, "Operación exitosa");
        }

        public async Task<RespuestaDto<TReturn>> EliminarAsync<TParam, TReturn>(TParam _param)
        {
            var muestra = _param as MuestraDto;

            if (muestra == null)
                return new RespuestaDto<TReturn>(EstadoOperacion.Malo, "Parámetro inválido");

            var model = await db.TaMuestraModel
                .FirstOrDefaultAsync(x => x.Id == muestra.Id);

            if (model == null)
                return new RespuestaDto<TReturn>(EstadoOperacion.Malo, "Registro no encontrado");

            db.TaMuestraModel.Remove(model);

            await db.SaveChangesAsync();

            return new RespuestaDto<TReturn>(EstadoOperacion.Bueno, "Operación eliminada correctamente");
        }

        public async Task<RespuestaDto<TReturn>> ConsultarListaAsync<TReturn>()
        {
            var resultado = await db.TaMuestraModel
                .Select(f => new MuestraDto
                {
                    Id = f.Id,
                    SemanaEpidemiologica = f.SemanaEpidemiologica,
                    Municipio = f.Municipio,
                    TipoMuestra = f.TipoMuestra,
                    Resultado = f.Resultado,
                    FechaRegistro = f.FechaRegistro
                })
                .ToListAsync();

            return new RespuestaDto<TReturn>(
                EstadoOperacion.Bueno,
                "Operación exitosa",
                (TReturn)(object)resultado);
        }


        public async Task<RespuestaDto<TReturn>> ConsultaListabyIdAsync<TParam, TReturn>(TParam _param)
        {
            int id = Convert.ToInt32(_param);

            var resultado = await db.TaMuestraModel
                .Where(x => x.Id == id)
                .Select(f => new MuestraDto
                {
                    Id = f.Id,
                    SemanaEpidemiologica = f.SemanaEpidemiologica,
                    Municipio = f.Municipio,
                    TipoMuestra = f.TipoMuestra,
                    Resultado = f.Resultado,
                    FechaRegistro = f.FechaRegistro
                })
                .FirstOrDefaultAsync();

            if (resultado == null)
                return new RespuestaDto<TReturn>(
                    EstadoOperacion.Malo,
                    "Registro no encontrado");

            return new RespuestaDto<TReturn>(
                EstadoOperacion.Bueno,
                "Operación exitosa",
                (TReturn)(object)resultado);
        }


    }
}
