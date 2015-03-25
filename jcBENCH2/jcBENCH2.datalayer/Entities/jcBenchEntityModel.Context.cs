﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace jcBENCH2.datalayer.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class CodeCamp_jcBenchEntities : DbContext
    {
        public CodeCamp_jcBenchEntities()
            : base("name=CodeCamp_jcBenchEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<BenchmarkResult> BenchmarkResults { get; set; }
    
        public virtual ObjectResult<getTopResults_Result> getTopResults(Nullable<int> numResults)
        {
            var numResultsParameter = numResults.HasValue ?
                new ObjectParameter("numResults", numResults) :
                new ObjectParameter("numResults", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getTopResults_Result>("getTopResults", numResultsParameter);
        }
    }
}