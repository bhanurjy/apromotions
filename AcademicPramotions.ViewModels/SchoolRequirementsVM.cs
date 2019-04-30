using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicPramotions.ViewModels
{
    public class SchoolRequirementsVM
    {
        public int SchoolRequirementsId { get; set; }
        public int SchoolId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public string SchoolName { get; set; }
        public string ItemName { get; set; }
    }
}
