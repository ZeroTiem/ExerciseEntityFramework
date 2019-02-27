using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseEntityFramework
{
    public class CustomerMap : EntityTypeConfiguration<TableTest>  
    {
        public CustomerMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            //this.Property(t => t.Name)
            //    .IsRequired()
            //    .HasMaxLength(256);

            //this.Property(t => t.Phone)
            //    .IsRequired()
            //    .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("Customer", "STORE");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Int1).HasColumnName("Int1");
            this.Property(t => t.Int2).HasColumnName("Int2");
            this.Property(t => t.Datetime1).HasColumnName("Datetime1");
            this.Property(t => t.Datetime2).HasColumnName("Datetime2");
            this.Property(t => t.Nvarchar1).HasColumnName("Nvarchar1");
            this.Property(t => t.Nvarchar2).HasColumnName("Nvarchar2");
            this.Property(t => t.Nvarchar3).HasColumnName("Nvarchar3");
            this.Property(t => t.Nvarchar4).HasColumnName("Nvarchar4");
            this.Property(t => t.Nvarchar5).HasColumnName("Nvarchar5");
            this.Property(t => t.Nvarchar6).HasColumnName("Nvarchar6");
        }
    }
}
