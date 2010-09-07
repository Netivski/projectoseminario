<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:include href="Common.xslt"/>
  <xsl:output method="text" indent="yes"/>
  <xsl:template match="entity">
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
        [WebMethod]
        public long Create(<xsl:call-template name="resolveRecursiveParams"></xsl:call-template>)
        {        
            return Singleton<xsl:call-template name="lt"/><xsl:value-of select="@name"/>Service<xsl:call-template name="gt"/>.Current.Create(<xsl:call-template name="resolveRecursiveCallParams"></xsl:call-template>);
        }

        [WebMethod]
        public bool Update(long recordId, <xsl:call-template name="resolveRecursiveParams"></xsl:call-template>)
        {
            return Singleton<xsl:call-template name="lt"/><xsl:value-of select="@name"/>Service<xsl:call-template name="gt"/>.Current.Update(recordId, <xsl:call-template name="resolveRecursiveCallParams"></xsl:call-template>);
        }

        [WebMethod]
        public <xsl:value-of select="@name"/> Read(long recordId)
        {
            return Singleton<xsl:call-template name="lt"/><xsl:value-of select="@name"/>Service<xsl:call-template name="gt"/>.Current.Read(recordId);
        }

        [WebMethod]
        public <xsl:value-of select="@name"/> ReadByUnique()
        {
            return Singleton<xsl:call-template name="lt"/><xsl:value-of select="@name"/>Service<xsl:call-template name="gt"/>.Current.ReadByUnique();
        }

        [WebMethod]
        public bool Delete(long recordId)
        {
            return Singleton<xsl:call-template name="lt"/><xsl:value-of select="@name"/>Service<xsl:call-template name="gt"/>.Current.Delete(recordId);
        }
    }
}
  </xsl:template>

  <xsl:template match="fields/field" mode="params">
    <xsl:value-of select="@edmType"/>&#160;<xsl:value-of select="@name"/><xsl:if test="position() != last()">, </xsl:if>
  </xsl:template>

  <xsl:template match="fields/field" mode="callParams">
    <xsl:value-of select="@name"/><xsl:if test="position() != last()">, </xsl:if>
  </xsl:template>

  <xsl:template name="resolveRecursiveParams">
    <xsl:apply-templates select="fields/field" mode="params"/>
    <xsl:if test="@type = 'dependent'">
      <xsl:if test="count(fields/field) > 0">, </xsl:if>
      <xsl:variable name="varBaseEntity" select="@baseEntity"></xsl:variable>
      <xsl:for-each select="//entity[@name=$varBaseEntity]">
        <xsl:call-template name="resolveRecursiveParams"></xsl:call-template>
      </xsl:for-each>
    </xsl:if>
  </xsl:template>

  <xsl:template name="resolveRecursiveCallParams">
    <xsl:apply-templates select="fields/field" mode="callParams"/>
    <xsl:if test="@type = 'dependent'">
      <xsl:if test="count(fields/field) > 0">, </xsl:if>
      <xsl:variable name="varBaseEntity" select="@baseEntity"></xsl:variable>
      <xsl:for-each select="//entity[@name=$varBaseEntity]">
        <xsl:call-template name="resolveRecursiveCallParams"></xsl:call-template>
      </xsl:for-each>
    </xsl:if>
  </xsl:template>
</xsl:stylesheet>
