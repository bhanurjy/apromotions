using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicPramotions.DataModels
{
    public class SponsorInfo
    {
        public int SponsorId { get; set; }
        public string SponsorName { get; set; }
        public string SponsorEmail { get; set; }
        public string SponsorAddress { get; set; }
        public string City { get; set; }
        public int State { get; set; }
        public string Zip { get; set; }
        public string BusinessName { get; set; }
        public string Phone { get; set; }
        public string AlternatePhone { get; set; }
        public string Fax { get; set; }
        public string BusinessWebsite { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
    }
}
