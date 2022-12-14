//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModeleEntite
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class AdvContext : DbContext
    {
        public AdvContext()
            : base("name=AdvContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductSubcategory> ProductSubcategories { get; set; }
        public virtual DbSet<Person> People { get; set; }
    
        public virtual ObjectResult<Person> GetTopN(string data)
        {
            var dataParameter = data != null ?
                new ObjectParameter("data", data) :
                new ObjectParameter("data", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Person>("GetTopN", dataParameter);
        }
    
        public virtual ObjectResult<Person> GetTopN(string data, MergeOption mergeOption)
        {
            var dataParameter = data != null ?
                new ObjectParameter("data", data) :
                new ObjectParameter("data", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Person>("GetTopN", mergeOption, dataParameter);
        }
    }
}
