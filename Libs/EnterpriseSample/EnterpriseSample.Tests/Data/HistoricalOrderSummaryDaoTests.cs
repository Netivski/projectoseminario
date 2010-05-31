using System.Collections.Generic;
using EnterpriseSample.Core.DataInterfaces;
using EnterpriseSample.Core.Domain;
using EnterpriseSample.Data;
using NUnit.Framework;

namespace EnterpriseSample.Tests.Data
{
    [TestFixture]
    [Category("Database Tests")]
    public class HistoricalOrderSummaryDaoTests
    {
        [Test]
        public void CanGetCustomerOrderHistory() {
            IDaoFactory daoFactory = new NHibernateDaoFactory(TestGlobals.SessionFactoryConfigPath);
            IHistoricalOrderSummaryDao historicalOrderSummaryDao = daoFactory.GetHistoricalOrderSummaryDao();

            List<HistoricalOrderSummary> foundSummaries = historicalOrderSummaryDao.GetCustomerOrderHistoryFor(TestGlobals.TestCustomer.ID);

            Assert.AreEqual(11, foundSummaries.Count);
        }
    }
}
