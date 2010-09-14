
using System;    
using System.Security.Permissions;
using System.Security;
using EDM.FoundationClasses.Security.Permissions;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
using ISEL.Sample.Rtti;
using ISEL.Sample.Entity;
using ISEL.Sample.Entity.DataInterfaces;
using ISEL.Sample.Entity.Data;

namespace ISEL.Sample.Services.Base
{
    public class EditorBaseService
    {   
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="EditorBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(string Nome, string Pais)
        {
            Editor record = new Editor(){ Nome = Nome, Pais = Pais };            
    
            if (!record.IsValid())
            {
                //throw new ArgumentException
            }

            NHibernateDaoFactory.Current.GetEditorDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="EditorBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, string Nome, string Pais)
        {             
            IEditorDao dao = NHibernateDaoFactory.Current.GetEditorDao();  

            Editor record = dao.GetById(recordId, false);
            record.Nome = Nome;
            record.Pais = Pais;            

            if (!record.IsValid())
            {
                //throw new ArgumentException
            }

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="EditorBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual Editor Read(long recordId)
        {
            return NHibernateDaoFactory.Current.GetEditorDao().GetById(recordId, false);
        }

         
        [RuntimeSecurity(SecurityAction.Demand, ClassName="EditorBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            NHibernateDaoFactory.Current.GetEditorDao().Delete( Read( recordId ) );
        }
    }
}
  