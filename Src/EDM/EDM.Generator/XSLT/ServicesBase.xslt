<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:include href="Common.xslt"/>
  <xsl:output method="text" indent="yes"/>
  <xsl:template match="entity">
using <xsl:value-of select="@baseNameSpace"/>;

namespace <xsl:value-of select="@servicesNameSpace"/>.Base
{
    public class <xsl:value-of select="@name"/>BaseService
    {        
        public long Create()
        {
            return 0;
        }
        
        public bool Update()
        {
            return false;
        }

        public <xsl:value-of select="@name"/> Read(long recordId)
        {
            return null;
        }

        public <xsl:value-of select="@name"/> ReadByUnique()
        {
            return null;
        }

        public bool Delete(long recordId)
        {
            return false;
        }
    }
}
  </xsl:template>
</xsl:stylesheet>
