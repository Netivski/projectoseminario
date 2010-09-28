﻿
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
    public class CommentBaseService
    {   
       
        [RuntimeSecurity(SecurityAction.Demand, ClassName="CommentBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(string Content, DateTime CreateDt)
        {
            Comment record = new Comment(){ Content = Content, CreateDt = CreateDt };            
    
            if (!record.IsValid) throw record.StateException;

            DaoFactory.Current.GetCommentDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="CommentBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, string Content, DateTime CreateDt)
        {             
            ICommentDao dao = DaoFactory.Current.GetCommentDao();  

            Comment record = dao.GetById(recordId, false);
            record.Content = Content;
            record.CreateDt = CreateDt;            

            if (!record.IsValid) throw record.StateException;

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="CommentBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual Comment Read(long recordId)
        {
            return DaoFactory.Current.GetCommentDao().GetById(recordId, false);
        }

         
        [RuntimeSecurity(SecurityAction.Demand, ClassName="CommentBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            DaoFactory.Current.GetCommentDao().Delete( Read( recordId ) );
        }
                        
    }
}
  