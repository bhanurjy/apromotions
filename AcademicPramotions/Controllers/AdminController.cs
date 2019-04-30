using AcademicPramotions.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcademicPramotions.Controllers
{
    public class AdminController : Controller
    {
        #region "Unitofwork Reference"

        IAdminBO _adminBO = null;

        public AdminController(IAdminBO adminBO)
        {
            this._adminBO = adminBO;
        }
        public AdminController()
        {
            _adminBO = new AdminBO();
        }

        #endregion
        //To get all the registered School details
        [HttpGet]
        public ActionResult GetRegisteredSchoolInfo()
        {
           var result = _adminBO.getRegisteredSchoolInfo();
           return View(result);
        }

        //To get all unapproved School details
        [HttpGet]
        public ActionResult GetUnapprovedSchoolInfo()
        {
            var result = _adminBO.getUnapprovedSchoolsInfo();
            return View(result);
        }

        //To get all the registered Sponsors
        public ActionResult GetRegisteredSponsorInfo()
        {
            var result = _adminBO.getRegisteredSponsorInfo();
            return View(result);
        }

        //To get the schools Requirements information
        public ActionResult GetSchoolsRequirementsInfo()
        {
            var result = _adminBO.getSchoolsRequirements();
            return View(result);
        }
		
        //To approve the selected schools
        public JsonResult ApproveSchools(string selectedSchools)
        {
            var SchoolsArray = selectedSchools.Split(',');
            var result = 1;
            foreach (var school in SchoolsArray)
            {
                result = _adminBO.approveSelectedSchools(Convert.ToInt32(school));
                if (result != 1)
                {
                    result = 0;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //To get school Requirements by School Id to display in admin
        public ActionResult GetSchoolRequiremetsbyId(int schoolId)
        {
            var data = _adminBO.getRequirementsbySchoolId(schoolId);
            return View(data);
        }

        //To get Uploaded Artwork
        public ActionResult GetUploadedArtwork()
        {
            var result = _adminBO.getUploadedArtwork();
            return View(result);
        }
    }
}
