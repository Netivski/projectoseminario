<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:include href="Common.xslt"/>
  <xsl:output method="text" indent="yes"/>
  <xsl:template match="entity">
using System;
using EDM.FoundationClasses.Entity;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
using <xsl:value-of select="@rttiNameSpace"/>;

namespace <xsl:value-of select="@baseNameSpace"/>
{
  [Serializable]
  public class <xsl:value-of select="@name"/> : Domain.<xsl:value-of select="@name"/>
  {
    public <xsl:value-of select="@name"/> () {}
  }
}
  </xsl:template>
</xsl:stylesheet>
