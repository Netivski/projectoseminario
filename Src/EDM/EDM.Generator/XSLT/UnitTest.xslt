<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:include href="Common.xslt"/>
  <xsl:output method="text" indent="yes"/>
  <xsl:template match="entity">
using System;
using EDM.FoundationClasses.Entity;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using <xsl:value-of select="@baseNameSpace"/>;
using <xsl:value-of select="@servicesNameSpace"/>;

namespace <xsl:value-of select="@unitTestNameSpace"/> 
{
  [TestClass]
  public class <xsl:value-of select="@name"/>Test: Base.<xsl:value-of select="@name"/>BaseTest
  {
  }
}
  </xsl:template>
  
</xsl:stylesheet>
