<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
    
  <xsl:output method="text" indent="yes"/>

  <!--<xsl:template match="Entities">
    <xsl:apply-templates select="Entitie"/>
  </xsl:template>-->

  <xsl:template match="entity">
using System;
using EDM.FoundationClasses.FoundationEntity; //a ver

namespace GeneratedEntity //a ver
{
  //Auto-Generated class
  public <xsl:choose><xsl:when test="@type = 'abstract'">abstract </xsl:when></xsl:choose>class <xsl:value-of select="@name"/> <xsl:choose><xsl:when test="@type = 'dependent'"> : <xsl:value-of select="@baseEntity"/></xsl:when></xsl:choose>
  {
    //fields
    <xsl:apply-templates select="schema/element" mode="fields"/>
    <xsl:choose>
      <xsl:when test="@type = 'abstract'"></xsl:when>
      <xsl:otherwise>
    //Generated parameterless constructor
    public <xsl:value-of select="@name"/> () <xsl:choose>
                                               <xsl:when test="@type = 'dependent'"> : base()</xsl:when>
                                             </xsl:choose> {}
      </xsl:otherwise>
    </xsl:choose>    
    //Properties
    <xsl:apply-templates select="schema/element" mode="props"/>
  }//class
}//namespace
  </xsl:template>
  <xsl:template match="schema/element" mode="fields" xml:space="preserve">
    <xsl:value-of select="@visibility"/> <xsl:value-of select="@type"/> <xsl:value-of select="@name"/>;
  </xsl:template>
  <xsl:template match="schema/element" mode="props">
    <xsl:choose xml:space="preserve"><xsl:when test="@visibility = 'public'">
    public <xsl:value-of select="@type"/> <xsl:value-of select="@name"/>{ get; set; }
      </xsl:when></xsl:choose>
  </xsl:template>
</xsl:stylesheet>
