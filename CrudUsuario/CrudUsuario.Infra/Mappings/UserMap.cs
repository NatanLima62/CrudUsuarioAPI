using CrudUsuario.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrudUsuario.Infra.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        
        builder.HasKey(user => user.Id);

        builder.Property(user => user.Name)
            .IsRequired()
            .HasColumnType("VARCHAR(180)");
        
        builder.Property(user => user.RG)
            .IsRequired()
            .HasColumnType("VARCHAR(180)");
        
        builder.Property(user => user.CPF)
            .IsRequired()
            .HasColumnType("VARCHAR(180)");
        
        builder.Property(user => user.Email)
            .IsRequired()
            .HasColumnType("VARCHAR(180)");
        
        builder.Property(user => user.Password)
            .IsRequired()
            .HasColumnType("VARCHAR(255)");
        
        builder.Property(user => user.CreateAt)
            .IsRequired(false)
            .ValueGeneratedOnAdd()
            .HasColumnType("DATETIME");
        
        builder.Property(user => user.UpdateAt)
            .IsRequired(false)
            .ValueGeneratedOnUpdate()
            .HasColumnType("DATETIME");
    }
}