
using System;    
using System.Security.Permissions;
using System.Security;
using EDM.FoundationClasses.Security.Permissions;
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
    
            if (!record.IsValid())
            {
                //throw new ArgumentException
            }

            NHibernateDaoFactory.Current.GetAlbumDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="AlbumBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, string Titulo)
        {             
            IAlbumDao dao = NHibernateDaoFactory.Current.GetAlbumDao();  

            Album record = dao.GetById(recordId, false);
            record.Titulo = Titulo;            

            if (!record.IsValid())
            {
                //throw new ArgumentException
            }

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="AlbumBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual Album Read(long recordId)
        {
            return NHibernateDaoFactory.Current.GetAlbumDao().GetById(recordId, false);
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="AlbumBaseService", MethodName="ReadByUnique", Unrestricted = false)] 
        public virtual Album ReadByUnique()
        {
            return null;
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="AlbumBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            NHibernateDaoFactory.Current.GetAlbumDao().Delete( Read( recordId ) );
        }
    }
}
  