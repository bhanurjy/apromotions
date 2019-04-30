using AcademicPramotions.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicPramotions.DataLayer.Mapper
{
    public class SportsInfoMap : EntityTypeConfiguration<SportsInfo>
    {
        public SportsInfoMap()
        {
            this.HasKey(t => t.SportId);
            this.ToTable("sportsinfo");
            this.Property(t => t.SportId).HasColumnName("SportId");
            this.Property(t => t.SportName).HasColumnName("SportName");
        }
    }
}
