using MVCCrudIslemleri.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MVCCrudIslemleri.Data.Mappings
{
    public class CategoryMapping:EntityTypeConfiguration<Category>
    {
        public CategoryMapping()
        {
            HasKey<int>(x => x.Id); 

            Property(x => x.Id)
                .HasColumnName("KategoriId")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(x => x.Name)
                .HasMaxLength(50)
                .HasColumnName("Kategori Adi")
                .IsRequired()
                .IsUnicode()
                .HasColumnOrder(1);

           

            Property(x => x.Description)
                .HasMaxLength(200)
                .HasColumnName("Açiklama")
                .IsOptional()
                .IsUnicode()
                .HasColumnType("nvarchar")
                .HasColumnOrder(2);

            ToTable("Kategori Tablosu");    

        }
    }
}