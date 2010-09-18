<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  <xsl:include href="Common.xslt"/>
  <xsl:output method="xml" indent="yes"/>
  
  <xsl:template match="solution">
    <hibernate-configuration xmlns="urn:nhibernate-configuration-2.2">
      
      <xsl:call-template name="NewLine" />
      <xsl:call-template name="Tab1" />
      <session-factory>
        
        <xsl:call-template name="NewLine" />
        <xsl:call-template name="Tab2" />
        <property name="connection.provider">
      NHibernate.Connection.DriverConnectionProvider<xsl:call-template name="NewLine" />
        <xsl:call-template name="Tab2" />
        </property>
        
        <xsl:call-template name="NewLine" />
        <xsl:call-template name="Tab2" />
        <property name="dialect">NHibernate.Dialect.<xsl:value-of select="environments/dataEnvironments/provider/@type"/>Dialect</property>
        
        <xsl:call-template name="NewLine" />
        <xsl:call-template name="Tab2" />
        <property name="show_sql">true</property>

        <xsl:call-template name="NewLine" />
        <xsl:call-template name="Tab2" />
        <property name="use_proxy_validator">false</property>

        <xsl:call-template name="NewLine" />
        <xsl:call-template name="Tab2" />
        <property name="proxyfactory.factory_class"> NHibernate.ByteCode.LinFu.ProxyFactoryFactory, NHibernate.ByteCode.LinFu </property>
        
        <xsl:call-template name="NewLine" />
        <xsl:call-template name="Tab2" />
        <property name="connection.connection_string">
          
          <xsl:call-template name="NewLine" />
          <xsl:call-template name="Tab3" />
          <xsl:value-of select="environments/dataEnvironments/provider/@connectionString"/>
        
        <xsl:call-template name="NewLine" />
        <xsl:call-template name="Tab2" />
        </property>
        
        <xsl:apply-templates select="entities/entity"/>

        <xsl:call-template name="NewLine" />
        <xsl:call-template name="Tab1" />
      </session-factory>

    <xsl:call-template name="NewLine" />
    </hibernate-configuration>
  </xsl:template>

  <xsl:template match="entities/entity" xmlns="urn:nhibernate-configuration-2.2">
    <xsl:call-template name="NewLine" />
    <xsl:call-template name="Tab2" />
    <mapping file="{@targetDomainPath}\{@name}.hbm.xml"/>
  </xsl:template>
  
</xsl:stylesheet>
