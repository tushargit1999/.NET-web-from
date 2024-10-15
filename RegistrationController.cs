using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecommerce.Models;

namespace Ecommerce.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult RegistrationIndex()
        {
            return View();
        }
        public ActionResult SaveRegistration(RegistrationModel model)
        {
            try
            {
                return Json(new { message = new RegistrationModel().SaveRegistration(model) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception EX)
            {
                return Json(new { EX.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ListRegistration()
        {
            try
            {
                return Json(new { model = (new RegistrationModel().ListRegistration()) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception EX)
            {
                return Json(new { EX.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult EditRegistration(int Registration_ID)
        {
            try
            {
                return Json(new { model = new RegistrationModel().EditRegistration(Registration_ID) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception EX)
            {
                return Json(new { EX.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult DeleteRegistration(int Registration_ID)
        {
            try
            {
                return Json(new { model = (new RegistrationModel().DeleteRegistration(Registration_ID)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception EX)
            {
                return Json(new { EX.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Details(int Registration_ID)
        {
            ViewBag.Registration_ID = Registration_ID;
            return View();
        }

        public ActionResult GetDetails(int Registration_ID)
        {
            try
            {
                return Json(new { model = new RegistrationModel().GetDetails(Registration_ID) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception EX)
            {
                return Json(new { EX.Message }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}