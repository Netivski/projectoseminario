<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:include href="Common.xslt"/>
  <xsl:output method="text" indent="yes"/>
  <xsl:template match="component">    
    <xsl:call-template name="lt"></xsl:call-template>%@ WebService Language="C#" CodeBehind="<xsl:value-of select="@name"/>Ws.asmx.cs" Class="<xsl:value-of select="@wsNameSpace"/>.<xsl:value-of select="@name"/>Ws" %<xsl:call-template name="gt"></xsl:call-template>    
  </xsl:template>
</xsl:stylesheet>
