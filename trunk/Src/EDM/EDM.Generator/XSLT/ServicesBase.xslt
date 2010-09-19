<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:include href="Common.xslt"/>
  <xsl:output method="text" indent="yes"/>
  <xsl:template match="entity">
using System;    
using System.Security.Permissions;
using System.Security;
using EDM.FoundationClasses.Security.Permissions;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
using EDM.FoundationClasses.Exception.FoundationType;
using <xsl:value-of select="@rttiNameSpace"/>;
using <xsl:value-of select="@baseNameSpace"/>;
using <xsl:value-of select="@baseNameSpace"/>.DataInterfaces;
using <xsl:value-of select="@baseNameSpace"/>.Data;

namespace <xsl:value-of select="@servicesNameSpace"/>.Base
{
    public class <xsl:value-of select="@name"/>BaseService
    {   
       <xsl:if test="@type != 'abstract' and @type != 'abstractdependent'">    
        <xsl:call-template name="WriteRuntimeSecurity">
          <xsl:with-param name="methodName" select="'Create'"></xsl:with-param>
        </xsl:call-template> 
        public virtual long Create(<xsl:call-template name="resolveRecursiveParams"></xsl:call-template>)
        {
            <xsl:value-of select="@name"/> record = new <xsl:value-of select="@name"/>(){ <xsl:call-template name="resolveRecursiveSetRecordInline"></xsl:call-template> };            
    
            if (!record.IsValid) throw record.StateException;

            DaoFactory.Current.Get<xsl:value-of select="@name"/>Dao().Save(record);

            return record.ID;
        }
        
        <xsl:call-template name="WriteRuntimeSecurity">
          <xsl:with-param name="methodName" select="'Update'"></xsl:with-param>
        </xsl:call-template> 
        public virtual void Update(long recordId<xsl:call-template name="resolveUpdateRecursiveParams"></xsl:call-template>)
        {             
            I<xsl:value-of select="@name"/>Dao dao = DaoFactory.Current.Get<xsl:value-of select="@name"/>Dao();  

            <xsl:value-of select="@name"/> record = dao.GetById(recordId, false);<xsl:call-template name="resolveRecursiveSetRecordRecordBase"></xsl:call-template>            

            if (!record.IsValid) throw record.StateException;

            dao.SaveOrUpdate(record);                                                         
        }

        <xsl:call-template name="WriteRuntimeSecurity">
          <xsl:with-param name="methodName" select="'Read'"></xsl:with-param>
        </xsl:call-template> 
        public virtual <xsl:value-of select="@name"/> Read(long recordId)
        {
            return DaoFactory.Current.Get<xsl:value-of select="@name"/>Dao().GetById(recordId, false);
        }

         <xsl:if test="@writeReadByUnique = 'true'">
        <xsl:call-template name="WriteRuntimeSecurity">
          <xsl:with-param name="methodName" select="'ReadByUnique'"></xsl:with-param>
        </xsl:call-template> 
        public virtual <xsl:value-of select="@name"/> ReadByUnique(<xsl:call-template name="readByUniqueResolveRecursiveParams"/>)
        {
            <xsl:value-of select="@name"/> record = new <xsl:value-of select="@name"/>();
            <xsl:call-template name="ReadByUniqueIsValidRecursive"/>
            <xsl:call-template name="ReadByUniqueSetFieldsRecursive"/>

            return DaoFactory.Current.Get<xsl:value-of select="@name"/>Dao().GetUniqueByExample(record<xsl:call-template name="ReadByUniqueExcludeFieldsRecursive"/> );
        }
        </xsl:if>

        <xsl:call-template name="WriteRuntimeSecurity">
          <xsl:with-param name="methodName" select="'Delete'"></xsl:with-param>
        </xsl:call-template> 
        public virtual void Delete(long recordId)
        {
            DaoFactory.Current.Get<xsl:value-of select="@name"/>Dao().Delete( Read( recordId ) );
        }
        </xsl:if>                
    }
}
  </xsl:template>
  
  <xsl:template match="fields/field" mode="updateParams">, <xsl:value-of select="@edmType"/>&#160;<xsl:value-of select="@name"/></xsl:template>

  <xsl:template name="resolveUpdateRecursiveParams">
    <xsl:apply-templates select="fields/field" mode="updateParams"/>
    <xsl:if test="@type = 'dependent' or @type = 'abstractdependent'">
      <xsl:variable name="varBaseEntity" select="@baseEntity"></xsl:variable>
      <xsl:for-each select="//entity[@name=$varBaseEntity]">
        <xsl:call-template name="resolveUpdateRecursiveParams"></xsl:call-template>
      </xsl:for-each>
    </xsl:if>
  </xsl:template>  
  
  <xsl:template match="field" mode="ReadByUniqueExcludeFields">, "<xsl:value-of select="@name"/>"</xsl:template>

  <xsl:template name="ReadByUniqueExcludeFieldsRecursive">
    <xsl:apply-templates select="fields/field[@unique != 'true']" mode="ReadByUniqueExcludeFields"/>
    <xsl:if test="@type = 'dependent' or @type = 'abstractdependent'">
      <xsl:if test="count(fields/field[@unique != 'true']) > 0"> </xsl:if>
      <xsl:variable name="varBaseEntity" select="@baseEntity"></xsl:variable>
      <xsl:for-each select="//entity[@name=$varBaseEntity]"><xsl:call-template name="ReadByUniqueExcludeFieldsRecursive"></xsl:call-template></xsl:for-each>
    </xsl:if>
  </xsl:template>


  <xsl:template match="field" mode="ReadByUniqueSetFields">
            record.<xsl:value-of select="@name"/> = <xsl:value-of select="@name"/>; 
  </xsl:template>

  <xsl:template name="ReadByUniqueSetFieldsRecursive">
    <xsl:apply-templates select="fields/field[@unique = 'true']" mode="ReadByUniqueSetFields"/>
    <xsl:if test="@type = 'dependent' or @type = 'abstractdependent'">
      <xsl:if test="count(fields/field[@unique = 'true']) > 0">, </xsl:if>
      <xsl:variable name="varBaseEntity" select="@baseEntity"></xsl:variable>
      <xsl:for-each select="//entity[@name=$varBaseEntity]">
        <xsl:call-template name="ReadByUniqueSetFieldsRecursive"></xsl:call-template>
      </xsl:for-each>
    </xsl:if>    
  </xsl:template>


  <xsl:template match="field" mode="ReadByUniqueIsValid">
            if( !Validator.IsValid(UserTypeMetadata.<xsl:value-of select="@type"/>, <xsl:value-of select="@name"/>) )
            {
              throw new GeneralArgumentException<xsl:call-template name="lt"/><xsl:value-of select="@edmType"/><xsl:call-template name="gt"/>( "<xsl:value-of select="@name"/>", "<xsl:value-of select="@type"/>", <xsl:value-of select="@name"/>);
            }                    
  </xsl:template>

  <xsl:template name="ReadByUniqueIsValidRecursive">
    <xsl:apply-templates select="fields/field[@unique = 'true']" mode="ReadByUniqueIsValid"/>
    <xsl:if test="@type = 'dependent' or @type = 'abstractdependent'">
      <xsl:if test="count(fields/field[@unique = 'true']) > 0">, </xsl:if>
      <xsl:variable name="varBaseEntity" select="@baseEntity"></xsl:variable>
      <xsl:for-each select="//entity[@name=$varBaseEntity]">
        <xsl:call-template name="ReadByUniqueIsValidRecursive"></xsl:call-template>
      </xsl:for-each>
    </xsl:if>    
  </xsl:template>


  <xsl:template name="readByUniqueResolveRecursiveParams">
    <xsl:apply-templates select="fields/field[@unique = 'true']" mode="params"/>
    <xsl:if test="@type = 'dependent' or @type = 'abstractdependent'">
      <xsl:if test="count(fields/field[@unique = 'true']) > 0">, </xsl:if>
      <xsl:variable name="varBaseEntity" select="@baseEntity"></xsl:variable>
      <xsl:for-each select="//entity[@name=$varBaseEntity]">
        <xsl:call-template name="readByUniqueResolveRecursiveParams"></xsl:call-template>
      </xsl:for-each>
    </xsl:if>    
  </xsl:template>

  <xsl:template match="fields/field" mode="params">
     <xsl:value-of select="@edmType"/>&#160;<xsl:value-of select="@name"/><xsl:if test="position() != last()">, </xsl:if>
  </xsl:template>

  <xsl:template match="fields/field" mode="setRecordInLine">
 <xsl:value-of select="@name"/> = <xsl:value-of select="@name"/><xsl:if test="position() != last()">, </xsl:if>
</xsl:template>

  <xsl:template match="fields/field" mode="setRecordRecordBase">
            record.<xsl:value-of select="@name"/> = <xsl:value-of select="@name"/>;</xsl:template>  

  <xsl:template name="resolveRecursiveParams">    
    <xsl:apply-templates select="fields/field" mode="params"/>
    <xsl:if test="@type = 'dependent' or @type = 'abstractdependent'">
      <xsl:if test="count(fields/field) > 0">, </xsl:if>
      <xsl:variable name="varBaseEntity" select="@baseEntity"></xsl:variable>
      <xsl:for-each select="//entity[@name=$varBaseEntity]">
        <xsl:call-template name="resolveRecursiveParams"></xsl:call-template>
      </xsl:for-each>
    </xsl:if>
  </xsl:template>

  <xsl:template name="resolveRecursiveSetRecordInline">
    <xsl:apply-templates select="fields/field" mode="setRecordInLine"/>
    <xsl:if test="@type = 'dependent' or @type = 'abstractdependent'">
      <xsl:variable name="varBaseEntity" select="@baseEntity"></xsl:variable>
      <xsl:if test="count(fields/field) > 0">, </xsl:if>
      <xsl:for-each select="//entity[@name=$varBaseEntity]">        
        <xsl:call-template name="resolveRecursiveSetRecordInline"></xsl:call-template> </xsl:for-each>
    </xsl:if>    
  </xsl:template>

  <xsl:template name="resolveRecursiveSetRecordRecordBase">
    <xsl:if test="@type = 'dependent' or @type = 'abstractdependent'">
      <xsl:variable name="varBaseEntity" select="@baseEntity"></xsl:variable>
      <xsl:for-each select="//entity[@name=$varBaseEntity]">
        <xsl:call-template name="resolveRecursiveSetRecordRecordBase"></xsl:call-template></xsl:for-each>
    </xsl:if>
    <xsl:apply-templates select="fields/field" mode="setRecordRecordBase"/>    
  </xsl:template>
  
  
</xsl:stylesheet>
