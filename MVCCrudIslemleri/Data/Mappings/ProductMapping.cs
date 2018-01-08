using MVCCrudIslemleri.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MVCCrudIslemleri.Data.Mappings
{
    
    public class ProductMapping:EntityTypeConfiguration<Product>
    {
         
        public ProductMapping()
        {
            ToTable("Ürün Tablosu");

            Property(x => x.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(20)
                .HasColumnName("Ürün Adi")
                .HasColumnOrder(1);

            Property(x => x.Price)
                .HasPrecision(16,2)
                .HasColumnName("Fiyat")
                .HasColumnType("decimal")
                .IsOptional() 
                .HasColumnOrder(2);

            Property(x => x.Stock)
                .HasColumnName("Stok Miktari")
                .HasColumnOrder(3)
                .HasColumnType("int");

            HasKey<int>(x => x.Id); // PK alanı tanımlama

            //HasRequired(x => x.Category)
            //    .WithMany(c => c.Products)
            //    .HasForeignKey<int>(x=> x.CategoryId);

        }
    }
}