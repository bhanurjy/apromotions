using AcademicPramotions.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicPramotions.DataLayer.Mapper
{
    public class StateMap : EntityTypeConfiguration<State>
    {
        public StateMap()
        {
            this.HasKey(t => t.StateId);
            this.ToTable("state");
            this.Property(t => t.StateId).HasColumnName("StateId");
            this.Property(t => t.StateName).HasColumnName("StateName");
        }
    }
}
