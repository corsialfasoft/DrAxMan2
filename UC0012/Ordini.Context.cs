﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Codice generato da un modello.
//
//     Le modifiche manuali a questo file potrebbero causare un comportamento imprevisto dell'applicazione.
//     Se il codice viene rigenerato, le modifiche manuali al file verranno sovrascritte.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UC0012
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OrdiniEntities : DbContext
    {
        public OrdiniEntities()
            : base("name=OrdiniEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<OrdiniProdotti> OrdiniProdotti { get; set; }
        public virtual DbSet<OrdiniSet> OrdiniSet { get; set; }
        public virtual DbSet<ProdottiSet> ProdottiSet { get; set; }
    }
}
