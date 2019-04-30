using AcademicPramotions.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicPramotions.Facade
{
    public interface ILoginBO
    {
        Users LoginUser(string UserName, string Password);
        int getRoleId(string UserName);
        int getSchoolId(int userId);
        int getSponsorId(int userId);
    }
}
