<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:include href="Common.xslt"/>
  <xsl:output method="text" indent="yes"/>
  <xsl:template match="/">
    <xsl:apply-templates select="/solution/entities"/>
  </xsl:template>

  <xsl:template match="entities">
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


        <xsl:apply-templates select="entity" mode="property"/>

        #region Inline DAO implementations

        /// <summary>
        /// Concrete DAO for accessing instances of <see cref="Customer" /> from DB.
        /// This should be extracted into its own class-file if it needs to extend the
        /// inherited DAO functionality.
        /// </summary>
        <xsl:apply-templates select="entity" mode="declarations"/>

        #endregion
    }
}
  </xsl:template>

  <xsl:template match="entity" mode="property">
    public I<xsl:value-of select="@name"/>Dao Get<xsl:value-of select="@name"/>Dao() {
      return new <xsl:value-of select="@name"/>Dao();
    }
  </xsl:template>

  <xsl:template match="entity" mode="declarations">    
    public class <xsl:value-of select="@name"/>Dao : AbstractNHibernateDao<xsl:call-template name="lt"></xsl:call-template><xsl:value-of select="@name"/>, long<xsl:call-template name="gt"></xsl:call-template>, I<xsl:value-of select="@name"/>Dao { }
  </xsl:template>
</xsl:stylesheet>
