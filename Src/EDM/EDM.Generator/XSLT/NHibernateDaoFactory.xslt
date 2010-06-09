<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:output method="text" indent="yes"/>
  <xsl:template match="entities">

<![CDATA[
    //Nota :: 
    //Por cada uma das ./entity criar o interface e declaração inline


using BasicSample.Core.DataInterfaces;
using BasicSample.Core.Domain;

namespace BasicSample.Data
{
    /// <summary>
    /// Exposes access to NHibernate DAO classes.  Motivation for this DAO
    /// framework can be found at http://www.hibernate.org/328.html.
    /// </summary>
    public class NHibernateDaoFactory : IDaoFactory
    {

        static readonly NHibernateDaoFactory current = null;
       
        NHibernateDaoFactory() { }


        static NHibernateDaoFactory() 
        {
            current = new NHibernateDaoFactory();
        }

        public static NHibernateDaoFactory Current
        {
            get { return current; }
        }



        public ICustomerDao GetCustomerDao() {
            return new CustomerDao();
        }

        public IHistoricalOrderSummaryDao GetHistoricalOrderSummaryDao() {
            return new HistoricalOrderSummaryDao();
        }

        public IOrderDao GetOrderDao() {
            return new OrderDao();
        }

        public ISupplierDao GetSupplierDao() {
            return new SupplierDao();
        }

        #region Inline DAO implementations

        /// <summary>
        /// Concrete DAO for accessing instances of <see cref="Customer" /> from DB.
        /// This should be extracted into its own class-file if it needs to extend the
        /// inherited DAO functionality.
        /// </summary>
        public class CustomerDao : AbstractNHibernateDao<Customer, string>, ICustomerDao { }

        public class SupplierDao : AbstractNHibernateDao<Supplier, long>, ISupplierDao { }

        #endregion
    }
}



]]>
  
  </xsl:template>
</xsl:stylesheet>
