<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  <xsl:output method="xml" indent="yes"/>

  <xsl:template match="/">
    
    <xsl:element name="?xml">
      <xsl:attribute name="version">1.0</xsl:attribute>
    </xsl:element>
  </xsl:template>

  
  <!DOCTYPE hibernate-mapping PUBLIC "-//Hibernate/Hibernate Mapping DTD 3.0//EN" "http://hibernate.sourceforge.net/hibernate-mapping-3.0.dtd">
  <hibernate-mapping package="org.hibernate.tutorial.domain">
    [...]
  </hibernate-mapping>

</xsl:stylesheet>
