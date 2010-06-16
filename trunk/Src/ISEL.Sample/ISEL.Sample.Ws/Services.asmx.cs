using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ISEL.Sample.Entity;
using ISEL.Sample.Entity.DataInterfaces;
using ISEL.Sample.Entity.DataInterfaces.Base;
using ISEL.Sample.Entity.Data;
using ISEL.Sample.Entity.Data.Base;

namespace ISEL.Sample.Ws
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Services : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public List<string> GetAllSample()
        {
            IDaoFactory daoFactory = new NHibernateDaoFactory();
            ISampleDao sampleDao = daoFactory.GetSampleDao();

            List<Entity.Sample> samples = sampleDao.GetAll();
            List<string> rObj = new List<string>();
            foreach (Entity.Sample sample in samples) rObj.Add(sample.Name);

            return rObj;
        }
    }
}
