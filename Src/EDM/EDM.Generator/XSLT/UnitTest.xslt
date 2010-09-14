<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:include href="Common.xslt"/>
  <xsl:output method="text" indent="yes"/>
  <xsl:template match="entity">
using System;
using EDM.FoundationClasses.Entity;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using <xsl:value-of select="@baseNameSpace"/>;
using <xsl:value-of select="@servicesNameSpace"/>;

namespace <xsl:value-of select="@unitTestNameSpace"/>
{
  [TestClass]
  public class <xsl:value-of select="@name"/>Test
  {
    private static <xsl:value-of select="@name"/>Service service = new <xsl:value-of select="@name"/>Service();
    private static long id = 0;
    
    [TestMethod]
    public void CanCreate<xsl:value-of select="@name"/>()
    {
      id = service.Create(<xsl:call-template name="resolveRecursiveParams"/>);
      Assert.IsTrue(id != 0, "Unable to create a <xsl:value-of select="@name"/>");
    }
    
    [TestMethod]
    public void CanUpdate<xsl:value-of select="@name"/>()
    {      
      service.Update(id<xsl:call-template name="resolveRecursiveParamsUpdate"/>);
      <xsl:value-of select="@name"/> target = service.Read(id);
      <xsl:call-template name="resolveRecursiveParamsVerifyUpdate"/>
    }
    
    [TestMethod]
    public void CanRead<xsl:value-of select="@name"/>()
    {
      <xsl:value-of select="@name"/> target = service.Read(id);
      Assert.IsNotNull(target, "Unable to read <xsl:value-of select="@name"/>.");
    }
    
    [TestMethod]
    public void CanReadByUnique<xsl:value-of select="@name"/>()
    {
      <xsl:value-of select="@name"/> target = service.ReadByUnique();
      Assert.IsNotNull(target, "Unable to ReadByUnique a <xsl:value-of select="@name"/>");
    }
    
    [TestMethod]
    public void CanDelete<xsl:value-of select="@name"/>()
    {
      service.Delete(id);
      Assert.IsNull(service.Read(id), "Unable to delete <xsl:value-of select="@name"/>");
    }
  }
}
  </xsl:template>

  <xsl:template name="resolveRecursiveParams">
    <xsl:apply-templates select="fields/field" mode="params"></xsl:apply-templates><xsl:if test="@type = 'dependent'"><xsl:if test="count(fields/field) > 0">, </xsl:if>
      <xsl:variable name="varBaseEntity" select="@baseEntity"></xsl:variable>
      <xsl:for-each select="//entity[@name=$varBaseEntity]"><xsl:call-template name="resolveRecursiveParams"></xsl:call-template></xsl:for-each>
    </xsl:if>
  </xsl:template>

  <xsl:template name="resolveRecursiveParamsUpdate">
    <xsl:if test="count(fields/field) > 0">, </xsl:if>
    <xsl:apply-templates select="fields/field" mode="update"></xsl:apply-templates><xsl:if test="@type = 'dependent'">
      <xsl:variable name="varBaseEntity" select="@baseEntity"></xsl:variable>
      <xsl:for-each select="//entity[@name=$varBaseEntity]"><xsl:call-template name="resolveRecursiveParamsUpdate"></xsl:call-template></xsl:for-each>
    </xsl:if>
  </xsl:template>

  <xsl:template name="resolveRecursiveParamsVerifyUpdate">    
    <xsl:apply-templates select="fields/field" mode="verifyUpdate"></xsl:apply-templates>
    <xsl:if test="@type = 'dependent'">      
      <xsl:variable name="varBaseEntity" select="@baseEntity"></xsl:variable>
      <xsl:for-each select="//entity[@name=$varBaseEntity]"><xsl:call-template name="resolveRecursiveParamsVerifyUpdate"></xsl:call-template></xsl:for-each>
    </xsl:if>
  </xsl:template>

  <xsl:template match="fields/field" mode="params"><xsl:choose><xsl:when test="@edmType='string'"><xsl:variable name="Type" select="@type"/><xsl:choose><xsl:when test="count(//solution/userTypes/*[@name=$Type]/enumeration) > 0">"<xsl:value-of select="//solution/userTypes/*[@name=$Type]/enumeration[1]"/>"</xsl:when><xsl:otherwise>"<xsl:value-of select="@name"/>"</xsl:otherwise></xsl:choose></xsl:when><xsl:when test="@edmType = 'DateTime'">new DateTime(2010, 1, 1)</xsl:when><xsl:when test="@edmType = bool">true</xsl:when><xsl:otherwise>1</xsl:otherwise></xsl:choose><xsl:if test="position() != last()">, </xsl:if></xsl:template>

  <xsl:template match="fields/field" mode="update"><xsl:choose><xsl:when test="@edmType='string'"><xsl:variable name="Type" select="@type"/><xsl:choose><xsl:when test="count(//solution/userTypes/*[@name=$Type]/enumeration) > 0">"<xsl:value-of select="//solution/userTypes/*[@name=$Type]/enumeration[2]"/>"</xsl:when><xsl:otherwise>"<xsl:value-of select="@name"/>_2"</xsl:otherwise></xsl:choose></xsl:when><xsl:when test="@edmType = 'DateTime'">new DateTime(2010, 2, 2)</xsl:when><xsl:when test="@edmType = bool">false</xsl:when><xsl:otherwise>2</xsl:otherwise></xsl:choose><xsl:if test="position() != last()">, </xsl:if></xsl:template>

  <xsl:template match="fields/field" mode="verifyUpdate">Assert.AreEqual(target.<xsl:value-of select="@name"/>, <xsl:choose><xsl:when test="@edmType='string'"><xsl:variable name="Type" select="@type"/><xsl:choose><xsl:when test="count(//solution/userTypes/*[@name=$Type]/enumeration) > 0">"<xsl:value-of select="//solution/userTypes/*[@name=$Type]/enumeration[2]"/>"</xsl:when><xsl:otherwise>"<xsl:value-of select="@name"/>_2"</xsl:otherwise></xsl:choose></xsl:when><xsl:when test="@edmType = 'DateTime'">new DateTime(2010, 2, 2)</xsl:when><xsl:when test="@edmType = bool">false</xsl:when><xsl:otherwise>2</xsl:otherwise></xsl:choose>);
</xsl:template>
</xsl:stylesheet>
