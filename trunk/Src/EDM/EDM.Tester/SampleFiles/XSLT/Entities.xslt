<?xml version="1.0" encoding="utf-8"?>
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
    
  }//class
}//namespace
  </xsl:template>
  <xsl:template match="fieds/field" mode="fields">
    public virtual <xsl:value-of select="@type"/> <xsl:value-of select="@name"/> { get; set; }
  </xsl:template>
  <xsl:template match="schema/element" mode="props">
    <xsl:choose xml:space="preserve"><xsl:when test="@visibility = 'public'">
    public <xsl:value-of select="@type"/> <xsl:value-of select="@name"/>{ get; set; }
      </xsl:when></xsl:choose>
  </xsl:template>
</xsl:stylesheet>
