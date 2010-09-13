
using EDM.FoundationClasses.Persistence.Core;
using EDM.FoundationClasses.Persistence.Data;
using ISEL.Sample.Entity;

namespace ISEL.Sample.Entity.DataInterfaces.Base
{
    /// <summary>
    /// Provides an interface for retrieving DAO objects
    ///</summary>

    public interface IDaoFactoryBase
    {
      
    ICalendarioDao GetCalendarioDao();
  
    IDocenteDao GetDocenteDao();
  
    IAnoDao GetAnoDao();
  
    IDisciplinaDao GetDisciplinaDao();
  
    ITurmaDao GetTurmaDao();
  
    ICursoDao GetCursoDao();
  
    IPersonDao GetPersonDao();
  
    IBlogDao GetBlogDao();
  
    IPostDao GetPostDao();
  
    ICommentDao GetCommentDao();
  
    IEditorDao GetEditorDao();
  
    IAlbumDao GetAlbumDao();
  
    ILPDao GetLPDao();
  
    IEPDao GetEPDao();
  
    IFaixaDao GetFaixaDao();
  
    IInterpreteDao GetInterpreteDao();
  
    ILojaDao GetLojaDao();
  
    }
}
  