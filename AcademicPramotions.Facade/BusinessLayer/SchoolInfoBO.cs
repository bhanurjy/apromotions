using AcademicPramotions.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using AcademicPramotions.DataLayer;
using AcademicPramotions.DataModels;
using AcademicPramotions.ViewModels;

namespace AcademicPramotions.Facade
{
    public class SchoolInfoBO : ISchoolInfoBO
    {
        #region "Unitofwork Reference"
        IUnitOfWork _unitOfWork = null;

        public SchoolInfoBO (IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
        }
        public SchoolInfoBO()
        {
            _unitOfWork = new UnitOfWork();
        }

        #endregion

        public int SaveSchoolInfo(SchoolInfoVM scoolInfo)
        {
            try
            {
                //To save values to User table
                var data = _unitOfWork.Repository<Users>().ExecuteProcedure(" sp_users_INSERT(@UserName,@Password,@RoleId)",
                            new MySqlParameter("@UserName", MySqlDbType.VarChar) { Value = scoolInfo.UserName },
                            new MySqlParameter("@Password", MySqlDbType.VarChar) { Value = scoolInfo.Password },
                            new MySqlParameter("@RoleId", MySqlDbType.Int32) { Value = 2 });
                var userId = _unitOfWork.Repository<Users>().GetAll().Where(f => f.UserName == scoolInfo.UserName).FirstOrDefault().UserId;
                //To save values to school Info table
                var result = _unitOfWork.Repository<SchoolInfo>().ExecuteProcedure("Proc_SetSchoolInfo(@SchoolName,@SchoolFirstColor,@SchoolSecondColor,@MastCot,@SchoolAddress,@City,@Zip,@ShippingAddress,@ShippingCity,@ShippingState,@ShippingZip,@Telephone,@AlternateTelephone,@Email,@Website,@ContactNumber,@ContactTitle,@ItemsRequiredFor,@ReceiveItemsForYear,@ItemsUsedFor,@AnnounceSponcerName,@PStateId,@UserId,@IsActive)",
                             new MySqlParameter("@SchoolName", MySqlDbType.VarChar) { Value = scoolInfo.SchoolName },
                             new MySqlParameter("@SchoolFirstColor", MySqlDbType.VarChar) { Value = scoolInfo.SchoolFirstColor },
                             new MySqlParameter("@SchoolSecondColor", MySqlDbType.VarChar) { Value = scoolInfo.SchoolSecondColor },
                             new MySqlParameter("@MastCot", MySqlDbType.VarChar) { Value = scoolInfo.MastCot },
                             new MySqlParameter("@SchoolAddress", MySqlDbType.VarChar) { Value = scoolInfo.SchoolAddress },
                             new MySqlParameter("@City", MySqlDbType.VarChar) { Value = scoolInfo.City },
                             new MySqlParameter("@Zip", MySqlDbType.VarChar) { Value = scoolInfo.Zip },
                             new MySqlParameter("@ShippingAddress", MySqlDbType.VarChar) { Value = scoolInfo.ShippingAddress },
                             new MySqlParameter("@ShippingCity", MySqlDbType.VarChar) { Value = scoolInfo.ShippingCity },
                             new MySqlParameter("@ShippingState", MySqlDbType.Int32) { Value = scoolInfo.ShippingState },
                             new MySqlParameter("@ShippingZip", MySqlDbType.VarChar) { Value = scoolInfo.ShippingZip },
                             new MySqlParameter("@Telephone", MySqlDbType.VarChar) { Value = scoolInfo.Telephone },
                             new MySqlParameter("@AlternateTelephone", MySqlDbType.VarChar) { Value = scoolInfo.AlternateTelephone },
                             new MySqlParameter("@Email", MySqlDbType.VarChar) { Value = scoolInfo.Email },
                             new MySqlParameter("@Website", MySqlDbType.VarChar) { Value = scoolInfo.Website },
                             new MySqlParameter("@ContactNumber", MySqlDbType.VarChar) { Value = scoolInfo.ContactNumber },
                             new MySqlParameter("@ContactTitle", MySqlDbType.VarChar) { Value = scoolInfo.ContactTitle },
                             new MySqlParameter("@ItemsRequiredFor", MySqlDbType.VarChar) { Value = scoolInfo.ItemsRequiredFor },
                             new MySqlParameter("@ReceiveItemsForYear", MySqlDbType.VarChar) { Value = scoolInfo.ReceiveItemsForYear },
                             new MySqlParameter("@ItemsUsedFor", MySqlDbType.VarChar) { Value = scoolInfo.ItemsUsedFor },
                             new MySqlParameter("@AnnounceSponcerName", MySqlDbType.Bit) { Value = scoolInfo.AnnounceSponcerName },
                             new MySqlParameter("@PStateId", MySqlDbType.Int32) { Value = scoolInfo.StateId },
                             new MySqlParameter("@UserId", MySqlDbType.Int32) { Value = userId },
                             new MySqlParameter("@IsActive", MySqlDbType.Int32) { Value = 0}
                             );
                //var result = _unitOfWork.Repository<SchoolInfo>().ExecuteProcedure(" sp_test_INSERT(@TestName)",
                //            new MySqlParameter("@testname", MySqlDbType.VarChar) { Value = "Uma" });

                return result;
            }
            catch(Exception e)
            {
                return 0;
            }
        }

        //To validate user name existance in db or not
        public bool ValidateUserName(string username)
        {
            var result = _unitOfWork.Repository<Users>().GetAll().Where(f => f.UserName == username).FirstOrDefault();
            if (result != null)
            {
                return true;
            }
            else {
                return false;
            }
        }

        //to get the districts list
        public List<State> GetState()
        {
            var lstState = _unitOfWork.Repository<State>().GetAll().ToList();
            return lstState;
        }

        public int SaveSchoolRequirements(int ItemId, int quantity,int schoolId)
        {
            //To save values to school requirement table
            var result = _unitOfWork.Repository<SchoolRequirements>().ExecuteProcedure("sp_schoolRequirements_INSERT(@SchoolId,@ItemId,@Quantity)",
                        new MySqlParameter("@SchoolId", MySqlDbType.Int32) { Value = schoolId },
                        new MySqlParameter("@ItemId", MySqlDbType.Int32) { Value = ItemId },
                        new MySqlParameter("@Quantity", MySqlDbType.Int32) { Value = quantity });
            return result;
        }

        public List<SchoolRequirementsVM> GetPostedRequirementsBySchoolId(int schoolId)
        {
            //var lstSchoolReqs = _unitOfWork.Repository<SchoolRequirements>().GetAll().Where(f => f.SchoolId == schoolId).ToList();

            var result = (from lstSchoolReqs in _unitOfWork.Repository<SchoolRequirements>().GetAll().Where(f => f.SchoolId == schoolId)
                          //join schoolinfo in _unitOfWork.Repository<SchoolInfo>().GetAll()
                          //on lstSchoolReqs.SchoolId equals schoolinfo.SchoolInfoId
                          join items in _unitOfWork.Repository<Items>().GetAll()
                          on lstSchoolReqs.ItemId equals items.ItemId
                          select new SchoolRequirementsVM
                          {
                              ItemName = items.ItemName,
                              Quantity = lstSchoolReqs.Quantity,
                              CreatedDate = lstSchoolReqs.CreatedDate
                          }).ToList();
            return result;
            //return lstSchoolReqs;
        }
    }
}
