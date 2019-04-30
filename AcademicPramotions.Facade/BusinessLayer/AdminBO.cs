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
    public class AdminBO : IAdminBO
    {
        #region "Unitofwork Reference"
        IUnitOfWork _unitOfWork = null;

        public AdminBO(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
        }
        public AdminBO()
        {
            _unitOfWork = new UnitOfWork();
        }

        #endregion
        //To get the list of unapproved schools info
        public List<SchoolInfoVM> getUnapprovedSchoolsInfo()
        {
            try
            {
                var result = (from schoolinfo in _unitOfWork.Repository<SchoolInfo>().GetAll().Where(f => f.IsActive == 0)
                              join stateinfo in _unitOfWork.Repository<State>().GetAll()
                              on schoolinfo.StateId equals stateinfo.StateId
                              select new SchoolInfoVM
                              {
                                  SchoolName = schoolinfo.SchoolName,
                                  City = schoolinfo.City,
                                  StateName = stateinfo.StateName,
                                  Telephone = schoolinfo.Telephone,
                                  Email = schoolinfo.Email,
                                  Website = schoolinfo.Website,
                                  ContactTitle = schoolinfo.ContactTitle,
                                  SchoolInfoId = schoolinfo.SchoolInfoId
                              }).ToList();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //To get the list of registered schools info
        public List<SchoolInfoVM> getRegisteredSchoolInfo()
        {
            try
            {
                //var schoolinfo = _unitOfWork.Repository<SchoolInfo>().GetAll().ToList();
                //var stateinfo = _unitOfWork.Repository<State>().GetAll().ToList();
                var result = (from schoolinfo in _unitOfWork.Repository<SchoolInfo>().GetAll().Where(f=>f.IsActive == 1)
                              join stateinfo in _unitOfWork.Repository<State>().GetAll()
                              on schoolinfo.StateId equals stateinfo.StateId
                              select new SchoolInfoVM
                              {
                                  SchoolName = schoolinfo.SchoolName,
                                  City = schoolinfo.City,
                                  StateName = stateinfo.StateName,
                                  Telephone = schoolinfo.Telephone,
                                  Email = schoolinfo.Email,
                                  Website = schoolinfo.Website,
                                  ContactTitle = schoolinfo.ContactTitle
                              }).ToList();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //To get the list of registered sponsor info
        public List<SponsorInfoVM> getRegisteredSponsorInfo()
        {
            try
            {
                var result = (from sponsorinfo in _unitOfWork.Repository<SponsorInfo>().GetAll()
                              join stateinfo in _unitOfWork.Repository<State>().GetAll()
                              on sponsorinfo.State equals stateinfo.StateId
                              select new SponsorInfoVM
                              {
                                  SponsorName = sponsorinfo.SponsorName,
                                  BusinessName = sponsorinfo.BusinessName,
                                  SponsorEmail = sponsorinfo.SponsorEmail,
                                  City = sponsorinfo.City,
                                  StateName = stateinfo.StateName,
                                  Phone = sponsorinfo.Phone,
                                  BusinessWebsite = sponsorinfo.BusinessWebsite
                              }).ToList();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //To get the list of schools reqirements
        public IEnumerable<SchoolInfo> getSchoolsRequirements()
        {
            try
            {
                //var result = (from SchlReqs in _unitOfWork.Repository<SchoolRequirements>().GetAll()
                //              group SchlReqs by new { SchlReqs.SchoolId, SchlReqs.CreatedDate.Date, SchlReqs.Quantity, SchlReqs.ItemId} into lstSchoolReqs
                //              join schoolinfo in _unitOfWork.Repository<SchoolInfo>().GetAll()
                //              on lstSchoolReqs.Key.SchoolId equals schoolinfo.SchoolInfoId
                //              join items in _unitOfWork.Repository<Items>().GetAll()
                //              on lstSchoolReqs.Key.ItemId equals items.ItemId
                //          select new SchoolRequirementsVM
                //          {
                //              SchoolName = schoolinfo.SchoolName,
                //              ItemName = items.ItemName,
                //              Quantity = lstSchoolReqs.Key.Quantity,
                //              CreatedDate = lstSchoolReqs.Key.Date
                //          }).ToList();
                //return result;
                var result = _unitOfWork.Repository<SchoolInfo>().GetAll();
                return result;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //To update the approved schoolStatus
        public int approveSelectedSchools(int schoolId)
        {
            //To save values to User table
            var data = _unitOfWork.Repository<SchoolInfo>().GetAll().Where(f => f.SchoolInfoId == schoolId).FirstOrDefault();
            data.IsActive = 1;
            var userId = data.UserId;
            var userdata = _unitOfWork.Repository<Users>().GetAll().Where(f => f.UserId == userId).FirstOrDefault();
            userdata.IsActive = true;
            _unitOfWork.Repository<Users>().Update(userdata);
            _unitOfWork.Repository<SchoolInfo>().Update(data);
            _unitOfWork.Save();
            return 1;
        }

        //To get school requirements based on the school Id
        public List<SchoolRequirementsVM> getRequirementsbySchoolId(int schoolId)
        {
            var result = (from SchlReqs in _unitOfWork.Repository<SchoolRequirements>().GetAll().Where(f => f.SchoolId == schoolId)
                          group SchlReqs by new { SchlReqs.SchoolId, SchlReqs.CreatedDate.Date, SchlReqs.Quantity, SchlReqs.ItemId } into lstSchoolReqs
                          join schoolinfo in _unitOfWork.Repository<SchoolInfo>().GetAll()
                          on lstSchoolReqs.Key.SchoolId equals schoolinfo.SchoolInfoId
                          join items in _unitOfWork.Repository<Items>().GetAll()
                          on lstSchoolReqs.Key.ItemId equals items.ItemId
                          select new SchoolRequirementsVM
                          {
                              SchoolName = schoolinfo.SchoolName,
                              ItemName = items.ItemName,
                              Quantity = lstSchoolReqs.Key.Quantity,
                              CreatedDate = lstSchoolReqs.Key.Date
                          }).ToList();
            return result;
        }

        public List<SponseringDetailsVM> getUploadedArtwork()
        {
            var result = (from sposringInfo in _unitOfWork.Repository<SponseringDetails>().GetAll()
                          join schoolinfo in _unitOfWork.Repository<SchoolInfo>().GetAll()
                          on sposringInfo.SchoolId equals schoolinfo.SchoolInfoId
                          join sponsor in _unitOfWork.Repository<SponsorInfo>().GetAll()
                          on sposringInfo.SponserId equals sponsor.SponsorId
                          join sportsinfo in _unitOfWork.Repository<SportsInfo>().GetAll()
                          on sposringInfo.Sport equals sportsinfo.SportId
                          join season in _unitOfWork.Repository<Years>().GetAll()
                          on sposringInfo.Season equals season.YearId
                          select new SponseringDetailsVM
                          {
                              SchoolName = schoolinfo.SchoolName,
                              SponsorName = sponsor.SponsorName,
                              Invoice = sposringInfo.Invoice,
                              SportName = sportsinfo.SportName,
                              SeasonName = season.Year,
                              ItemsSponsering = sposringInfo.ItemsSponsering
                          }).ToList();
            return result;
        }
    }
}
