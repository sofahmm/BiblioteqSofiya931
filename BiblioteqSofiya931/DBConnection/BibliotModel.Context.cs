﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BiblioteqSofiya931.DBConnection
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BiblioteqKymSofiyaEntities : DbContext
    {
        public BiblioteqKymSofiyaEntities()
            : base("name=BiblioteqKymSofiyaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<CreateBuild> CreateBuild { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Hall> Hall { get; set; }
        public virtual DbSet<HistoryReaderTicket> HistoryReaderTicket { get; set; }
        public virtual DbSet<Janr> Janr { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Reader> Reader { get; set; }
        public virtual DbSet<ReadTicket> ReadTicket { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
