
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
    public class CategoryBaseWs : System.Web.Services.WebService
    {
        
        [WebMethod]
        public long Create(string Name, string Description, string SmallImagePath, string LargeImagePath, DateTime EffectiveStartDate, DateTime EffectiveEndDate)
        {        
            return Singleton<CategoryService>.Current.Create(Name, Description, SmallImagePath, LargeImagePath, EffectiveStartDate, EffectiveEndDate);
        }

        [WebMethod]
        public void Update(long recordId, string Name, string Description, string SmallImagePath, string LargeImagePath, DateTime EffectiveStartDate, DateTime EffectiveEndDate)
        {
            Singleton<CategoryService>.Current.Update(recordId, Name, Description, SmallImagePath, LargeImagePath, EffectiveStartDate, EffectiveEndDate);
        }

        [WebMethod]
        public void Delete(long recordId)
        {
            Singleton<CategoryService>.Current.Delete(recordId);
        }
        
    }
}
  