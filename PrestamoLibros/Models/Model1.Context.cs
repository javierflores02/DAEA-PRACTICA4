﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PrestamoLibros.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PrestamoLibroEntities : DbContext
    {
        public PrestamoLibroEntities()
            : base("name=PrestamoLibroEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AUTOR> AUTOR { get; set; }
        public virtual DbSet<LIBRO> LIBRO { get; set; }
        public virtual DbSet<PRESTAMO> PRESTAMO { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }
    }
}
