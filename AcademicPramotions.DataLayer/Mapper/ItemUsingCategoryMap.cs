using AcademicPramotions.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicPramotions.DataLayer
{
    public class ItemUsingCategoryMap : EntityTypeConfiguration<ItemUsingCategory>
    {
        public ItemUsingCategoryMap()
        {
            this.HasKey(t => t.ItemsUsedCategoryId);
            this.ToTable("itemusingcategory");
            this.Property(t => t.ItemsUsedCategoryId).HasColumnName("ItemsUsedCategoryId");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
