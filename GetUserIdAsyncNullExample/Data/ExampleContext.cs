using GetUserIdAsyncNullExample.Attributes;
using GetUserIdAsyncNullExample.Models;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GetUserIdAsyncNullExample.Data
{
    public class ExampleContext : IdentityDbContext<User, Role, Guid>
    {
        public ExampleContext(DbContextOptions<ExampleContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Call parent to implement Users DbSet
            base.OnModelCreating(builder);

            // Since we're using Guid primary keys, we need to give Core Identity a little kick to create the Ids
            builder.Entity<Role>().Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Id).ValueGeneratedOnAdd();

            AttachAttributes(builder.Model.GetEntityTypes());
        }

        // Sets the default values from the values in [DefaultAttribute]
        public static void AttachAttributes(IEnumerable<IMutableEntityType> entityTypes)
        {
            foreach (var entityType in entityTypes) {
                foreach (var property in entityType.GetProperties()) {
                    var memberInfo = property.PropertyInfo ?? (MemberInfo)property.FieldInfo;
                    var defaultValue = memberInfo?.GetCustomAttribute<DefaultValueAttribute>();
                    if (defaultValue != null) {
                        if (defaultValue.IsLiteral) {
                            property.SqlServer().DefaultValue = defaultValue.Value;
                        } else {
                            property.SqlServer().DefaultValueSql = defaultValue.Value;
                        }
                    }
                }
            }
        }
    }
}
