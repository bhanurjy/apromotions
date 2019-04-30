using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademicPramotions.DataModels;

namespace AcademicPramotions.DataLayer
{
    public class SchoolRequirementsMap : EntityTypeConfiguration<SchoolRequirements>
    {
        public SchoolRequirementsMap()
        {
            this.HasKey(t => t.SchoolRequirementsId);
            this.ToTable("schoolrequirements");
            this.Property(t => t.SchoolRequirementsId).HasColumnName("SchoolRequirementsId");
            this.Property(t => t.SchoolId).HasColumnName("SchoolId");
            this.Property(t => t.ItemId).HasColumnName("ItemId");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
        }
    }
}
