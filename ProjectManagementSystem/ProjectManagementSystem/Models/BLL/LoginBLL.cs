using ProjectManagementSystem.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.Models.BLL
{
    public class LoginBLL
    {
        PMSEntities dbObj = new PMSEntities();
        public UserM getUserInfo(string email, string password)
        {
            UserM userInfo = new UserM();
            var query = from user in dbObj.Users
                        where user.vEmail == email && user.vPassword == password
                        select new UserM
                        {
                            iID = user.iID,
                            vName = user.vName,
                            vEmail = user.vEmail,
                            vDesignation = user.vDesignation,
                            vStatus = user.vStatus
                        };
            foreach (var bp in query)
            {
                userInfo.iID = bp.iID;
                userInfo.vName = bp.vName;
                userInfo.vEmail = bp.vEmail;
                userInfo.vDesignation = bp.vDesignation;
                userInfo.vStatus = bp.vStatus;
            }
            return userInfo;
        }
    }
}