using domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data
{
    public class ClienteMapping : IEntityTypeConfiguration<Clientes>
    {
        public void Configure(EntityTypeBuilder<Clientes> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.CPF)
                .HasColumnName("CPF")
                .HasMaxLength(11);

            builder.Property(e => e.DataCadastro)
              .HasColumnName("DataCadastro")
              .HasDefaultValue(DateTime.Now);


            builder.Property(e => e.Nome)
               .HasColumnName("Nome")
               .HasMaxLength(200);

            builder.Property(e => e.Valor)
              .HasColumnName("Valor")
              .HasPrecision(20,10);    

            builder.Property(e => e.Endereco)
             .HasColumnName("Endereco")
             .HasMaxLength(200);

            builder.ToTable("Cliente");
        }
    }

}
