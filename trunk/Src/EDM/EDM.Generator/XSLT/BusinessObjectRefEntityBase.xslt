<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:include href="Common.xslt"/>
  <xsl:output method="text" indent="yes"/>
  <xsl:template match="entity">
using System;
using EDM.FoundationClasses.Entity;
using EDM.FoundationClasses.BusinessObject;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
using EDM.FoundationClasses.Exception;
using EDM.FoundationClasses.Exception.FoundationType;
using <xsl:value-of select="@rttiNameSpace"/>;
using System.Collections.Generic;

namespace <xsl:value-of select="@baseNameSpace"/>.BusinessObject.Base
{
  [Serializable]
  public class BO<xsl:value-of select="@name"/>Base : IBusinessObject  
  {
    <xsl:value-of select="@name"/> entity = null;
  
    public BO<xsl:value-of select="@name"/>Base( <xsl:value-of select="@name"/> entity )
    {
      if( entity == null ) throw new ArgumentNullException("entity");

      this.entity = entity;
    }

    <xsl:call-template name="WriteFields"/>

    public bool IsValid
    {
      get
      { 
        return entity.IsValid();
      }
    }
        
    public override int GetHashCode()
    {
      return entity.GetHashCode();
    }

    <!--Temos de verificar esta assunção onde a comparação do estado é-nos dada pelo valor da chave primária-->    
    public bool Equals(<xsl:value-of select="@name"/> obj)
    {
       return obj.ID == entity.ID;
    }
  }
}
  </xsl:template>
    
  <xsl:template match="fields/field" mode="field" >
    public virtual <xsl:value-of select="@edmType"/>&#160;<xsl:value-of select="@name"/> 
    { 
       get { return entity.<xsl:value-of select="@name"/>;  }
       set { entity.<xsl:value-of select="@name"/> = value; }
    }
  </xsl:template>


    <xsl:template name="WriteFields">
    <xsl:apply-templates select="fields/field" mode="field"/>
    <xsl:if test="@type = 'dependent' or @type = 'abstractdependent'">
      <xsl:variable name="varFieldCount" select="count(fields/field)"></xsl:variable>
      <xsl:variable name="varBaseEntity" select="@baseEntity"></xsl:variable>
      <xsl:for-each select="/solution/entities/entity[@name=$varBaseEntity]">
        <xsl:if test="$varFieldCount > 0 and count(/solution/entities/entity[@name=$varBaseEntity]/fields/field) > 0">, </xsl:if>
        <xsl:call-template name="WriteFields"></xsl:call-template>
      </xsl:for-each>
    </xsl:if>
  </xsl:template>




</xsl:stylesheet>
