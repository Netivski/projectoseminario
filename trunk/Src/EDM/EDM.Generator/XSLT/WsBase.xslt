<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:include href="Common.xslt"/>
  <xsl:output method="text" indent="yes"/>
  <xsl:template match="entity">
using System.Web.Services;
using <xsl:value-of select="@baseNameSpace"/>;
using <xsl:value-of select="@servicesNameSpace"/>;

namespace <xsl:value-of select="@wsNameSpace"/>.Base
{
    [WebService(Namespace = "<xsl:value-of select="@wsHeaderNameSpace"/>")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class <xsl:value-of select="@name"/>BaseWs : System.Web.Services.WebService
    {
        static <xsl:value-of select="@name"/>Service bp = null;

        static <xsl:value-of select="@name"/>BaseWs()
        {
            bp = new <xsl:value-of select="@name"/>Service();
        }

        [WebMethod]
        public long Create()
        {
            return bp.Create();
        }

        [WebMethod]
        public bool Update()
        {
            return bp.Update();
        }

        [WebMethod]
        public <xsl:value-of select="@name"/> Read(long recordId)
        {
            return bp.Read(recordId);
        }

        [WebMethod]
        public <xsl:value-of select="@name"/> ReadByUnique()
        {
            return bp.ReadByUnique();
        }

        [WebMethod]
        public bool Delete(long recordId)
        {
            return bp.Delete(recordId);
        }
    }
}
  </xsl:template>
</xsl:stylesheet>
