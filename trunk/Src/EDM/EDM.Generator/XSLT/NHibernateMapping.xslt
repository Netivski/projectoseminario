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
          <generator class="assigned" />

          <xsl:call-template name="NewLine" />
          <xsl:call-template name="Tab2" />
        </id>
        <xsl:apply-templates select="fields/field"/>

        <xsl:call-template name="NewLine" />
        <xsl:call-template name="Tab1" />
      </class>

      <xsl:call-template name="NewLine" />
    </hibernate-mapping>
  </xsl:template>

  <xsl:template match="field" xmlns="urn:nhibernate-mapping-2.2">
    <xsl:call-template name="NewLine" />
    <xsl:call-template name="Tab2" />
    <property name="{@name}" column="{@name}" not-null="true"/>
  </xsl:template>

</xsl:stylesheet>
