<?xml version="1.0" encoding="iso-8859-1"?>
<!--<?xml version="1.0" encoding="iso-8859-1"?>-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" exclude-result-prefixes="">
  <xsl:include href="Common.xslt"/>
  <xsl:output method="text"/>
  <xsl:template match="userTypes">
using System;
using System.Collections.Generic;
using EDM.FoundationClasses.FoundationType;

namespace <xsl:value-of select="@nameSpace"/>.Base
{
    public class BaseUserTypeMetadata
    {
    
      protected BaseUserTypeMetadata() { }
      
      <xsl:apply-templates select="*"/>
    }
}
  </xsl:template>
  <!--Template to generate user types-->
  <xsl:template match="*">
        public static IUserType<xsl:call-template name="lt"/><xsl:value-of select="name(.)"/><xsl:call-template name="gt"/>&#160;<xsl:value-of select="@name"/> = new UserType<xsl:call-template name="lt"/><xsl:value-of select="name(.)"/><xsl:call-template name="gt"/>(<xsl:choose><xsl:when test="@length != ''"><xsl:value-of select="@length"/>, </xsl:when><xsl:otherwise>0, </xsl:otherwise></xsl:choose>
        <xsl:choose><xsl:when test="@minLength != ''"><xsl:value-of select="@minLength"/>, </xsl:when><xsl:otherwise>0, </xsl:otherwise></xsl:choose>
        <xsl:choose><xsl:when test="@maxLength != ''"><xsl:value-of select="@maxLength"/>, </xsl:when><xsl:otherwise>0, </xsl:otherwise></xsl:choose>
        <xsl:choose><xsl:when test="@pattern != ''">@"<xsl:value-of select="@pattern"/>", </xsl:when><xsl:otherwise>null, </xsl:otherwise></xsl:choose>
        <xsl:choose><xsl:when test="count(enumeration) != 0">new List<xsl:call-template name="lt"/><xsl:value-of select="name(.)"/><xsl:call-template name="gt"/> {<xsl:apply-templates select="enumeration"/>}, </xsl:when><xsl:otherwise>null, </xsl:otherwise></xsl:choose>
        <xsl:choose><xsl:when test="@minInclusive != ''">new NullableType<xsl:call-template name="lt"></xsl:call-template><xsl:value-of select="name(.)"/><xsl:call-template name="gt"></xsl:call-template>(<xsl:value-of select="@minInclusive"/>), </xsl:when><xsl:otherwise>null, </xsl:otherwise></xsl:choose>
        <xsl:choose><xsl:when test="@minExclusive != ''">new NullableType<xsl:call-template name="lt"></xsl:call-template><xsl:value-of select="name(.)"/><xsl:call-template name="gt"></xsl:call-template>(<xsl:value-of select="@minExclusive"/>), </xsl:when><xsl:otherwise>null, </xsl:otherwise></xsl:choose>
        <xsl:choose><xsl:when test="@maxInclusive != ''">new NullableType<xsl:call-template name="lt"></xsl:call-template><xsl:value-of select="name(.)"/><xsl:call-template name="gt"></xsl:call-template>(<xsl:value-of select="@maxInclusive"/>), </xsl:when><xsl:otherwise>null, </xsl:otherwise></xsl:choose>
        <xsl:choose><xsl:when test="@maxExclusive != ''">new NullableType<xsl:call-template name="lt"></xsl:call-template><xsl:value-of select="name(.)"/><xsl:call-template name="gt"></xsl:call-template>(<xsl:value-of select="@maxExclusive"/>), </xsl:when><xsl:otherwise>null, </xsl:otherwise></xsl:choose>
        <xsl:choose><xsl:when test="@whiteSpace != ''"><xsl:value-of select="@whiteSpace"/>, </xsl:when><xsl:otherwise>0, </xsl:otherwise></xsl:choose>
        <xsl:choose><xsl:when test="@totalDigits != ''"><xsl:value-of select="@totalDigits"/>, </xsl:when><xsl:otherwise>null, </xsl:otherwise></xsl:choose>
    <xsl:choose><xsl:when test="@fractionDigits != ''"><xsl:value-of select="@fractionDigits"/>, </xsl:when><xsl:otherwise>null</xsl:otherwise></xsl:choose>);
  </xsl:template>
  <!--Template to generate enumeration List-->
  <xsl:template match="enumeration"><xsl:if test="name(..) = 'string'">"</xsl:if><xsl:value-of select="text()"/><xsl:if test="name(..) = 'string'">"</xsl:if><xsl:if test="position() != last()">, </xsl:if></xsl:template>
</xsl:stylesheet>
