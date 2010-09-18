<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:include href="Common.xslt"/>
  <xsl:output method="text" indent="yes"/>
  <xsl:template match="component">
using System;        
using EDM.FoundationClasses.Patterns;

namespace <xsl:value-of select="@servicesNameSpace"/>.Base
{
    public class <xsl:value-of select="@name"/>BaseImplementationService : <xsl:value-of select="@name"/>BaseService
    {        
      <xsl:apply-templates select="businessProcess"/>           
    }
}
  </xsl:template>
  
  <xsl:template match="businessProcess">    
        #region - <xsl:value-of select="@name"/>        
        protected override <xsl:choose><xsl:when test="count(output/@edmType) = 1"><xsl:value-of select="output/@edmType"/></xsl:when><xsl:otherwise>void</xsl:otherwise></xsl:choose>&#160;<xsl:value-of select="@name"/>Logic(<xsl:apply-templates select="input/param" mode="params"/>)
        {
          throw new NotImplementedException( string.Format("Method {0} not Implemented", "<xsl:value-of select="@name"/>Logic" ));
        }
        #endregion
</xsl:template>

  <xsl:template match="param" mode="params">
     <xsl:value-of select="@edmType"/>&#160;<xsl:value-of select="@name"/><xsl:if test="position() != last()">, </xsl:if>
  </xsl:template>

  <xsl:template match="param" mode="call">
    <xsl:value-of select="@name"/><xsl:if test="position() != last()">, </xsl:if>
  </xsl:template>  
  
</xsl:stylesheet>
