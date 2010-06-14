<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="xml" version="1.0" encoding="utf-8" indent="yes"/>
  <xsl:template match="entity">

    <hibernate-mapping xmlns="urn:nhibernate-mapping-2.2">
      <class name="{@nameSpace}, {@assemblyName}" table="{@name}" lazy="false">
        <id name="ID" column="Id">
          <generator class="assigned" />
        </id>

        <xsl:apply-templates select="fields/field"/>        
      </class>
    </hibernate-mapping>
  </xsl:template>
  <xsl:template match="field">
    <property name="{@name}" column="{@name}" />    
 </xsl:template>  
</xsl:stylesheet>
