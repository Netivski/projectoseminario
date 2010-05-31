using NUnit.Framework;
using ProjectBase.Data;

namespace EnterpriseSample.Tests.Data
{
    public class NHibernateTestCase
    {
        /// <summary>
        /// Initializes the NHibernate session bound to CallContext (since this isn't in an HTTP context).
        /// </summary>
        [TestFixtureSetUp]
        public void Setup() {
            NHibernateSessionManager.Instance.BeginTransactionOn(TestGlobals.SessionFactoryConfigPath);
        }

        /// <summary>
        /// Properly disposes of the <see cref="NHibernateSessionManager"/>.
        /// This always rolls back the transaction; therefore, changes never get committed.
        /// </summary>
        [TestFixtureTearDown]
        public void Dispose() {
            NHibernateSessionManager.Instance.RollbackTransactionOn(TestGlobals.SessionFactoryConfigPath);
        }
    }
}
