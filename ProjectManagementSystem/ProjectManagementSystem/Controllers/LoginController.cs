using ProjectManagementSystem.Models;
using ProjectManagementSystem.Models.BLL;
using ProjectManagementSystem.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        LoginBLL objLogin = new LoginBLL();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User model)
        {
            if (model.vEmail != null && model.vPassword != null)
            {
                UserM userInfo = objLogin.getUserInfo(model.vEmail, model.vPassword);
                return RedirectToAction("Index", "Home", new { userName = userInfo.vName, uid = userInfo.iID.ToString(), status = userInfo.vStatus, designation = userInfo.vDesignation });
            }
            return View(model);
        }
	}
}