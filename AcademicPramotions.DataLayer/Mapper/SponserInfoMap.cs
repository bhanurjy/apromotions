using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademicPramotions.DataModels;

namespace AcademicPramotions.DataLayer
{
    public class SponserInfoMap : EntityTypeConfiguration<SponsorInfo>
    {
        public SponserInfoMap()
        {
            this.HasKey(t => t.SponsorId);
            this.ToTable("sponsorinfo");
            this.Property(t => t.SponsorId).HasColumnName("SponsorId");
            this.Property(t => t.SponsorName).HasColumnName("SponsorName");
            this.Property(t => t.SponsorEmail).HasColumnName("SponsorEmail");
            this.Property(t => t.SponsorAddress).HasColumnName("SponsorAddress");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Zip).HasColumnName("Zip");
            this.Property(t => t.BusinessName).HasColumnName("BusinessName");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.AlternatePhone).HasColumnName("AlternatePhone");
            this.Property(t => t.Fax).HasColumnName("Fax");
            this.Property(t => t.BusinessWebsite).HasColumnName("BusinessWebsite");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UserId).HasColumnName("UserId");
        }
    }
}
