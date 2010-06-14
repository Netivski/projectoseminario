<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="text" indent="yes"/>
  <xsl:template match="/">
    <xsl:apply-templates select="/solution/entities"/>  
  </xsl:template>

  <xsl:template match="entities">
    using BasicSample.Core.Domain;

    namespace BasicSample.Core.DataInterfaces
    {
      /// <summary>
      /// Provides an interface for retrieving DAO objects
      ///</summary>
    
    public interface IDaoFactory
    {
    <xsl:apply-templates select="entity" mode="interface"/>
    }

    // There's no need to declare each of the DAO interfaces in its own file, so just add them inline here.
    // But you're certainly welcome to put each declaration into its own file.
    #region Inline interface declarations
     <xsl:apply-templates select="entity" mode="declarations"/>
    #endregion
    }    
  </xsl:template>

  <xsl:template match="entity" mode="interface">
    I<xsl:value-of select="@name"/>Dao Get<xsl:value-of select="@name"/>Dao();
  </xsl:template>

  <xsl:template match="entity" mode="declarations">    
    public interface I<xsl:value-of select="@name"/>Dao : IDao<xsl:call-template name="lt"></xsl:call-template><xsl:value-of select="@name"/>, long<xsl:call-template name="gt"></xsl:call-template>{ }
  </xsl:template>

  <xsl:template name="gt">
    <xsl:text disable-output-escaping="yes"><![CDATA[>]]></xsl:text>
  </xsl:template>
  <xsl:template name="lt">
    <xsl:text disable-output-escaping="yes"><![CDATA[<]]></xsl:text>
  </xsl:template>

</xsl:stylesheet>
