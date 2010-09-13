<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:include href="Common.xslt"/>
  <xsl:output method="xml" version="1.0" encoding="utf-8" indent="yes"/>

  <xsl:template match="entity">
    <hibernate-mapping xmlns="urn:nhibernate-mapping-2.2">

      <xsl:call-template name="NewLine" />
      <xsl:call-template name="Tab1" />
      <class name="{@nameSpace}, {@assemblyName}" table="{@name}" lazy="false">

        <xsl:call-template name="NewLine" />
        <xsl:call-template name="Tab2" />
        <id name="ID" column="Id">

          <xsl:call-template name="NewLine" />
          <xsl:call-template name="Tab3" />
          <xsl:choose>
            <xsl:when test="count(relations/oneToOne) != 0">
              <generator class="foreign">                
                <xsl:apply-templates select="relations/oneToOne" mode="generator"/>
                <xsl:call-template name="NewLine" />
                <xsl:call-template name="Tab3" />
              </generator>                          
            </xsl:when>
            <xsl:otherwise>
              <generator class="identity" />
            </xsl:otherwise>
          </xsl:choose>
          

          <xsl:call-template name="NewLine" />
          <xsl:call-template name="Tab2" />
        </id>
        <xsl:apply-templates select="fields/field"/>

        <xsl:call-template name="NewLine" />
        <xsl:call-template name="Tab1" />
        
        <xsl:apply-templates select="relations/manyToOne"  mode="manyToOne" />
        <xsl:apply-templates select="relations/oneToMany"  mode="oneToMany" />        
        <!--
        <xsl:apply-templates select="relations/oneToOne"   mode="oneToOne" />        
        <xsl:apply-templates select="relations/manyToMany" mode="manyToMany" />
        -->
        
        <xsl:call-template name="NewLine" />
        <xsl:call-template name="Tab1" />

      </class>

      <xsl:call-template name="NewLine" />
    </hibernate-mapping>
  </xsl:template>

  <xsl:template match="field" xmlns="urn:nhibernate-mapping-2.2">
    <xsl:call-template name="NewLine" />
    <xsl:call-template name="Tab2" />
    <property name="{@name}" column="{@name}" not-null="{@nillable}"/>
  </xsl:template>

  <xsl:template match="oneToOne" mode="generator" xmlns="urn:nhibernate-mapping-2.2">
    <xsl:call-template name="NewLine" />
    <xsl:call-template name="Tab3" />
    <xsl:call-template name="Tab2" />
    <param name="property">
      <xsl:value-of select="@name"></xsl:value-of>
    </param>    
  </xsl:template>


  <xsl:template match="oneToOne" mode="oneToOne" xmlns="urn:nhibernate-mapping-2.2">
    <xsl:call-template name="NewLine" />
    <xsl:call-template name="Tab2" />
    <one-to-one name="{@name}" class="{@nameSpace}, {@assemblyName}"/>

  </xsl:template>
  
  <xsl:template match="manyToOne" mode="manyToOne" xmlns="urn:nhibernate-mapping-2.2">
    <xsl:call-template name="NewLine" />
    <xsl:call-template name="Tab2" />
    <many-to-one name="{@name}"
       class="{@nameSpace}, {@assemblyName}"
       column="{@fkName}" cascade="all"/>
  </xsl:template>
  

  <xsl:template match="oneToMany" mode="oneToMany" xmlns="urn:nhibernate-mapping-2.2">
    <xsl:call-template name="NewLine" />
    <xsl:call-template name="Tab2" />
    <bag name="_{@name}" access="field" table="{@entity}" inverse="true"> <xsl:call-template name="NewLine" /><xsl:call-template name="Tab3" />      
      <key column="{@fkName}" /><xsl:call-template name="NewLine" /><xsl:call-template name="Tab3" />
      <one-to-many class="{@nameSpace}, {@assemblyName}" /><xsl:call-template name="NewLine" /><xsl:call-template name="Tab2" />
    </bag>

  </xsl:template>

  <xsl:template match="manyToMany" mode="manyToMany" xmlns="urn:nhibernate-mapping-2.2">
    <xsl:call-template name="NewLine" />
    <xsl:call-template name="Tab2" />
    <bag name="{@name}" table="{@tableName}" inverse="true"> <xsl:call-template name="NewLine" /><xsl:call-template name="Tab3" />      
      <key column="{@parentField}" /><xsl:call-template name="NewLine" /><xsl:call-template name="Tab3" />
      <many-to-many column="{@childField}" class="{@nameSpace}, {@assemblyName}" /><xsl:call-template name="NewLine" /><xsl:call-template name="Tab2" />
    </bag>
  </xsl:template>

</xsl:stylesheet>
