using AcademicPramotions.DataLayer;
using AcademicPramotions.DataModels;
using AcademicPramotions.ViewModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicPramotions.Facade
{
    public class SponsorBO : ISponsorBO
    {
        #region "Unitofwork Reference"
        IUnitOfWork _unitOfWork = null;

        public SponsorBO (IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
        }
        public SponsorBO()
        {
            _unitOfWork = new UnitOfWork();
        }

        #endregion

        public int saveSponsorInfo(SponsorInfoVM sponsorinfo)
        {
            sponsorinfo.SponsorName = sponsorinfo.FirstName + " " + sponsorinfo.LastName;
            //To save values to User table
            var data = _unitOfWork.Repository<Users>().ExecuteProcedure(" sp_users_INSERT(@UserName,@Password,@RoleId)",
                        new MySqlParameter("@UserName", MySqlDbType.VarChar) { Value = sponsorinfo.UserName },
                        new MySqlParameter("@Password", MySqlDbType.VarChar) { Value = sponsorinfo.Password },
                        new MySqlParameter("@RoleId", MySqlDbType.Int32) { Value = 3 });
            var userId = _unitOfWork.Repository<Users>().GetAll().Where(f => (f.UserName == sponsorinfo.UserName) && f.RoleId == 3).FirstOrDefault().UserId;
            //To save values to school Info table
            var result = _unitOfWork.Repository<SponsorInfo>().ExecuteProcedure("sp_sponsors_INSERT(@SponsorName,@SponsorEmail,@SponsorAddress,@City,@State,@Zip,@BusinessName,@Phone,@AlternatePhone,@Fax,@BusinessWebsite,@UserId)",
                         new MySqlParameter("@SponsorName", MySqlDbType.VarChar) { Value = sponsorinfo.SponsorName },
                         new MySqlParameter("@SponsorEmail", MySqlDbType.VarChar) { Value = sponsorinfo.SponsorEmail },
                         new MySqlParameter("@SponsorAddress", MySqlDbType.VarChar) { Value = sponsorinfo.SponsorAddress },
                         new MySqlParameter("@City", MySqlDbType.VarChar) { Value = sponsorinfo.City },
                         new MySqlParameter("@State", MySqlDbType.Int32) { Value = sponsorinfo.State },
                         new MySqlParameter("@Zip", MySqlDbType.VarChar) { Value = sponsorinfo.Zip },
                         new MySqlParameter("@BusinessName", MySqlDbType.VarChar) { Value = sponsorinfo.BusinessName },
                         new MySqlParameter("@Phone", MySqlDbType.VarChar) { Value = sponsorinfo.Phone },
                         new MySqlParameter("@AlternatePhone", MySqlDbType.VarChar) { Value = sponsorinfo.AlternatePhone },
                         new MySqlParameter("@Fax", MySqlDbType.VarChar) { Value = sponsorinfo.Fax },
                         new MySqlParameter("@BusinessWebsite", MySqlDbType.VarChar) { Value = sponsorinfo.BusinessWebsite },
                         new MySqlParameter("@UserId", MySqlDbType.Int32) { Value = userId }
                         );
           //To active the sponsor registered
            var userDetails = _unitOfWork.Repository<Users>().GetAll().Where(f => f.UserId == userId).FirstOrDefault();
            userDetails.IsActive = true;
            _unitOfWork.Repository<Users>().Update(userDetails);
            _unitOfWork.Save();
            return result;
        }

        //To validate user name existance in db or not
        public bool ValidateUserName(string username)
        {
            var result = _unitOfWork.Repository<Users>().GetAll().Where(f => f.UserName == username).FirstOrDefault();
            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Items> GetSponsoringItems()
        {
            var lstSponseringItems = _unitOfWork.Repository<Items>().GetAll().ToList();
            return lstSponseringItems;
        }

        public List<SportsInfo> GetSportsInfo()
        {
            var lstSportsInfo = _unitOfWork.Repository<SportsInfo>().GetAll().ToList();
            return lstSportsInfo;
        }

        public List<Years> GetSeasonInfo()
        {
            var lstSeasonInfo = _unitOfWork.Repository<Years>().GetAll().ToList();
            return lstSeasonInfo;
        }

        public List<SchoolInfo> GetSchoolInfo()
        {
            var lstschoolInfo = (from sinfo in _unitOfWork.Repository<SchoolInfo>().GetAll()
                select new SchoolInfo{
                    SchoolInfoId = sinfo.SchoolInfoId,
                    SchoolName = sinfo.SchoolName
                }).ToList();
            return lstschoolInfo;
        }

        //To save the uploaded artwork info
        public int UploadArtworkInfo(SponseringDetails sponseringDetails)
        {
            try
            {
                //sponseringDetails.SponserId = 1;
                //To save values to school Info table
                var result = _unitOfWork.Repository<SponseringDetails>().ExecuteProcedure("sp_sponsoringDetails_INSERT(@SponserId,@SchoolId,@Invoice,@Sport,@Season,@ItemsSponsering,@UploadArt,@Instructions)",
                             new MySqlParameter("@SponserId", MySqlDbType.Int32) { Value = sponseringDetails.SponserId },
                             new MySqlParameter("@SchoolId", MySqlDbType.Int32) { Value = sponseringDetails.SchoolId },
                             new MySqlParameter("@Invoice", MySqlDbType.VarChar) { Value = sponseringDetails.Invoice },
                             new MySqlParameter("@Sport", MySqlDbType.Int32) { Value = sponseringDetails.Sport },
                             new MySqlParameter("@Season", MySqlDbType.Int32) { Value = sponseringDetails.Season },
                             new MySqlParameter("@ItemsSponsering", MySqlDbType.VarChar) { Value = sponseringDetails.ItemsSponsering },
                             new MySqlParameter("@UploadArt", MySqlDbType.Text) { Value = sponseringDetails.UploadArt },
                             new MySqlParameter("@Instructions", MySqlDbType.VarChar) { Value = sponseringDetails.Instructions }
                             );
                return result;
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }
    }
}
