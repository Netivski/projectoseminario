using BasicSample.Data;
using NUnit.Framework;

namespace BasicSample.Tests.Data
{
    public class NHibernateTestCase
    {
        /// <summary>
        /// Initializes the NHibernate session bound to CallContext (since this isn't in an HTTP context).
        /// </summary>
        [TestFixtureSetUp]
        public void Setup() {
            NHibernateSessionManager.Instance.BeginTransaction();
        }

        /// <summary>
        /// Properly disposes of the <see cref="NHibernateSessionManager"/>.
        /// This always rolls back the transaction; therefore, changes never get committed.
        /// </summary>
        [TestFixtureTearDown]
        public void Dispose() {
            NHibernateSessionManager.Instance.RollbackTransaction();
        }
    }
}
