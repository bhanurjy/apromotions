using AcademicPramotions.Facade;
using AcademicPramotions.ViewModels;
using AcademicPramotions.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcademicPramotions.Controllers
{
    public class SponsorController : Controller
    {
        #region constructor ref

        ISponsorBO _sponsorBO= null;
        public SponsorController(ISponsorBO _sponsorBO)
        {
            this._sponsorBO = _sponsorBO;
        }

        public SponsorController()
        {
            _sponsorBO = new SponsorBO();
        }
        #endregion

        public ActionResult SponsorRegistration()
        {
            return View();
        }

        public int SaveSponsorInfo(SponsorInfoVM sponsorinfo)
        {
            var result = _sponsorBO.saveSponsorInfo(sponsorinfo);
            return result;
        }

        public ActionResult UploadArtWork()
        {
            return View();
        }

        public ActionResult getSponsoringItems()
        {
            var data = _sponsorBO.GetSponsoringItems();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getSportsInfo()
        {
            var data = _sponsorBO.GetSportsInfo();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getSeasonInfo()
        {
            var data = _sponsorBO.GetSeasonInfo();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public int UploadArtworkInfo(SponseringDetails sponsoringdetails)
        {
            var sponsorId = Convert.ToInt32(Session["SponsorId"]);
            sponsoringdetails.SponserId = sponsorId;
            var result = _sponsorBO.UploadArtworkInfo(sponsoringdetails);
            return result;
        }

        //To get the list of school name sfor prepopulating
        public ActionResult getSchoolInfo()
        {
            var data = _sponsorBO.GetSchoolInfo();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //To display the sponsor dashboard
        public ActionResult SponsorDashBoard()
        {
            return View();
        }

        //To validate username exist in db or not
        [HttpPost]
        public JsonResult ValidateUserName(string UserName)
        {
            var resuult = _sponsorBO.ValidateUserName(UserName);
            return Json(resuult, JsonRequestBehavior.AllowGet);
        }
    }
}
