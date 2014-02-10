﻿using KrausRGA.EntityModel;
using KrausRGA.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KrausRGA.ErrorLogger;

namespace KrausRGA.DBLogics
{
    /// <summary>
    /// Avinash: 31 Oct 2013
    /// Get Operations Performed on sage x3v6 the database of BI server.
    /// </summary>
   public class cmdSageOperations
    {

       /// <summary>
       /// Database object of x3v6 from BI server.
       /// </summary>
     //  x3v6Entities entX3V6 = new x3v6Entities();

       /// <summary>
       /// Get RMA details from the sage by SRNumber.
       /// </summary>
       /// <param name="SRNumber">
       /// String SRNumber. must be valied.
       /// </param>
       /// <returns>
       /// list of RMAInfo class related to entered SRNumber.
       /// </returns>
       public List<RMAInfo> GetRMAInfoBySRNumber(String SRNumber)
       {
           List<RMAInfo> lsRMAInfo = new List<RMAInfo>();
           try
           {
               var RMAdetailsInfo = Service.entGet.RMAInfoBySRNumber(SRNumber).ToList();
               if (RMAdetailsInfo.Count()>0)
               {
                   foreach (var RMAitem in RMAdetailsInfo)
                   {
                       lsRMAInfo.Add(new RMAInfo(RMAitem));
                   }
               }
           }
           catch (Exception ex)
           {
               ex.LogThis("cmdSageOperations/GetRMAInfoBySRNumber");
           }
           return lsRMAInfo;
       }

       /// <summary>
       /// Get RMA details from the sage by PO Number.
       /// </summary>
       /// <param name="PONumber">
       /// String PO Number.
       /// </param>
       /// <returns>
       /// list of RMAInfo class related to entered PONumber.
       /// </returns>
       public List<RMAInfo> GetRMAInfoByPONumber(String PONumber)
       {
           List<RMAInfo> lsRMAInfo = new List<RMAInfo>();
           try
           {
               var RMAdetailsInfo = Service.entGet.RMAInfoByPONumber(PONumber).ToList();
               if (RMAdetailsInfo.Count() > 0)
               {
                   foreach (var RMAitem in RMAdetailsInfo)
                   {
                       lsRMAInfo.Add(new RMAInfo(RMAitem));
                   }
               }
           }
           catch (Exception ex)
           {
               ex.LogThis("cmdSageOperations/GetRMAInfoByPONumber");
           }
           return lsRMAInfo;
       }

       /// <summary>
       /// Get RMA details from the sage by SO Number customer Order number.
       /// </summary>
       /// <param name="SONumber">
       /// string SOnumber .
       /// </param>
       /// <returns>
       /// List of RMA Information class.
       /// </returns>
       public List<RMAInfo> GetRMAInfoBySONumber(String SONumber)
       {
           List<RMAInfo> lsRMAInfo = new List<RMAInfo>();
           try
           {
               var RMAdetailsInfo = Service.entGet.RMAInfoBySONumber(SONumber).ToList();
               if (RMAdetailsInfo.Count() > 0)
               {
                   foreach (var RMAitem in RMAdetailsInfo)
                   {
                       lsRMAInfo.Add(new RMAInfo(RMAitem));
                   }
               }
           }
           catch (Exception ex)
           {
               ex.LogThis("cmdSageOperations/GetRMAInfoBySONumber");
           }
           return lsRMAInfo;
       }

       /// <summary>
       /// Get RMA details from the sage by Shipmen Number.
       /// </summary>
       /// <param name="ShipmentNumber">
       /// string Shipment Number .
       /// </param>
       /// <returns>
       /// List of RMA Information class.
       /// </returns>
       public List<RMAInfo> GetRMAInfoByShipmentNumber(String ShipmentNumber)
       {
           List<RMAInfo> lsRMAInfo = new List<RMAInfo>();
           try
           {
               var RMAdetailsInfo = Service.entGet.RMAInfoByShippingNumber(ShipmentNumber).ToList();
               if (RMAdetailsInfo.Count() > 0)
               {
                   foreach (var RMAitem in RMAdetailsInfo)
                   {
                       lsRMAInfo.Add(new RMAInfo(RMAitem));
                   }
               }
           }
           catch (Exception ex)
           {
               ex.LogThis("cmdSageOperations/GetRMAInfoByShipmentNumber");
           }
           return lsRMAInfo;
       }


       public List<String> GetNewRMANumber(String Chars)
       {
           List<String> lsRMAInfo = new List<String>();
           try
           {
               var NewRMAdetailsInfo = Service.entGet.ProductMachingNameCat(Chars);
               if (NewRMAdetailsInfo.Count() > 0)
               {
                   foreach (var RMAitem in NewRMAdetailsInfo)
                   {
                       lsRMAInfo.Add(RMAitem);
                   }
               }
           }
           catch (Exception ex)
           {
               ex.LogThis("cmdSageOperations/GetNewRMANumber");
           }
           return lsRMAInfo;
       }

       public string GetEANCode(String ItemCode)
       {
           string EANCode = "";
           try
           {
               EANCode = Service.entGet.GetEANCode(ItemCode);
           }
           catch (Exception)
           {
           }
           return EANCode;
       
       }


    }
}
