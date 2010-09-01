<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:template name="gt">
    <xsl:text disable-output-escaping="yes"><![CDATA[>]]></xsl:text>
  </xsl:template>
  <xsl:template name="lt">
    <xsl:text disable-output-escaping="yes"><![CDATA[<]]></xsl:text>
  </xsl:template>



  <xsl:template name="and">
    <xsl:text disable-output-escaping="yes"><![CDATA[&& ]]></xsl:text>
  </xsl:template>
  <xsl:template name="NewLine">
    <xsl:text>&#x0A;</xsl:text>
  </xsl:template>
  <xsl:template name="Tab1">
    <xsl:text>&#x09;</xsl:text>
  </xsl:template>
  <xsl:template name="Tab2">
    <xsl:text>&#x09;</xsl:text>
    <xsl:text>&#x09;</xsl:text>
  </xsl:template>
  <xsl:template name="Tab3">
    <xsl:text>&#x09;</xsl:text>
    <xsl:text>&#x09;</xsl:text>
    <xsl:text>&#x09;</xsl:text>
  </xsl:template>
  <xsl:template name="Tab4">
    <xsl:text>&#x09;</xsl:text>
    <xsl:text>&#x09;</xsl:text>
    <xsl:text>&#x09;</xsl:text>
    <xsl:text>&#x09;</xsl:text>
  </xsl:template>

</xsl:stylesheet>
