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
        
        [WebMethod]
        public string ReadByUnique(string NIF)
        {
            DirectorSegundaLinha record = Singleton<DirectorSegundaLinhaService>.Current.ReadByUnique(NIF);
            return record == null? "null": record.Nome;
        }

        [WebMethod]
        public long CreateEmpregado(int Numero, DateTime DtAdmissao, string Nome, DateTime DtNascimento, string NIF)
        {
            return Singleton<EmpregadoService>.Current.Create( Numero, DtAdmissao, Nome, DtNascimento, NIF );
        }

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
            NHibernateDaoFactory.Current.GetAlbumDao().GetById(albumId, false).Editor = NHibernateDaoFactory.Current.GetEditorDao().GetById(editorId, false);
        }

        [WebMethod]
        public string ReadAlbumEditor(long albumId)
        {
            return NHibernateDaoFactory.Current.GetAlbumDao().GetById(albumId, false).Editor.Nome;
        }

        [WebMethod]
        public void UpdateAlbumEditorNome(long albumId, string editorNome)
        {
            NHibernateDaoFactory.Current.GetAlbumDao().GetById(albumId, false).Editor.Nome = editorNome;
        }

        [WebMethod]
        public long AddEditorAlbum(string nome, string pais, string titulo)
        {
            Editor record = new Editor() { Nome = nome, Pais = pais };

            record.AddAlbum(new Album() { Titulo = titulo });

            if (!record.IsValid())
            {
                //throw new ArgumentException
            }

            NHibernateDaoFactory.Current.GetEditorDao().Save(record);

            return record.ID;
        }

        [WebMethod]
        public string ReadEditorAlbum(long recordId)
        {
            return NHibernateDaoFactory.Current.GetEditorDao().GetById(recordId, false).Albuns[0].Titulo;
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
