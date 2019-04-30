using AcademicPramotions.Facade;
using AcademicPramotions.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademicPramotions.DataLayer;


namespace AcademicPramotions.Facade
{
    public class LoginBO : ILoginBO
    {
        #region "Unitofwork Reference"
        IUnitOfWork _unitOfWork = null;

        public LoginBO(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
        }
        public LoginBO()
        {
            _unitOfWork = new UnitOfWork();
        }

        #endregion

        public Users LoginUser(string UserName, string Password)
        {
            try
            {
                var result = _unitOfWork.Repository<Users>().GetAll().Where(f => (f.UserName == UserName) && f.IsActive == true && f.Password == Password).FirstOrDefault();
               
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        //To get the role Id
        public int getRoleId(string UserName)
        {
            return _unitOfWork.Repository<Users>().GetAll().Where(f => f.UserName == UserName).Select(f => f.RoleId).FirstOrDefault();
        }

        //To get the schoolId based on the userId in users table
        public int getSchoolId(int userId)
        {
            return _unitOfWork.Repository<SchoolInfo>().GetAll().Where(f => f.UserId == userId).Select(f => f.SchoolInfoId).FirstOrDefault();
        }
        //To get the sponsorId based on the userId in users table
        public int getSponsorId(int userId)
        {
            return _unitOfWork.Repository<SponsorInfo>().GetAll().Where(f => f.UserId == userId).Select(f => f.SponsorId).FirstOrDefault();
        }
    }
}
