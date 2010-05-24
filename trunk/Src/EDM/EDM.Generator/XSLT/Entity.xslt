﻿<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:output method="text" indent="yes"/>

  <xsl:template match="entity">
using System;
using EDM.FoundationClasses.Entity;
using EDM.FoundationClasses.FoundationType;
using GenRtti;

namespace GenEntity
{
  //Auto-Generated class
  [Serializable]
  public <xsl:if test="@type = 'abstract'">abstract</xsl:if> class <xsl:value-of select="@name"/> : <xsl:choose><xsl:when test="@type = 'dependent'"><xsl:value-of select="@baseEntity"/></xsl:when><xsl:otherwise>IEntity</xsl:otherwise></xsl:choose>
  {
    //Generated parameterless constructor
    public <xsl:value-of select="@name"/> () {}

    //fields
    <xsl:apply-templates select="fields/field" mode="fields"/>

    public <xsl:choose><xsl:when test="@type = 'dependent'">override</xsl:when><xsl:otherwise>virtual</xsl:otherwise></xsl:choose> bool IsValid()
    {
      return <xsl:if test="@type = 'dependent'">base.IsValid()<xsl:if test="count(fields/field[@unique = 'true']) > 0"><xsl:text disable-output-escaping="yes"><![CDATA[ &&]]></xsl:text></xsl:if></xsl:if> <xsl:apply-templates select="fields/field[@unique = 'true']" mode="IsValid"/>;
    }
    
    <xsl:if test="@type != 'dependent' and count(fields/field[@unique = 'true']) > 0">
    public override int GetHashCode()
    {
      return <xsl:apply-templates select="fields/field[@unique = 'true']" mode="Hash"/>;
    }</xsl:if>
    
    public override bool Equals(<xsl:value-of select="@name"/> obj)
    {
      if(obj == null) return false;
      return <xsl:if test="@type = 'dependent'">base.Equals((<xsl:value-of select="@baseEntity"/>)obj)<xsl:if test="count(fields/field[@unique = 'true']) > 0"><xsl:text disable-output-escaping="yes"><![CDATA[ && ]]></xsl:text></xsl:if></xsl:if><xsl:apply-templates select="fields/field[@unique = 'true']" mode="Equals"/>;
    }
  }//class
}//namespace
  </xsl:template>
  <xsl:template match="fields/field" mode="fields">
    public virtual <xsl:value-of select="@baseType"/> <xsl:value-of select="@name"/> { get; set; }
  </xsl:template>  
  <xsl:template match="fields/field[@unique = 'true']" mode="IsValid"> Validator.IsValid(UserTypeMetadata.<xsl:value-of select="@type"/>, <xsl:value-of select="@name"/>) <xsl:if test="position() != last()"><xsl:text disable-output-escaping="yes"><![CDATA[&&]]></xsl:text></xsl:if></xsl:template>
  <xsl:template match="fields/field[@unique = 'true']" mode="Hash"><xsl:value-of select="@name"/>.GetHashCode()<xsl:if test="position() != last()"> ^ </xsl:if></xsl:template>
  <xsl:template match="fields/field[@unique = 'true']" mode="Equals"><xsl:value-of select="@name"/>.Equals(obj.<xsl:value-of select="@name"/>)<xsl:if test="position() != last()"><xsl:text disable-output-escaping="yes"><![CDATA[ && ]]></xsl:text></xsl:if></xsl:template>
</xsl:stylesheet>
