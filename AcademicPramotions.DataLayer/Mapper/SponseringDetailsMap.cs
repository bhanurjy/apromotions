using AcademicPramotions.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicPramotions.DataLayer
{
    public class SponseringDetailsMap : EntityTypeConfiguration<SponseringDetails>
    {
        public SponseringDetailsMap()
        {
            this.HasKey(t => t.SponseringDetailsId);
            this.ToTable("sponseringdetails");
            this.Property(t => t.SponseringDetailsId).HasColumnName("SponseringDetailsId");
            this.Property(t => t.SponserId).HasColumnName("SponserId");
            this.Property(t => t.SchoolId).HasColumnName("SchoolId");
            this.Property(t => t.Invoice).HasColumnName("Invoice");
            this.Property(t => t.Sport).HasColumnName("Sport");
            this.Property(t => t.Season).HasColumnName("Season");
            this.Property(t => t.ItemsSponsering).HasColumnName("ItemsSponsering");
            this.Property(t => t.UploadArt).HasColumnName("UploadArt");
            this.Property(t => t.Instructions).HasColumnName("Instructions");
        }
    }
}
