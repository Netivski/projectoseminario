<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:include href="Common.xslt"/>
  <xsl:output method="text" indent="yes"/>
  <xsl:template match="component">
using System;    
using System.Web.Services;
using EDM.FoundationClasses.Patterns;
using <xsl:value-of select="@baseNameSpace"/>;
using <xsl:value-of select="@servicesNameSpace"/>;

namespace <xsl:value-of select="@wsNameSpace"/>.Base
{
    [WebService(Namespace = "<xsl:value-of select="@wsHeaderNameSpace"/>")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class <xsl:value-of select="@name"/>BaseWs : System.Web.Services.WebService
    {
        <xsl:apply-templates select="businessProcess"/>                                 
    }
}
  </xsl:template>

  <xsl:template match="businessProcess">    
        [WebMethod]
        public <xsl:value-of select="output/@edmType"/>&#160;<xsl:value-of select="@name"/>(<xsl:apply-templates select="input/param" mode="params"/>)
        {                              
          return Singleton<xsl:call-template name="lt"/><xsl:value-of select="../@name"/>Service<xsl:call-template name="gt"/>.Current.<xsl:value-of select="@name"/>(<xsl:apply-templates select="input/param" mode="call"/>);
        }        
</xsl:template>

  <xsl:template match="param" mode="params">
     <xsl:value-of select="@edmType"/>&#160;<xsl:value-of select="@name"/><xsl:if test="position() != last()">, </xsl:if>
  </xsl:template>

  <xsl:template match="param" mode="call">
    <xsl:value-of select="@name"/><xsl:if test="position() != last()">, </xsl:if>
  </xsl:template>
  
  
</xsl:stylesheet>
