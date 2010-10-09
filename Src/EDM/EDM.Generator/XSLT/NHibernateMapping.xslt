﻿<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:include href="Common.xslt"/>
  <xsl:output method="xml" version="1.0" encoding="utf-8" indent="yes"/>

  <xsl:template match="entity">
    <hibernate-mapping xmlns="urn:nhibernate-mapping-2.2">

      <xsl:call-template name="NewLine" />
      <xsl:call-template name="Tab1" />      
  <xsl:choose>
    <xsl:when test="@type = 'abstractdependent' or @type = 'dependent'">
      <subclass name="{@nameSpace}, {@assemblyName}" extends="{@assemblyName}.{@baseEntity}, {@assemblyName}" discriminator-value="{@name}" abstract="{@abstract}">
        <xsl:call-template name="resolveFields"></xsl:call-template>

        <xsl:call-template name="NewLine" />
        <xsl:call-template name="Tab1" />

        <xsl:apply-templates select="relations/manyToOne"  mode="manyToOne" />
        <xsl:apply-templates select="relations/oneToMany"  mode="oneToMany" />

        <xsl:call-template name="NewLine" />
        <xsl:call-template name="Tab1" />
      </subclass>
    </xsl:when>
    <xsl:otherwise>
      <class name="{@nameSpace}, {@assemblyName}" table="{@masterEntity}" lazy="false" abstract="{@abstract}">
        <xsl:call-template name="NewLine" />
        <xsl:call-template name="Tab2" />
        <id name="ID" column="Id">
          <xsl:call-template name="NewLine" />
          <xsl:call-template name="Tab3" />
              <generator class="identity" />          
          <xsl:call-template name="NewLine" />
          <xsl:call-template name="Tab2" />
        </id>
        <xsl:if test="@type='abstract'">
          <xsl:call-template name="NewLine" />
          <xsl:call-template name="Tab2" />
          <discriminator column="EntityType" type="String" />
        </xsl:if>
        <xsl:call-template name="resolveFields"></xsl:call-template>

        <xsl:call-template name="NewLine" />
        <xsl:call-template name="Tab1" />
        
        <xsl:apply-templates select="relations/manyToOne"  mode="manyToOne" />
        <xsl:apply-templates select="relations/oneToMany"  mode="oneToMany" />        
        
        <xsl:call-template name="NewLine" />
        <xsl:call-template name="Tab1" />
      </class>
    </xsl:otherwise>
  </xsl:choose>
      <xsl:call-template name="NewLine" />
    </hibernate-mapping>
  </xsl:template>

  <xsl:template name="resolveFields">
    <xsl:apply-templates select="fields/field"/>
  </xsl:template>


  <xsl:template name="resolveRecursiveFields">
    <xsl:apply-templates select="fields/field"/>
    <xsl:if test="@type = 'dependent' or @type = 'abstractdependent'">
      <xsl:if test="count(fields/field) > 0"> </xsl:if>
      <xsl:variable name="varBaseEntity" select="@baseEntity"></xsl:variable>
      <xsl:for-each select="/solution/entities/entity[@name=$varBaseEntity]">
        <xsl:call-template name="resolveRecursiveFields"></xsl:call-template>
      </xsl:for-each>
    </xsl:if>
  </xsl:template>

  <xsl:template match="field" xmlns="urn:nhibernate-mapping-2.2">
    <xsl:call-template name="NewLine" />
    <xsl:call-template name="Tab2" />
    <property name="{@name}" column="{@name}" not-null="{@not-null}"/>
  </xsl:template>
  
  <xsl:template match="manyToOne" mode="manyToOne" xmlns="urn:nhibernate-mapping-2.2">
    <xsl:call-template name="NewLine" />
    <xsl:call-template name="Tab2" />
    <many-to-one name="{@name}" class="{@nameSpace}, {@assemblyName}" column="{@fkName}" cascade="all"/>
  </xsl:template>
  

  <xsl:template match="oneToMany" mode="oneToMany" xmlns="urn:nhibernate-mapping-2.2">
    <xsl:call-template name="NewLine" />
    <xsl:call-template name="Tab2" />
    <bag name="_{@name}" access="field" table="{@entity}" inverse="true" cascade="all"> <xsl:call-template name="NewLine" /><xsl:call-template name="Tab3" />      
      <key column="{@fkName}" /><xsl:call-template name="NewLine" /><xsl:call-template name="Tab3" />
      <one-to-many class="{@nameSpace}, {@assemblyName}" /><xsl:call-template name="NewLine" /><xsl:call-template name="Tab2" />
    </bag>

  </xsl:template>

  <xsl:template match="manyToMany" mode="manyToMany" xmlns="urn:nhibernate-mapping-2.2">
    <xsl:call-template name="NewLine" />
    <xsl:call-template name="Tab2" />
    <bag name="{@name}" table="{@tableName}" inverse="true" cascade="all"> <xsl:call-template name="NewLine" /><xsl:call-template name="Tab3" />      
      <key column="{@parentField}" /><xsl:call-template name="NewLine" /><xsl:call-template name="Tab3" />
      <many-to-many column="{@childField}" class="{@nameSpace}, {@assemblyName}" /><xsl:call-template name="NewLine" /><xsl:call-template name="Tab2" />
    </bag>
  </xsl:template>

</xsl:stylesheet>
