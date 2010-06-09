<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:output method="text" indent="yes"/>
  <xsl:template match="entities">

<![CDATA[
    //Nota :: 
    //Por cada uma das ./entity criar o interface e declaração inline

    using BasicSample.Core.Domain;

    namespace BasicSample.Core.DataInterfaces
    {
    /// <summary>
      /// Provides an interface for retrieving DAO objects
      ///
      ///</summary>
    public interface IDaoFactory
    {
      ICustomerDao GetCustomerDao();
      ISupplierDao GetSupplierDao();
    }

    // There's no need to declare each of the DAO interfaces in its own file, so just add them inline here.
    // But you're certainly welcome to put each declaration into its own file.
    #region Inline interface declarations

      public interface ICustomerDao : IDao<Customer, string="">{ }
      public interface ISupplierDao : IDao<Supplier, long="">{ }

    #endregion
    }

]]>
  
  </xsl:template>
</xsl:stylesheet>
