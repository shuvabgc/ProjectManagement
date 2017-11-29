using ProjectManagementSystem.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.Models.BLL
{
    public class ProjectBLL
    {
        PMSEntities dbObj = new PMSEntities();
        public int InsertUpdateProject(ProjectInformation model)
        {
            var count = dbObj.ProjectInformations.Count(a => a.vName == model.vName);

            if (count > 0)
            {
                // Update Project
                ProjectInformation projectInfo = dbObj.ProjectInformations.First(p => p.vName == model.vName);
                var oldFileNames = projectInfo.vFilesName;
                projectInfo.vCodeName = model.vCodeName;
                projectInfo.vStatus = model.vStatus;
                projectInfo.vDescription = model.vDescription;
                projectInfo.dStartDate = model.dStartDate;
                projectInfo.dEndDate = model.dEndDate;
                projectInfo.iDurationInDays = model.iDurationInDays;
                projectInfo.vFilesName = oldFileNames +" "+ model.vFilesName;
                projectInfo.vStatus = model.vStatus;
                dbObj.SaveChanges();
                var id = projectInfo.iID;
                return id;
            }
            else
            {
                // Insert Project
                ProjectInformation projectInfo = new ProjectInformation();
                projectInfo.vName = model.vName;
                projectInfo.vCodeName = model.vCodeName;
                projectInfo.vStatus = model.vStatus;
                projectInfo.vDescription = model.vDescription;
                projectInfo.dStartDate = model.dStartDate;
                projectInfo.dEndDate = model.dEndDate;
                projectInfo.iDurationInDays = model.iDurationInDays;
                projectInfo.vFilesName = model.vFilesName;
                projectInfo.vStatus = model.vStatus; ;
                dbObj.ProjectInformations.Add(projectInfo);
                dbObj.SaveChanges();
                var id = projectInfo.iID;
                return id;
            }
        }

        public List<ProjectInformation> GetProjectList()
        {
            return dbObj.ProjectInformations.ToList();
        }
        public List<AssignedPerson> GetAssignList()
        {
            return dbObj.AssignedPersons.ToList();
        }
        public void SaveAssignedPersonInfo(AssignedPerson model)
        {
            ProjectInformation projectInfo = dbObj.ProjectInformations.First(p => p.vName == model.vProjectName);
            var projectID = projectInfo.iID;

            User userInfo = dbObj.Users.First(p => p.vName == model.vAssignedPersonName);
            var userDesignation = userInfo.vDesignation;

            model.vAssignedPersonDesignation = userDesignation;
            model.iProjectID = projectID;

            AssignedPerson obj = new AssignedPerson();
            obj.iProjectID = model.iProjectID;
            obj.vProjectName = model.vProjectName;
            obj.vAssignedPersonName = model.vAssignedPersonName;
            obj.vAssignedPersonDesignation = model.vAssignedPersonDesignation;
            dbObj.AssignedPersons.Add(obj);
            dbObj.SaveChanges();
        }

    }
}