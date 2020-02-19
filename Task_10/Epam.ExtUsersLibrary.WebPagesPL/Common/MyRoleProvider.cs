using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epam.ExtUsersLibrary.BLL.Ioc;
using System.Web.Security;

namespace Epam.ExtUsersLibrary.WebPagesPL.Common
{
    public class MyRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override bool IsUserInRole(string username, string roleName)
        {
            var visitorLogic = DependencyResolver.VisitorLogic;
            var user = visitorLogic.GetByLogin(username);
            if (user != null && user.Roles.Contains(roleName))
            {
                return true;
            }

            return false;
        }
        public override string[] GetRolesForUser(string username)
        {
            if (DefaultAdminChecker.CheckDefault(username))
            {
                return new string[] {"admin"};
            }
            var visitorLogic = DependencyResolver.VisitorLogic;
            var user = visitorLogic.GetByLogin(username);
            return user.Roles.ToArray();

        }

        #region NOT_IMPLEMENTED

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    #endregion
    }
}