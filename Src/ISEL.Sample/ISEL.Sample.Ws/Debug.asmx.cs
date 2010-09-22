using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ISEL.Sample.Entity;
using ISEL.Sample.Entity.DataInterfaces;
using ISEL.Sample.Entity.Data;
using ISEL.Sample.Services;
using EDM.FoundationClasses.Patterns;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System.IO;
using System.Text;

namespace ISEL.Sample.Ws
{
    /// <summary>
    /// Summary description for Debug
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Debug : System.Web.Services.WebService
    {

        public class GetSchemaResult
        {
            public string SchemaExport { get; set; }
            public string SchemaUpdate { get; set; }
        }

        [WebMethod]
        public List<string> GetDirectorAlbum(long directorId)
        {
            Director director = DaoFactory.Current.GetDirectorDao().GetById(directorId, false); 

            List<string> rObj = new List<string>();
            foreach (DirectorAlbum album in director.Albuns) rObj.Add(string.Concat(album.Album.Titulo, album.Album.GetType().Name));

            return rObj;
        }


        [WebMethod]
        public GetSchemaResult GetSchema()
        {
            Configuration cfg = new Configuration();
            cfg.Configure();
            SchemaExport s = new SchemaExport(cfg);
            SchemaUpdate su = new SchemaUpdate(cfg);

            StringBuilder schemaExport = new StringBuilder();
            s.Execute(txt => schemaExport.Append(txt), false, false);
            StringBuilder schemaUpdate = new StringBuilder();
            su.Execute(txt => schemaUpdate.Append(txt), false);

            return new GetSchemaResult() { SchemaExport = schemaExport.ToString(), SchemaUpdate = schemaUpdate.ToString() };
        }

        [WebMethod]
        public List<string> GetAlbunsLoja(long lojaId)
        {
            Loja loja = Singleton<LojaService>.Current.Read(lojaId);
            List<string> rObj = new List<string>();
            foreach (LojaAlbum album in loja.Albuns) rObj.Add(string.Concat(album.Album.Titulo, album.Album.GetType().Name));

            loja.RemoveLojaAlbum(loja.Albuns[0]);

            return rObj;
            
        }

        
        [WebMethod]
        public string ReadByUnique(string NIF)
        {
            DirectorSegundaLinha record = Singleton<DirectorSegundaLinhaService>.Current.ReadByUnique(NIF);
            return record == null? "null": record.Nome;
        }

        //[WebMethod]
        //public long CreateEmpregado(int Numero, DateTime DtAdmissao, string Nome, DateTime DtNascimento, string NIF)
        //{
        //    return Singleton<EmpregadoService>.Current.Create( Numero, DtAdmissao, Nome, DtNascimento, NIF );
        //}

        [WebMethod]
        public long CreateDirectorSegundaLinha(int Antiguidade, double LimiteCartaoCredito, double LimiteAprovacao, int Numero, DateTime DtAdmissao, string Nome, DateTime DtNascimento, string NIF)
        {
            return Singleton<DirectorSegundaLinhaService>.Current.Create(Antiguidade, LimiteCartaoCredito, LimiteAprovacao, Numero, DtAdmissao, Nome, DtNascimento, NIF);
        }

        [WebMethod]
        public long CreateManager(int LitrosCombustivel, int Numero, DateTime DtAdmissao, string Nome, DateTime DtNascimento, string NIF)
        {
            return Singleton<ManagerService>.Current.Create(LitrosCombustivel, Numero, DtAdmissao, Nome, DtNascimento, NIF);
        }

        [WebMethod]
        public string ManyToOne(long albumId)
        {
            //Person person;
            //Blog blog;
            //Post post;
            //Comment comment;
            

            //IDocenteDao



            return string.Empty;
        }

        [WebMethod]
        public void AlbumChangeEditor(long albumId, long editorId)
        {
            DaoFactory.Current.GetAlbumDao().GetById(albumId, false).Editor = DaoFactory.Current.GetEditorDao().GetById(editorId, false);
        }

        [WebMethod]
        public string ReadAlbumEditor(long albumId)
        {
            return DaoFactory.Current.GetAlbumDao().GetById(albumId, false).Editor.Nome;
        }

        [WebMethod]
        public void UpdateAlbumEditorNome(long albumId, string editorNome)
        {
            DaoFactory.Current.GetAlbumDao().GetById(albumId, false).Editor.Nome = editorNome;
        }

        [WebMethod]
        public long AddEditorAlbum(string nome, string pais, string titulo)
        {
            Editor record = new Editor() { Nome = nome, Pais = pais };

            LP lp = null;
            record.AddAlbum(lp =  new LP() { Titulo = titulo });

            DaoFactory.Current.GetEditorDao().Save(record);

            DaoFactory.Current.GetLPDao().Save(lp);

            return record.ID;
        }

        [WebMethod]
        public string ReadEditorAlbum(long recordId)
        {
            return DaoFactory.Current.GetEditorDao().GetById(recordId, false).Albuns[0].Titulo;
        }


        [WebMethod]
        public long AddEditor(string nome, string pais)
        {
            return Singleton<EditorService>.Current.Create(nome, pais);
        }

        [WebMethod]
        public void UpdateEditor(long id, string nome, string pais)
        {
            Singleton<EditorService>.Current.Update( id, nome, pais);
        }

        [WebMethod]
        public string ReadEditor(long recordId)
        {
            return Singleton<EditorService>.Current.Read(recordId).Nome;
        }

        [WebMethod]
        public void DeleteEditor(long recordId)
        {
            Singleton<EditorService>.Current.Delete(recordId);
        }

    }
}
