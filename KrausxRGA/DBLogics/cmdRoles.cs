﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KrausRGA.Models;
using KrausRGA.EntityModel;
using KrausRGA.ErrorLogger;

namespace KrausRGA.DBLogics
{
    /// <summary>
    /// Avinash: 1Nov2013
    /// Role information get set functions for database.
    /// </summary>
   public class cmdRoles
    {
       /// <summary>
       /// RMA Database ovbject.
       /// </summary>
      // RMASYSTEMEntities entRMA = new RMASYSTEMEntities();

        #region Get fucntions of Role class.

       /// <summary>
       /// Gives the whole table information of user.
       /// </summary>
       /// <returns>
       /// List of user onformation
       /// </returns>
       public List<Role> GetRoles()
       {
           List<Role> _lsRuturn = new List<Role>();

           try
           {
               var Rolesinfo = Service.entGet.RoleAll();
               foreach (var roleitem in Rolesinfo)
               {
                   Role roles = new Role(roleitem);
                   //roles = (Role)Rolesinfo;
                   _lsRuturn.Add(roles);
               }
           }
           catch (Exception ex)
           {
               ex.LogThis("cmdRoles/GetRoles");
           }

           return _lsRuturn;
       }

       /// <summary>
       /// Gives the role information filtred by RoleID
       /// </summary>
       /// <param name="RoleID">
       /// String RoleID.
       /// </param>
       /// <returns>
       /// Role Class Object with filtred RoleID Information
       /// else Null.
       /// </returns>
       public Role GetRole(Guid RoleID)
       {
           Role role = new Role();
           try
           {
               role = new Role(Service.entGet.RoleByRoleID(RoleID));
           }
           catch (Exception ex)
           {
               ex.LogThis("cmdRoles/GetRole(Guid RoleID)");
           }
           return role;
       }

       /// <summary>
       /// Check That user IsAdmin User Or Not.
       /// </summary>
       /// <param name="UserID">
       /// Guid UserID
       /// </param>
       /// <returns>
       /// Boolean True Or Flase;
       /// </returns>
       public Boolean IsSuperUser(Guid UserID)
       {
           Boolean _return = true;

           try
           {
               Guid RoleID = Service.entGet.UserByUserID(UserID).RoleID;
                   //Service.Users.FirstOrDefault(i => i.UserID == UserID).RoleId;

               String Action = Service.entGet.RoleByRoleID(RoleID).Action.ToString();
                 //  ent.Roles.FirstOrDefault(i => i.RoleId == RoleID).Action.ToString();
               string[] isAdmin = Action.Split('&')[0].Split('-');
               foreach (String Act in isAdmin)
               {
                   if (Act.ToUpper() == "FALSE")
                   {
                       _return = false;
                       break;
                   }
               }
           }
           catch (Exception)
           { }

           return _return;
       }

        #endregion

    }
}
