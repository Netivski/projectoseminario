<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="xml"/>

  <xsl:attribute-set name="solution">
    <xsl:attribute name="generatedFileName">
      <xsl:value-of select="@generatedFileName"/>
    </xsl:attribute>
  </xsl:attribute-set>
  <xsl:attribute-set name="entity">
    <xsl:attribute name="type">
      <xsl:value-of select="@type"/>
    </xsl:attribute>
    <xsl:attribute name="name">
      <xsl:value-of select="@name"/>
    </xsl:attribute>
    <xsl:attribute name="generatedFileName">
      <xsl:value-of select="@generatedFileName"/>
    </xsl:attribute>
  </xsl:attribute-set>
  
  <xsl:attribute-set name="field">
    <xsl:attribute name="name">
      <xsl:value-of select="@name"/>
    </xsl:attribute>
    <xsl:attribute name="type">
      <xsl:value-of select="@type"/>
    </xsl:attribute>
    <xsl:attribute name="unique">
      <xsl:value-of select="@unique"/>
    </xsl:attribute>
    <xsl:attribute name="visible">
      <xsl:value-of select="@visible"/>
    </xsl:attribute>
    <xsl:attribute name="nillable">
      <xsl:value-of select="@nillable"/>
    </xsl:attribute>
    <xsl:attribute name="sequence">
      <xsl:value-of select="@sequence"/>
    </xsl:attribute>
    <xsl:attribute name="searchable">
      <xsl:value-of select="searchable"/>
    </xsl:attribute>
    <xsl:attribute name="EDMType">
      <xsl:variable name="type" select="@type"/>
      <xsl:value-of select="name(../../../../userTypes/*[@name = $type])"/>
    </xsl:attribute>
  </xsl:attribute-set>
  
  <xsl:template match="*">
    <xsl:copy use-attribute-sets="solution">
      <xsl:apply-templates/>
    </xsl:copy>
  </xsl:template>
  <xsl:template match="userTypes">
    <xsl:copy>
      <xsl:copy-of select="*"/>
    </xsl:copy>
  </xsl:template>
  <xsl:template match="entities">
    <xsl:copy use-attribute-sets="" >
      <xsl:apply-templates/>
    </xsl:copy>
  </xsl:template>
  <xsl:template match="entity">
    <xsl:copy use-attribute-sets="entity">
      <xsl:apply-templates/>
    </xsl:copy>
  </xsl:template>
  <xsl:template match="fields">
    <xsl:copy>
      <xsl:apply-templates/>
    </xsl:copy>
  </xsl:template>
  <xsl:template match="field">
    <xsl:copy use-attribute-sets="field"/>
  </xsl:template> 
</xsl:stylesheet>