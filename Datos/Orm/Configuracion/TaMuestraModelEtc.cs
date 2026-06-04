using Datos.Orm.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Datos.Orm.Configuracion
{
    public class TaMuestraModelEtc : IEntityTypeConfiguration<TaMuestraModel>
    {
        public void Configure(EntityTypeBuilder<TaMuestraModel> builder)
        {
            builder.ToTable("ta_muestra", "dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName("id")
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.SemanaEpidemiologica)
                   .HasColumnName("semana_epidemiologica")
                   .HasMaxLength(150)
                   .IsRequired();

            builder.Property(x => x.Municipio)
                   .HasColumnName("municipio")
                   .HasMaxLength(150)
                   .IsRequired();

            builder.Property(x => x.TipoMuestra)
                   .HasColumnName("tipo_muestra")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.Resultado)
                   .HasColumnName("resultado")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.FechaRegistro)
                   .HasColumnName("fecha_registro")
                   .HasMaxLength(120)
                   .IsRequired();
        }
    }
}