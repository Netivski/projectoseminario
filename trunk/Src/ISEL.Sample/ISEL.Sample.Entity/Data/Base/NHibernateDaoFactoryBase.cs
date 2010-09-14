
using EDM.FoundationClasses.Persistence.Core;
using EDM.FoundationClasses.Persistence.Data;
using ISEL.Sample.Entity;
using ISEL.Sample.Entity.DataInterfaces;
using ISEL.Sample.Entity.DataInterfaces.Base;



namespace ISEL.Sample.Entity.Data.Base
{
    /// <summary>
    /// Exposes access to NHibernate DAO classes.  Motivation for this DAO
    /// framework can be found at http://www.hibernate.org/328.html.
    /// </summary>
    public class NHibernateDaoFactoryBase : IDaoFactory
    {

      static readonly NHibernateDaoFactoryBase current = null;

      protected NHibernateDaoFactoryBase() { }

      static NHibernateDaoFactoryBase()
      {
        current = new NHibernateDaoFactoryBase();
      }

      public static NHibernateDaoFactoryBase Current
      {
        get { return current; }
      }


    
    public IPessoaDao GetPessoaDao() {
      return new PessoaDao();
    }
  
    public IEmpregadoDao GetEmpregadoDao() {
      return new EmpregadoDao();
    }
  
    public IManagerDao GetManagerDao() {
      return new ManagerDao();
    }
  
    public IDirectorDao GetDirectorDao() {
      return new DirectorDao();
    }
  
    public IDirectorPrimeiraLinhaDao GetDirectorPrimeiraLinhaDao() {
      return new DirectorPrimeiraLinhaDao();
    }
  
    public IDirectorSegundaLinhaDao GetDirectorSegundaLinhaDao() {
      return new DirectorSegundaLinhaDao();
    }
  
    public IClienteDao GetClienteDao() {
      return new ClienteDao();
    }
  
    public ICalendarioDao GetCalendarioDao() {
      return new CalendarioDao();
    }
  
    public IDocenteDao GetDocenteDao() {
      return new DocenteDao();
    }
  
    public IAnoDao GetAnoDao() {
      return new AnoDao();
    }
  
    public IDisciplinaDao GetDisciplinaDao() {
      return new DisciplinaDao();
    }
  
    public ITurmaDao GetTurmaDao() {
      return new TurmaDao();
    }
  
    public ICursoDao GetCursoDao() {
      return new CursoDao();
    }
  
    public IPersonDao GetPersonDao() {
      return new PersonDao();
    }
  
    public IBlogDao GetBlogDao() {
      return new BlogDao();
    }
  
    public IPostDao GetPostDao() {
      return new PostDao();
    }
  
    public ICommentDao GetCommentDao() {
      return new CommentDao();
    }
  
    public IEditorDao GetEditorDao() {
      return new EditorDao();
    }
  
    public IAlbumDao GetAlbumDao() {
      return new AlbumDao();
    }
  
    public ILPDao GetLPDao() {
      return new LPDao();
    }
  
    public IEPDao GetEPDao() {
      return new EPDao();
    }
  
    public IFaixaDao GetFaixaDao() {
      return new FaixaDao();
    }
  
    public IInterpreteDao GetInterpreteDao() {
      return new InterpreteDao();
    }
  
    public ILojaDao GetLojaDao() {
      return new LojaDao();
    }
  
    public ILojaAlbumDao GetLojaAlbumDao() {
      return new LojaAlbumDao();
    }
  

    }
}
  