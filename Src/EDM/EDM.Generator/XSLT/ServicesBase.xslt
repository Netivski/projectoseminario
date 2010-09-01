<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:include href="Common.xslt"/>
  <xsl:output method="text" indent="yes"/>
  <xsl:template match="entity">
using System;    
using <xsl:value-of select="@baseNameSpace"/>;

namespace <xsl:value-of select="@servicesNameSpace"/>.Base
{
    public class <xsl:value-of select="@name"/>BaseService
    {        
        public static long Create(<xsl:call-template name="resolveRecursiveParams"></xsl:call-template>)
        {
            <xsl:value-of select="@name"/> record = new <xsl:value-of select="@name"/>();
            <xsl:call-template name="resolveRecursiveSetRecord"></xsl:call-template>
    
            //if( !record.IsValid() ) throw new .... 
            return 0;
        }
        
        public static bool Update(long recordId, <xsl:call-template name="resolveRecursiveParams"></xsl:call-template>)
        {
            <xsl:value-of select="@name"/> record = new <xsl:value-of select="@name"/>();
            //record.ID = recordId;
            <xsl:call-template name="resolveRecursiveSetRecord"></xsl:call-template>
             
             //if( !record.IsValid() ) throw new .... 
            
            return false;
        }

        public static <xsl:value-of select="@name"/> Read(long recordId)
        {
            return null;
        }

        public static <xsl:value-of select="@name"/> ReadByUnique()
        {
            return null;
        }

        public static bool Delete(long recordId)
        {
            return false;
        }
    }
}
  </xsl:template>

  <xsl:template match="fields/field" mode="params">
     <xsl:value-of select="@edmType"/>&#160;<xsl:value-of select="@name"/><xsl:if test="position() != last()">, </xsl:if>
  </xsl:template>

  <xsl:template match="fields/field" mode="setRecord">
            record.<xsl:value-of select="@name"/> = <xsl:value-of select="@name"/>;</xsl:template>

  <xsl:template name="resolveRecursiveParams">
    <xsl:apply-templates select="fields/field" mode="params"/>
    <xsl:if test="@type = 'dependent'">
      <xsl:if test="count(fields/field) > 0">, </xsl:if>
      <xsl:variable name="varBaseEntity" select="@baseEntity"></xsl:variable>
      <xsl:for-each select="//entity[@name=$varBaseEntity]">
        <xsl:call-template name="resolveRecursiveParams"></xsl:call-template>
      </xsl:for-each>
    </xsl:if>
  </xsl:template>

  <xsl:template name="resolveRecursiveSetRecord">
    <xsl:apply-templates select="fields/field" mode="setRecord"/>
    <xsl:if test="@type = 'dependent'">
      <xsl:variable name="varBaseEntity" select="@baseEntity"></xsl:variable>
      <xsl:for-each select="//entity[@name=$varBaseEntity]">
        <xsl:call-template name="resolveRecursiveSetRecord"></xsl:call-template>
      </xsl:for-each>
    </xsl:if>
  </xsl:template>

</xsl:stylesheet>
