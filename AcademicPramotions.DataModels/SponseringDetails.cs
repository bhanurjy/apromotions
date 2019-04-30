using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicPramotions.DataModels
{
    public class SponseringDetails
    {
        public int SponseringDetailsId { get; set; }
        public int SponserId { get; set; }
        public int SchoolId { get; set; }
        public string Invoice { get; set; }
        public int Sport { get; set; }
        public int Season { get; set; }
        public string ItemsSponsering { get; set; }
        public string UploadArt { get; set; }
        public string Instructions { get; set; }
    }
}
