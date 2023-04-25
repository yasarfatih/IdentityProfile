using IdentityProfileApp.Context;
using IdentityProfileApp.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace IdentityProfileApp.Web.CustomProvider
{

    public class CustomRoleProvider : RoleProvider
    {
        public IdentityProfileAppContext _context = new IdentityProfileAppContext();
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            _context.Roles.Add(new Role()
            {
                Id = Guid.NewGuid(),
                Name = roleName
            });
            _context.SaveChanges();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            var role = _context.Roles.SingleOrDefault(x => x.Name.ToUpper() == roleName.ToUpper());
            if (role != null)
            {
                _context.Roles.Remove(role);
            }
            return 0 < _context.SaveChanges();
        }

        public override string[] FindUsersInRole(string roleName, string emailToMatch)
        {
            var roles = _context.UserInRoles.Include("Role").Include("User").Where(ur => ur.User.EmailAdress == emailToMatch)
              .Select(r => r.Role.Name).ToArray();
            return roles;
        }

        public override string[] GetAllRoles()
        {
            return _context.Roles.Select(r => r.Name).ToArray();
        }

        public override string[] GetRolesForUser(string email)
        {

            var rolesForUser = _context.UserInRoles.Include("Role").Include("User").Where(ur => ur.User.EmailAdress == email).Select(ur => ur.Role.Name).ToArray();
            return rolesForUser;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            var userInRoles = _context.UserInRoles.Include("Role").Include("User").Where(ur => ur.Role.Name == roleName).Select(ur => new { ur.User.Name, ur.User.Surname }).ToArray();
            string[] users = new string[userInRoles.Length];
            for (int i = 0; i < userInRoles.Length; i++)
            {
                users[i] = string.Format("{0} {1}", userInRoles[i].Name, userInRoles[i].Surname);
            }
            return users;
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            var roles = _context.UserInRoles.Include("Role").Include("User").Where(ur => ur.User.Name == username && ur.Role.Name == roleName).ToList();
            return 0 < roles.Count;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            for (int i = 0; i < roleNames.Length; i++)
            {
                for (int j = 0; j < usernames.Length; j++)
                {
                    var roles = _context.UserInRoles.Include("Role").Include("User").Where(ur => ur.User.Name == usernames[j] && ur.Role.Name == roleNames[i]).ToList();
                    _context.UserInRoles.RemoveRange(roles);
                }
                _context.SaveChanges();
            }

        }

        public override bool RoleExists(string roleName)
        {
            var role = _context.Roles.Any(r => r.Name == roleName);
            return role;
        }
    }
}