﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GiftPoint.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class GiftPointEntities : DbContext
    {
        public GiftPointEntities()
            : base("name=GiftPointEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenusConfiguration> MenusConfigurations { get; set; }
        public virtual DbSet<MenusRight> MenusRights { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<vw_Categories> vw_Categories { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
    
        public virtual ObjectResult<usp_ParentCategories_Result> usp_ParentCategories()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_ParentCategories_Result>("usp_ParentCategories");
        }
    }
}
