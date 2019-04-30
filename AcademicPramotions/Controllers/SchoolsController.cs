using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcademicPramotions.DataModels;
using AcademicPramotions.Facade;
using AcademicPramotions.ViewModels;

namespace AcademicPramotions.Controllers
{
    public class SchoolsController : Controller
    {
        #region constructor ref

        ISchoolInfoBO _schoolInfoBO= null;
        public SchoolsController(ISchoolInfoBO _schoolInfoBO)
        {
            this._schoolInfoBO = _schoolInfoBO;
        }

        public SchoolsController()
        {
            _schoolInfoBO = new SchoolInfoBO();
        }
        #endregion

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignUpForm()
        {
            return View();
        }

        public JsonResult SaveSchoolInfo(SchoolInfoVM scoolInfo)
        {
            var result = _schoolInfoBO.SaveSchoolInfo(scoolInfo);
            return Json(result, JsonRequestBehavior.AllowGet);
            //return Json(null, JsonRequestBehavior.AllowGet);
        }

        //To get the districts from the database
        public JsonResult GetState()
        {
            var data = _schoolInfoBO.GetState();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //To Show the school dashboard
        public ActionResult SchoolDashBoard()
        {
            return View();
        }
        
        //To show the page for posting the requiremenmts
        public ActionResult PostRequirements()
        {
            return View();
        }

        //To view the requirements posted by that school
        public ActionResult ViewPostedRequirements()
        {
            int schoolId = Convert.ToInt32(Session["SchoolId"]);
            var result = _schoolInfoBO.GetPostedRequirementsBySchoolId(schoolId);
            return View(result);
        }

        //To validate username exist in db or not
        [HttpPost]
        public JsonResult ValidateUserName( string UserName)
        {
            var resuult = _schoolInfoBO.ValidateUserName(UserName);
            return Json(resuult, JsonRequestBehavior.AllowGet);
        }

        //To save the posted requiremnts from the school
        public ActionResult SaveSchoolRequirementsInfo(SchoolRequirementVM requirements)
        {
            int quantity = 0;
            int ItemId = 0;
            int schoolId = Convert.ToInt32(Session["SchoolId"]);

            if (requirements.RallyTowels != null)
            {
                ItemId = 1;
                _schoolInfoBO.SaveSchoolRequirements(ItemId, Convert.ToInt32(requirements.RallyTowels), schoolId);
            }
            if (requirements.Megaphones != null)
            {
                ItemId = 2;
                _schoolInfoBO.SaveSchoolRequirements(ItemId, Convert.ToInt32(requirements.Megaphones), schoolId);
            }
            if (requirements.Banners != null)
            {
                ItemId = 3;
                _schoolInfoBO.SaveSchoolRequirements(ItemId, Convert.ToInt32(requirements.Banners), schoolId);
            }
            if (requirements.SeatCushions != null)
            {
                ItemId = 4;
                _schoolInfoBO.SaveSchoolRequirements(ItemId, Convert.ToInt32(requirements.SeatCushions), schoolId);
            }
            if (requirements.ToteBags != null)
            {
                ItemId = 5;
                _schoolInfoBO.SaveSchoolRequirements(ItemId, Convert.ToInt32(requirements.ToteBags), schoolId);
            }
            if (requirements.PomPoms != null)
            {
                ItemId = 6;
                _schoolInfoBO.SaveSchoolRequirements(ItemId, Convert.ToInt32(requirements.PomPoms), schoolId);
            }
            if (requirements.ThunderSticks != null)
            {
                ItemId = 7;
                _schoolInfoBO.SaveSchoolRequirements(ItemId, Convert.ToInt32(requirements.ThunderSticks), schoolId);
            }
            if (requirements.SportsBottles != null)
            {
                ItemId = 8;
                _schoolInfoBO.SaveSchoolRequirements(ItemId, Convert.ToInt32(requirements.SportsBottles), schoolId);
            }
            if (requirements.Cups != null)
            {
                ItemId = 9;
                _schoolInfoBO.SaveSchoolRequirements(ItemId, Convert.ToInt32(requirements.Cups), schoolId);
            }
            if (requirements.SpiritBeads != null)
            {
                ItemId = 10;
                _schoolInfoBO.SaveSchoolRequirements(ItemId, Convert.ToInt32(requirements.SpiritBeads), schoolId);
            }
            if (requirements.TShirts != null)
            {
                ItemId = 11;
                _schoolInfoBO.SaveSchoolRequirements(ItemId, Convert.ToInt32(requirements.TShirts), schoolId);
            }
            if (requirements.Miniballs != null)
            {
                ItemId = 12;
                _schoolInfoBO.SaveSchoolRequirements(ItemId, Convert.ToInt32(requirements.Miniballs), schoolId);
            }
            if (requirements.CarFlags != null)
            {
                ItemId = 13;
                _schoolInfoBO.SaveSchoolRequirements(ItemId, Convert.ToInt32(requirements.CarFlags), schoolId);
            }
            if (requirements.CollapsableMegaphones != null)
            {
                ItemId = 14;
                _schoolInfoBO.SaveSchoolRequirements(ItemId, Convert.ToInt32(requirements.CollapsableMegaphones), schoolId);
            }
            return RedirectToAction("PostRequirements");
        }
    }
}
