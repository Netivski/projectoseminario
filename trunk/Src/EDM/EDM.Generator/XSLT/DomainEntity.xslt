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

namespace <xsl:value-of select="@baseNameSpace"/>.Domain
{
  [Serializable]
  public <xsl:if test="@type = 'abstract'">abstract</xsl:if> class <xsl:value-of select="@name"/>Domain : <xsl:choose><xsl:when test="@type = 'dependent'"><xsl:value-of select="@baseEntity"/></xsl:when><xsl:otherwise>DomainObject<xsl:call-template name="lt"></xsl:call-template>long<xsl:call-template name="gt"></xsl:call-template>, IEntity
  </xsl:otherwise></xsl:choose>
  {
    public <xsl:value-of select="@name"/>Domain () {}

    <xsl:apply-templates select="fields/field" mode="fields"/>

    public <xsl:choose><xsl:when test="@type = 'dependent'">override</xsl:when><xsl:otherwise>virtual</xsl:otherwise></xsl:choose> bool IsValid()
    {
      return <xsl:if test="@type = 'dependent'"> base.IsValid() <xsl:if test="count(fields/field) > 0"> <xsl:text disable-output-escaping="yes"><![CDATA[ &&]]></xsl:text> </xsl:if> </xsl:if> <xsl:apply-templates select="fields/field" mode="IsValid"/>;
    }

    public override int GetHashCode()
    {
      return string.Format("{0}.{1}", GetType().FullName, ID).GetHashCode();
    }

    <!--Temos de verificar esta assunção onde a comparação do estado é-nos dada pelo valor da chave primária-->    
    public bool Equals(<xsl:value-of select="@name"/> obj)
    {
      <xsl:choose> <xsl:when test="@type = 'dependent'"> return base.Equals((<xsl:value-of select="@baseEntity"/>)obj); </xsl:when> <xsl:otherwise> if(obj == null) return false; 
      return obj.ID == ID; </xsl:otherwise> </xsl:choose>  
    }
  }
}
  </xsl:template>
  <xsl:template match="fields/field" mode="fields">
    public virtual <xsl:value-of select="@edmType"/>&#160;<xsl:value-of select="@name"/> { get; set; }
  </xsl:template>
  
  <xsl:template match="fields/field" mode="IsValid">Validator.IsValid(UserTypeMetadata.<xsl:value-of select="@type"/>, <xsl:value-of select="@name"/>) <xsl:if test="position() != last()"> <xsl:text disable-output-escaping="yes"><![CDATA[&&]]></xsl:text> </xsl:if></xsl:template>

</xsl:stylesheet>
