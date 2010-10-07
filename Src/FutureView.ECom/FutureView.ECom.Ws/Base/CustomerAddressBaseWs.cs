
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
    public class CustomerAddressBaseWs : System.Web.Services.WebService
    {
        
        [WebMethod]
        public long Create(string Country, string Line1, string Line2, string PostalCode, string PostalCodeDesc)
        {        
            return Singleton<CustomerAddressService>.Current.Create(Country, Line1, Line2, PostalCode, PostalCodeDesc);
        }

        [WebMethod]
        public void Update(long recordId, string Country, string Line1, string Line2, string PostalCode, string PostalCodeDesc)
        {
            Singleton<CustomerAddressService>.Current.Update(recordId, Country, Line1, Line2, PostalCode, PostalCodeDesc);
        }

        [WebMethod]
        public void Delete(long recordId)
        {
            Singleton<CustomerAddressService>.Current.Delete(recordId);
        }
        
    }
}
  