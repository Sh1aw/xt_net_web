using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epam.ExtUsersLibrary.BLL.Ioc;
using System.Web.Security;
using Epam.ExtUsersLibrary.BLL.Interfaces;
using Epam.ExtUsersLibrary.Entities;

namespace Epam.ExtUsersLibrary.WebPagesPL.Common
{
    public class MyRoleProvider : RoleProvider
    {
        private IVisitorLogic _visitorLogic = DependencyResolver.VisitorLogic;
        private IRoleLogic _roleLogic = DependencyResolver.RoleLogic;
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override bool IsUserInRole(string username, string roleName)
        {
            var visitor = _visitorLogic.GetByLogin(username);
            if (visitor!=null && visitor.IdRole!=null)
            {
                var visitorRole = _roleLogic.GetRoleById(visitor.IdRole??default);
                if (visitorRole.Name.Equals(roleName))
                {
                    return true;
                }

                return false;
            }

            return false;

        }
        public override string[] GetRolesForUser(string username)
        {
            if (DefaultAdminChecker.CheckDefault(username))
            {
                return new string[] { "admin" };
            }

            var visitor = _visitorLogic.GetByLogin(username);
            if (visitor!=null && visitor.IdRole!=null)
            {
                var role = _roleLogic.GetRoleById(visitor.IdRole ?? default);
                return new string[] {role.Name};
                //return new string[] {"user"};
            }
            else
            {
                return new string[] {};
            }
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