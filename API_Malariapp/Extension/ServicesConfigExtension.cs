using Comun.Dto;
using Datos.Orm.Contexto;
using Microsoft.EntityFrameworkCore;
using Negocio.Contrato;
using Negocio.Gestion;

namespace API_Malariapp.Extension
{
    public static class ServicesConfigExtension
    {
        public static void InjeccionDepenciaObjetos(this WebApplicationBuilder _builder)
        {
            _builder.Services.AddDbContext<ContextoDb>(opciones =>
             opciones.UseSqlServer(_builder.Configuration.GetConnectionString("DbConexion")));

            _builder.Services.AddScoped<IMuestra, MuestraLogica >();
        }
    }
}
