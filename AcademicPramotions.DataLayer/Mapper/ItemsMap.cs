using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademicPramotions.DataModels;

namespace AcademicPramotions.DataLayer
{
    public class ItemsMap : EntityTypeConfiguration<Items>
    {
        public ItemsMap()
        {
            this.HasKey(t => t.ItemId);
            this.ToTable("items");
            this.Property(t => t.ItemId).HasColumnName("ItemId");
            this.Property(t => t.ItemName).HasColumnName("ItemName");
        }
    }
}
