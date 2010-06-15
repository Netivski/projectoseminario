<?xml version="1.0" encoding="iso-8859-1"?>

<!--<?xml version="1.0" encoding="iso-8859-1"?>-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" exclude-result-prefixes="">
  <xsl:output method="text"/>
  <xsl:template match="userTypes">
using System;
using EDM.FoundationClasses.FoundationType;
using <xsl:value-of select="@nameSpace"/>.Base;

namespace <xsl:value-of select="@nameSpace"/>
{
    public class UserTypeMetadata: BaseUserTypeMetadata
    {
        UserTypeMetadata() { }
    }
}
  </xsl:template>  
</xsl:stylesheet>
