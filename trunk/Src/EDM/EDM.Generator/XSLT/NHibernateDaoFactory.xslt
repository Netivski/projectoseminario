<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:include href="Common.xslt"/>
  <xsl:output method="text" indent="yes"/>
  <xsl:template match="/">
    <xsl:apply-templates select="/solution/entities"/>
  </xsl:template>

  <xsl:template match="entities">
using EDM.FoundationClasses.Persistence.Core;
using EDM.FoundationClasses.Persistence.Data;
using <xsl:value-of select="@nameSpace"/>.Data.Base;
using <xsl:value-of select="@nameSpace"/>.DataInterfaces;
using <xsl:value-of select="@nameSpace"/>.DataInterfaces.Base;



namespace <xsl:value-of select="@nameSpace"/>.Data
{
    /// <summary>
    /// Exposes access to NHibernate DAO classes.  Motivation for this DAO
    /// framework can be found at http://www.hibernate.org/328.html.
    /// </summary>
    public class NHibernateDaoFactory : NHibernateDaoFactoryBase
    {
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
