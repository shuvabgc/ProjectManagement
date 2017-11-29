using ProjectManagementSystem.Models;
using ProjectManagementSystem.Models.BLL;
using ProjectManagementSystem.Models.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        UserBLL objUser = new UserBLL();
        ProjectBLL objProject = new ProjectBLL();
        PMSEntities dbObj = new PMSEntities();
        public ActionResult Index(string userName, string uid, string status, string designation)
        {
            ViewBag.UserName = userName;
            ViewBag.UserID = uid;
            ViewBag.Status = status;
            ViewBag.Designation = designation;
            return View();
        }

        public ActionResult ManageUser(string userName, string uid, string status, string designation)
        {
            ViewBag.UserName = userName;
            ViewBag.UserID = uid;
            ViewBag.Status = status;
            ViewBag.Designation = designation;

            var userList = objUser.GetUserList();
            ViewBag.UserDetails = userList;
            return View();
        }

        [HttpPost]
        public ActionResult ManageUser(string userName, string uid, string status, string designation, User model)
        {
            ViewBag.UserName = userName;
            ViewBag.UserID = uid;
            ViewBag.Status = status;
            ViewBag.Designation = designation;

            objUser.InsertUpdateUser(model);
            var userList = objUser.GetUserList();
            ViewBag.UserDetails = userList;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        public ActionResult Logout()
        {
            return RedirectToAction("Index", "Login");
        }
        public JsonResult RestPassword(string email)
        {
            objUser.ResetPassword(email);
            return Json("", JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddProject (string userName, string uid, string status, string designation)
        {
            ViewBag.UserName = userName;
            ViewBag.UserID = uid;
            ViewBag.Status = status;
            ViewBag.Designation = designation;

            var projectList = objProject.GetProjectList();
            ViewBag.ProjectDetails = projectList;
            return View();
        }
        [HttpPost]
        public ActionResult AddProject(ProjectInformation model, HttpPostedFileBase postedFile, string userName, string uid, string status, string designation)
        {
            ViewBag.UserName = userName;
            ViewBag.UserID = uid;
            ViewBag.Status = status;
            ViewBag.Designation = designation;
            if (postedFile != null)
            {
                model.vFilesName = postedFile.FileName;
                int projectID = objProject.InsertUpdateProject(model);
                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                postedFile.SaveAs(path + projectID.ToString() + Path.GetFileName(postedFile.FileName));
                
            }
            else
            {
                int projectID2 = objProject.InsertUpdateProject(model);
            }

            var projectList = objProject.GetProjectList();
            ViewBag.ProjectDetails = projectList;
            return View();
        }

        public ActionResult AssignPerson(string userName, string uid, string status, string designation)
        {
            ViewBag.UserName = userName;
            ViewBag.UserID = uid;
            ViewBag.Status = status;
            ViewBag.Designation = designation;

            var content = from p in dbObj.ProjectInformations select new { p.iID, p.vName };
            var x = content.ToList().Select(c => new SelectListItem
                           {
                               Text = c.vName,
                               Value = c.vName,
                               Selected = (c.iID == 1)
                           }).ToList();
            ViewBag.ProjectList = x;

            var content2 = from p in dbObj.Users where p.vDesignation != "IT-Admin" select new { p.iID, p.vName };
            var x2 = content2.ToList().Select(c => new SelectListItem
                            {
                                Text = c.vName,
                                Value = c.vName,
                                Selected = (c.iID == 1)
                            }).ToList();
            ViewBag.UserList = x2;

            var assignList = objProject.GetAssignList();
            ViewBag.AssignDetails = assignList;
            return View();
        }

        [HttpPost]
        public ActionResult AssignPerson(AssignedPerson model, string userName, string uid, string status, string designation)
        {
            ViewBag.UserName = userName;
            ViewBag.UserID = uid;
            ViewBag.Status = status;
            ViewBag.Designation = designation;

            var content = from p in dbObj.ProjectInformations select new { p.iID, p.vName };
            var x = content.ToList().Select(c => new SelectListItem
            {
                Text = c.vName,
                Value = c.vName,
                Selected = (c.iID == 1)
            }).ToList();
            ViewBag.ProjectList = x;

            var content2 = from p in dbObj.Users where p.vDesignation != "IT-Admin" select new { p.iID, p.vName };
            var x2 = content2.ToList().Select(c => new SelectListItem
            {
                Text = c.vName,
                Value = c.vName,
                Selected = (c.iID == 1)
            }).ToList();
            ViewBag.UserList = x2;

            objProject.SaveAssignedPersonInfo(model);
            
            var assignList = objProject.GetAssignList();
            ViewBag.AssignDetails = assignList;

            return View();
        }
    }
}