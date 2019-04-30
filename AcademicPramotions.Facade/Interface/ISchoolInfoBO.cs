using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademicPramotions.DataModels;
using AcademicPramotions.ViewModels;

namespace AcademicPramotions.Facade
{
    public interface ISchoolInfoBO
    {
        int SaveSchoolInfo(SchoolInfoVM scoolInfo);
        List<State> GetState();
        int SaveSchoolRequirements(int ItemId, int quantity, int schoolId);
        List<SchoolRequirementsVM> GetPostedRequirementsBySchoolId(int schoolId);
        bool ValidateUserName(string username);
    }
}
