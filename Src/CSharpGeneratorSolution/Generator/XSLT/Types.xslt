<?xml version="1.0" encoding="utf-16"?>
<!--<?xml version="1.0" encoding="iso-8859-1"?>-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:output method="text" indent="yes"/>
  
  <xsl:template match="//customType">
using System;
using EDM.FoundationClasses.FoundationType;

namespace GenRtti
{
  //Auto-Generated class
  public static class <xsl:value-of select="@name"/> {
    
    public static ICustomType<xsl:text disable-output-escaping="yes"><![CDATA[<]]></xsl:text><xsl:value-of select="@baseType"/><xsl:text disable-output-escaping="yes">></xsl:text> custom<xsl:value-of select="@baseType"/>(
              BaseType.U<xsl:value-of select="@baseType"/>, 
              <xsl:choose>
                <xsl:when test="length/text() = ''"> 0</xsl:when>
                <xsl:otherwise>
                  <xsl:value-of select="length"/>
                </xsl:otherwise>                                
              </xsl:choose>,
              <xsl:choose>
                <xsl:when test="minLength/text() = ''"> 0</xsl:when>
                <xsl:otherwise>
                  <xsl:value-of select="minLength"/>
                </xsl:otherwise>
              </xsl:choose>,
              <xsl:choose>
                <xsl:when test="maxLength = &quot;&quot;"> 0</xsl:when>
                <xsl:otherwise>
                  <xsl:value-of select="maxLength"/>
                </xsl:otherwise>
              </xsl:choose>,
              <xsl:choose>
                <xsl:when test="pattern = &quot;&quot;"> null</xsl:when>
                <xsl:otherwise>
                  <xsl:value-of select="pattern"/>
                </xsl:otherwise>
              </xsl:choose>,
              <xsl:choose>
                <xsl:when test="enumeration = &quot;&quot;"> null</xsl:when>
                <xsl:otherwise>
                  <xsl:value-of select="enumeration"/>
                </xsl:otherwise>
              </xsl:choose>,
              <xsl:choose>
                <xsl:when test="minInclusive = &quot;&quot;"> 0 </xsl:when>
                <xsl:otherwise>
                  <xsl:value-of select="minInclusive"/>
                </xsl:otherwise>
              </xsl:choose>,
              <xsl:choose>
                <xsl:when test="minExclusive = &quot;&quot;"> 0 </xsl:when>
                <xsl:otherwise>
                  <xsl:value-of select="minExclusive"/>
                </xsl:otherwise>
              </xsl:choose>,
              <xsl:choose>
                <xsl:when test="maxInclusive = &quot;&quot;"> 0 </xsl:when>
                <xsl:otherwise>
                  <xsl:value-of select="maxInclusive"/>
                </xsl:otherwise>
              </xsl:choose>,
              <xsl:choose>
                <xsl:when test="maxExclusive = &quot;&quot;"> 0 </xsl:when>
                <xsl:otherwise>
                  <xsl:value-of select="maxExclusive"/>
                </xsl:otherwise>
              </xsl:choose>,
              <xsl:choose>
                <xsl:when test="whiteSpace = &quot;&quot;"> 0 </xsl:when>
                <xsl:otherwise>
                  <xsl:value-of select="whiteSpace"/>
                </xsl:otherwise>
              </xsl:choose>,
              <xsl:choose>
                <xsl:when test="totalDigits = &quot;&quot;"> 0 </xsl:when>
                <xsl:otherwise>
                  <xsl:value-of select="totalDigits"/>
                </xsl:otherwise>
              </xsl:choose>,
              <xsl:choose>
                <xsl:when test="fractionDigits = &quot;&quot;"> 0 </xsl:when>
                <xsl:otherwise>
                  <xsl:value-of select="fractionDigits"/>
                </xsl:otherwise>
              </xsl:choose>);
              
              public static bool IsValid(<xsl:value-of select="@baseType"/> value){
                  return Validator.IsValid(custom<xsl:value-of select="@baseType"/>, value);
              }
         }
    }
    </xsl:template>
</xsl:stylesheet>
