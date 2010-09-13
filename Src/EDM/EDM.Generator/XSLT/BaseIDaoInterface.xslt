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
    // There's no need to declare each of the DAO interfaces in its own file, so just add them inline here.
    // But you're certainly welcome to put each declaration into its own file.
    #region Inline interface declarations 
      <xsl:apply-templates select="entity" mode="base"/>
    #endregion 
}
  </xsl:template>

  <xsl:template match="entity" mode="base">
    public interface I<xsl:value-of select="@name"/>DaoBase : IDao<xsl:call-template name="lt"></xsl:call-template><xsl:value-of select="@name"/>, long<xsl:call-template name="gt"></xsl:call-template>{ }
  </xsl:template>
  
</xsl:stylesheet>
