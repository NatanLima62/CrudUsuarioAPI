using System;
using System.Collections.Generic;
using CrudUsuario.Infra.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CrudUsuario.Infra.Contexts
{
    public partial class dbCrudUsuarioContext : DbContext
    {
        public dbCrudUsuarioContext()
        {
        }

        public dbCrudUsuarioContext(DbContextOptions<dbCrudUsuarioContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;User Id=root;database=dbCrudUser;", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
