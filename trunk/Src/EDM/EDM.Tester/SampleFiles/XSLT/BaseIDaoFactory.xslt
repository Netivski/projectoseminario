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
using <xsl:value-of select="@nameSpace"/>;

namespace <xsl:value-of select="@nameSpace"/>.DataInterfaces.Base
{
    /// <summary>
    /// Provides an interface for retrieving DAO objects
    ///</summary>

    public interface IDaoFactoryBase
    {
      <xsl:apply-templates select="entity" mode="interface"/>
    }
}
  </xsl:template>

  <xsl:template match="entity" mode="interface">
    I<xsl:value-of select="@name"/>Dao Get<xsl:value-of select="@name"/>Dao();
  </xsl:template>

</xsl:stylesheet>
