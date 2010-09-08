<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:include href="Common.xslt"/>
  <xsl:output method="text" indent="yes"/>
  <xsl:template match="entity">
    using System;
    using EDM.FoundationClasses.Entity;
    using EDM.FoundationClasses.FoundationType;
    using EDM.FoundationClasses.Persistence.Core;
    using ISEL.Sample.Entity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    namespace <xsl:value-of select="@unitTestNameSpace"/>
    {
      [TestClass()]
      public class <xsl:value-of select="@name"/>Test
      {
        private static <xsl:value-of select="@name"/> target;
        
        [ClassInitialize]
        public static void initTest(TestContext ctx)
        {
          target = new <xsl:value-of select="@name"/>();
        }
        
        [TestMethod()]
        public void <xsl:value-of select="@name"/>ConstructorTest()
        {
          Assert.IsNotNull(target, "Unable to instanciate a <xsl:value-of select="@name"/>.");
        }
        
        [TestMethod()]
        public void isValid<xsl:value-of select="@name"/>Test()
        {
          target = new <xsl:value-of select="@name"/>();
          Assert.IsTrue(target.IsValid(), "IsValid unexpectadely returned false.");
        }
     }
  }
  </xsl:template>
</xsl:stylesheet>
