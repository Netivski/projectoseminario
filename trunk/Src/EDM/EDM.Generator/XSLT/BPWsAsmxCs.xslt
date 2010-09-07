<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:include href="Common.xslt"/>
  <xsl:output method="text" indent="yes"/>
  <xsl:template match="component">    
namespace <xsl:value-of select="@wsNameSpace"/>
{
    public class <xsl:value-of select="@name"/>Ws : Base.<xsl:value-of select="@name"/>BaseWs
    {
    }
}    
  </xsl:template>
</xsl:stylesheet>
