﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppNetServer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AppNetEntities2 : DbContext
    {
        public AppNetEntities2()
            : base("name=AppNetEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Auftrag> Auftrag { get; set; }
        public virtual DbSet<Auftraggeber> Auftraggeber { get; set; }
        public virtual DbSet<Auftragnehmer> Auftragnehmer { get; set; }
        public virtual DbSet<Offerte> Offerte { get; set; }
    }
}
