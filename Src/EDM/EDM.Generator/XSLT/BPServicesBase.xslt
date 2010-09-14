<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:include href="Common.xslt"/>
  <xsl:output method="text" indent="yes"/>
  <xsl:template match="component">
using System;
using System.Security.Permissions;
using System.Security;
using EDM.FoundationClasses.Security.Permissions;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
using EDM.FoundationClasses.Exception.FoundationType;
using <xsl:value-of select="@rttiNameSpace"/>;
using System.Collections.Generic;


namespace <xsl:value-of select="@servicesNameSpace"/>.Base
{
    public abstract class <xsl:value-of select="@name"/>BaseService
    {        
        <xsl:apply-templates select="businessProcess"/>           
    }
}
  </xsl:template>

  <xsl:template match="businessProcess">    
        #region - <xsl:value-of select="@name"/>
        protected virtual void&#160;<xsl:value-of select="@name"/>ValidatePreCondition(<xsl:apply-templates select="input/param" mode="params"/>)
        {
          <xsl:apply-templates select="input/param" mode="isValid"/>
        }
        
        protected abstract <xsl:value-of select="output/@edmType"/>&#160;<xsl:value-of select="@name"/>Logic(<xsl:apply-templates select="input/param" mode="params"/>);  
        
        protected virtual void&#160;<xsl:value-of select="@name"/>ValidatePosCondition(<xsl:value-of select="output/@edmType"/> result)
        {
          if( !Validator.IsValid(UserTypeMetadata.<xsl:value-of select="output/@type"/>, result) )
          {
            throw new EDMArgumentException("ValidatePosCondition", "<xsl:value-of select="output/@type"/>", result.ToString());
          }
        }
        <xsl:call-template name="WriteRuntimeSecurity"><xsl:with-param name="methodName" select="@name"></xsl:with-param></xsl:call-template> 
        public virtual <xsl:value-of select="output/@edmType"/>&#160;<xsl:value-of select="@name"/>(<xsl:apply-templates select="input/param" mode="params"/>)
        {
          <xsl:value-of select="@name"/>ValidatePreCondition(<xsl:apply-templates select="input/param" mode="call"/>);
          <xsl:value-of select="output/@edmType"/> result = <xsl:value-of select="@name"/>Logic(<xsl:apply-templates select="input/param" mode="call"/>);
          <xsl:value-of select="@name"/>ValidatePosCondition(result);
          return result;
        }
        #endregion
</xsl:template>

  <xsl:template match="param" mode="params">
     <xsl:value-of select="@edmType"/>&#160;<xsl:value-of select="@name"/><xsl:if test="position() != last()">, </xsl:if>
  </xsl:template>

  <xsl:template match="param" mode="call">
    <xsl:value-of select="@name"/><xsl:if test="position() != last()">, </xsl:if>
  </xsl:template>

  <xsl:template match="param" mode="isValid">
          if( !Validator.IsValid(UserTypeMetadata.<xsl:value-of select="@type"/>, <xsl:value-of select="@name"/>) )
          {
            throw new EDMArgumentException("<xsl:value-of select="../../@name"/>ValidatePreCondition", "<xsl:value-of select="@type"/>", <xsl:value-of select="@name"/>.ToString());
          }
  </xsl:template>

</xsl:stylesheet>
