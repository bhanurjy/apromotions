using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using AcademicPramotions.DataModels;

namespace AcademicPramotions.DataLayer
{
    public class SchoolInfoMap : EntityTypeConfiguration<SchoolInfo>
    {
        public SchoolInfoMap()
        {
            this.HasKey(t => t.SchoolInfoId);
            this.ToTable("schoolinfo");
            this.Property(t => t.SchoolInfoId).HasColumnName("SchoolInfoId");
            this.Property(t => t.SchoolName).HasColumnName("SchoolName");
            this.Property(t => t.SchoolFirstColor).HasColumnName("SchoolFirstColor");
            this.Property(t => t.SchoolSecondColor).HasColumnName("SchoolSecondColor");
            this.Property(t => t.MastCot).HasColumnName("MastCot");
            this.Property(t => t.SchoolAddress).HasColumnName("SchoolAddress");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.StateId).HasColumnName("StateId");
            this.Property(t => t.Zip).HasColumnName("Zip");
            this.Property(t => t.ShippingAddress).HasColumnName("ShippingAddress");
            this.Property(t => t.ShippingCity).HasColumnName("ShippingCity");
            this.Property(t => t.ShippingState).HasColumnName("ShippingState");
            this.Property(t => t.ShippingZip).HasColumnName("ShippingZip");
            this.Property(t => t.Telephone).HasColumnName("Telephone");
            this.Property(t => t.AlternateTelephone).HasColumnName("AlternateTelephone");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Website).HasColumnName("Website");
            this.Property(t => t.ContactNumber).HasColumnName("ContactNumber");
            this.Property(t => t.ContactTitle).HasColumnName("ContactTitle");
            this.Property(t => t.ItemsRequiredFor).HasColumnName("ItemsRequiredFor");
            this.Property(t => t.ReceiveItemsForYear).HasColumnName("ReceiveItemsForYear");
            this.Property(t => t.ItemsUsedFor).HasColumnName("ItemsUsedFor");
            this.Property(t => t.AnnounceSponcerName).HasColumnName("AnnounceSponcerName");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
        }
    }
}
