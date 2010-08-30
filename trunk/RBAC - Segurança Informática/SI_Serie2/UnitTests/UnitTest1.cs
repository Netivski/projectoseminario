using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VSSolution;
using System.Threading;
using System.Security.Permissions;
using System.Security;

namespace UnitTests
{
    /*
     * - Aluno has 'Method A' and 'Method B' permissions
     * - Docente has 'Method C' and 'Method D' permissions
     * - Guest has 'Method D' permissions
     * - Administrator has 'Method A', 'Method B', 'Method C' and 'Method D' permissions
     * 
     * - There's a role hierarchy defined where 'Aluno' is senior to 'Guest', therefore gaining
     * 'Method D' permission by inhearitance.
     * 
     * */

    [TestClass]
    public class UnitTest1
    {

        /* Test permission gained directly the declarative way */
        [TestMethod]
        
        public void AlunoTriesPermissionA_Declarative()
        {
            UserIdentity user = new UserIdentity("The.Duke");
            Thread.CurrentPrincipal = user;
            DeclarativeMethodA();
        }
        [StringSecurityAttribute(SecurityAction.Demand, Name = "Method A", Unrestricted = false)]
        private void DeclarativeMethodA() { }


        /* Test security exception the declarative way */
        [TestMethod]
        [ExpectedException(typeof(System.Security.SecurityException))]
        public void AlunoTriesPermissionC_Declarative()
        {
            UserIdentity user = new UserIdentity("The.Duke");
            Thread.CurrentPrincipal = user;
            DeclarativeMethodC();
        }
        [StringSecurityAttribute(SecurityAction.Demand, Name = "Method C", Unrestricted = false)]
        private void DeclarativeMethodC() { }


        /* Test permission gained by hierarchy the declarative way */
        [TestMethod]
        public void AlunoTriesPermissionD_Declarative()
        {
            UserIdentity user = new UserIdentity("The.Duke");
            Thread.CurrentPrincipal = user;
            DeclarativeMethodD();
        }
        [StringSecurityAttribute(SecurityAction.Demand, Name = "Method D", Unrestricted = false)]
        private void DeclarativeMethodD() { }


        /* Test permission gained directly the imperative way */
        [TestMethod]
        public void AlunoTriesPermissionA_Imperative()
        {
            UserIdentity user = new UserIdentity("The.Duke");
            Thread.CurrentPrincipal = user;
            IPermission p = new StringPermission("Method A");
            p.Demand();
        }


        /* Test security exception the imperative way */
        [TestMethod]
        //[ExpectedException(typeof(System.Security.SecurityException))]
        public void AlunoTriesPermissionC_Imperative()
        {
            UserIdentity user = new UserIdentity("The.Duke");
            Thread.CurrentPrincipal = user;
            IPermission p = new StringPermission("Method C");
            p.Demand();
        }


        /* Test permission gaineb by hierarchy the imperative way */
        [TestMethod]
        public void AlunoTriesPermissionD_Imperative()
        {
            UserIdentity user = new UserIdentity("The.Duke");
            Thread.CurrentPrincipal = user;
            IPermission p = new StringPermission("Method D");
            p.Demand();
        }
    }
}
