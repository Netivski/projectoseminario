<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
    <xsl:output method="xml" indent="yes"/>
  <xsl:template match="solution">
    <hibernate-configuration xmlns="urn:nhibernate-configuration-2.2">
    <session-factory>
      <property name="connection.provider">NHibernate.Connection.DriverConnectionProvider</property>
      <property name="dialect">
        <xsl:value-of select="environments/dataEnvironments/provider/@dialect"/>
      </property>
      <property name="connection.connection_string">
        <xsl:value-of select="environments/dataEnvironments/provider/@connectionString"/>
      </property>
      <xsl:apply-templates select="entities/entity"/>
    </session-factory>
    </hibernate-configuration>
  </xsl:template>

  <xsl:template match="entities/entity" xmlns="urn:nhibernate-configuration-2.2">
    <mapping file="{@nameSpace}.hbm.xml"/>
  </xsl:template>
  
</xsl:stylesheet>
