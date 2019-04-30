using AcademicPramotions.DataModels;
using AcademicPramotions.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicPramotions.Facade
{
    public interface ISponsorBO
    {
        int saveSponsorInfo(SponsorInfoVM sponsorinfo);
        List<Items> GetSponsoringItems();
        List<SportsInfo> GetSportsInfo();
        List<Years> GetSeasonInfo();
        List<SchoolInfo> GetSchoolInfo();
        int UploadArtworkInfo(SponseringDetails sponseringDetails);
        bool ValidateUserName(string username);
    }
}
