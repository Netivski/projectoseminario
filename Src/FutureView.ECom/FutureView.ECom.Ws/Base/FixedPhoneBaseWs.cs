﻿
using System;    
using System.Web.Services;
using EDM.FoundationClasses.Patterns;
using FutureView.ECom.Entity;
using FutureView.ECom.Services;

namespace FutureView.ECom.Ws.Base
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class FixedPhoneBaseWs : System.Web.Services.WebService
    {
        
        [WebMethod]
        public long Create(string Prefix, string Number)
        {        
            return Singleton<FixedPhoneService>.Current.Create(Prefix, Number);
        }

        [WebMethod]
        public void Update(long recordId, string Prefix, string Number)
        {
            Singleton<FixedPhoneService>.Current.Update(recordId, Prefix, Number);
        }

        [WebMethod]
        public void Delete(long recordId)
        {
            Singleton<FixedPhoneService>.Current.Delete(recordId);
        }
        
    }
}
  