using AcademicPramotions.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicPramotions.DataLayer
{
    public class YearsMap : EntityTypeConfiguration<Years>
    {
        public YearsMap()
        {
            this.HasKey(t => t.YearId);
            this.ToTable("years");
            this.Property(t => t.YearId).HasColumnName("YearId");
            this.Property(t => t.Year).HasColumnName("Year");
        }
    }
}
