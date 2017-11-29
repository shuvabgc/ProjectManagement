using ProjectManagementSystem.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.Models.BLL
{
    public class UserBLL
    {
        PMSEntities dbObj = new PMSEntities();
        public bool InsertUpdateUser(User model)
        {
            var count = dbObj.Users.Count(a => a.vEmail == model.vEmail);

            if (count > 0)
            {
                // Update User
                User user = dbObj.Users.First(p => p.vEmail == model.vEmail);
                user.vName = model.vName;
                user.vPassword = model.vPassword;
                user.vStatus = model.vStatus;
                user.vDesignation = model.vDesignation;
                dbObj.SaveChanges();
                return true;
            }
            else
            {
                // Insert User
                User user = new User();
                user.vName = model.vName;
                user.vEmail = model.vEmail;
                user.vPassword = model.vPassword;
                user.vStatus = model.vStatus;
                user.vDesignation = model.vDesignation;
                dbObj.Users.Add(user);
                dbObj.SaveChanges();
                return true;
            }
        }

        public List<User> GetUserList()
        {
            return dbObj.Users.ToList();
        }

        public void ResetPassword(string email)
        {
            User user = dbObj.Users.First(p => p.vEmail == email);
            user.vPassword = email+"123";
            dbObj.SaveChanges();
        }
    }
}