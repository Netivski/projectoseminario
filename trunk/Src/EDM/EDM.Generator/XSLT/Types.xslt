<?xml version="1.0" encoding="iso-8859-1"?>

<!--<?xml version="1.0" encoding="iso-8859-1"?>-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" exclude-result-prefixes="">

  <xsl:output method="text"/>

  <xsl:template match="userTypes">
using System;
using EDM.FoundationClasses.FoundationType;

namespace GenRtti
{
  public static class UserTypeMetadata
  {
    <xsl:apply-templates select="*"/>
  }
}
  </xsl:template>
  
  <!--Template to generate user types-->
  <xsl:template match="*">
    public static IUserType<xsl:text disable-output-escaping="yes"><![CDATA[<]]></xsl:text><xsl:value-of select="name(.)"/><xsl:text disable-output-escaping="yes">></xsl:text>&#160;<xsl:value-of select="@name"/> = new UserType<xsl:text disable-output-escaping="yes"><![CDATA[<]]></xsl:text><xsl:value-of select="name(.)"/><xsl:text disable-output-escaping="yes">></xsl:text>(<xsl:choose><xsl:when test="@length != ''"><xsl:value-of select="@length"/>, </xsl:when><xsl:otherwise>0, </xsl:otherwise></xsl:choose>
    <xsl:choose><xsl:when test="@minLength != ''"><xsl:value-of select="@minLength"/>, </xsl:when><xsl:otherwise>0, </xsl:otherwise></xsl:choose>
    <xsl:choose><xsl:when test="@maxLength != ''"><xsl:value-of select="@maxLength"/>, </xsl:when><xsl:otherwise>0, </xsl:otherwise></xsl:choose>
    <xsl:choose><xsl:when test="@pattern != ''">"<xsl:value-of select="@pattern"/>", </xsl:when><xsl:otherwise>null, </xsl:otherwise></xsl:choose>
    <xsl:choose><xsl:when test="count(enumeration) != 0">new List<xsl:text disable-output-escaping="yes"><![CDATA[<]]></xsl:text>string<xsl:text disable-output-escaping="yes">></xsl:text> {<xsl:apply-templates select="enumeration"/>}, </xsl:when><xsl:otherwise>null, </xsl:otherwise></xsl:choose>
    <xsl:choose><xsl:when test="@minInclusive != ''"><xsl:value-of select="@minInclusive"/>, </xsl:when><xsl:otherwise>null, </xsl:otherwise></xsl:choose>
    <xsl:choose><xsl:when test="@minExclusive != ''"><xsl:value-of select="@minExclusive"/>, </xsl:when><xsl:otherwise>null, </xsl:otherwise></xsl:choose>
    <xsl:choose><xsl:when test="@maxInclusive != ''"><xsl:value-of select="@maxInclusive"/>, </xsl:when><xsl:otherwise>null, </xsl:otherwise></xsl:choose>
    <xsl:choose><xsl:when test="@maxExclusive != ''"><xsl:value-of select="@maxExclusive"/>, </xsl:when><xsl:otherwise>null, </xsl:otherwise></xsl:choose>
    <xsl:choose><xsl:when test="@whiteSpace != ''"><xsl:value-of select="@whiteSpace"/>, </xsl:when><xsl:otherwise>0, </xsl:otherwise></xsl:choose>
    <xsl:choose><xsl:when test="@totalDigits != ''"><xsl:value-of select="@totalDigits"/>, </xsl:when><xsl:otherwise>null, </xsl:otherwise></xsl:choose>
    <xsl:choose><xsl:when test="@fractionDigits != ''"><xsl:value-of select="@fractionDigits"/>, </xsl:when><xsl:otherwise>null</xsl:otherwise></xsl:choose>);
  </xsl:template>
  
  <!--Template to generate enumeration List-->
  <xsl:template match="enumeration">"<xsl:value-of select="text()"/>"<xsl:if test="position() != last()">, </xsl:if></xsl:template>
</xsl:stylesheet>
