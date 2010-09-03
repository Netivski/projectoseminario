<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:include href="Common.xslt"/>
  <xsl:output method="text" indent="yes"/>
  <xsl:template match="entity">
namespace <xsl:value-of select="@servicesNameSpace"/>
{
    public class <xsl:value-of select="@name"/>Service: Base.<xsl:value-of select="@name"/>BaseService
    {
    }
}
  </xsl:template>
</xsl:stylesheet>