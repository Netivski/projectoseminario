
using System;    
using System.Security.Permissions;
using System.Security;
using EDM.FoundationClasses.Security.Permissions;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
using EDM.FoundationClasses.Exception.FoundationType;
using ISEL.Sample.Rtti;
using ISEL.Sample.Entity;
using ISEL.Sample.Entity.DataInterfaces;
using ISEL.Sample.Entity.Data;

namespace ISEL.Sample.Services.Base
{
    public class AlbumBaseService
    {   
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="AlbumBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(string Titulo)
        {
            Album record = new Album(){ Titulo = Titulo };            
    
            if (!record.IsValid) throw record.StateException;

            DaoFactory.Current.GetAlbumDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="AlbumBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, string Titulo)
        {             
            IAlbumDao dao = DaoFactory.Current.GetAlbumDao();  

            Album record = dao.GetById(recordId, false);
            record.Titulo = Titulo;            

            if (!record.IsValid) throw record.StateException;

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="AlbumBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual Album Read(long recordId)
        {
            return DaoFactory.Current.GetAlbumDao().GetById(recordId, false);
        }

         
        [RuntimeSecurity(SecurityAction.Demand, ClassName="AlbumBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            DaoFactory.Current.GetAlbumDao().Delete( Read( recordId ) );
        }
    }
}
  