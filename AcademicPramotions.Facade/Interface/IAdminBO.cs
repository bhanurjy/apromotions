using AcademicPramotions.DataModels;
using AcademicPramotions.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicPramotions.Facade
{
    public interface IAdminBO
    {
        List<SchoolInfoVM> getRegisteredSchoolInfo();
        List<SponsorInfoVM> getRegisteredSponsorInfo();
        IEnumerable<SchoolInfo> getSchoolsRequirements();
        List<SchoolRequirementsVM> getRequirementsbySchoolId(int schoolId);
        List<SchoolInfoVM> getUnapprovedSchoolsInfo();
        int approveSelectedSchools(int schoolId);
        List<SponseringDetailsVM> getUploadedArtwork();
    }
}
