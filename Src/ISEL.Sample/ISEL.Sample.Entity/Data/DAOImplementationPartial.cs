
using EDM.FoundationClasses.Persistence.Core;
using EDM.FoundationClasses.Persistence.Data;
using ISEL.Sample.Entity;
using ISEL.Sample.Entity.DataInterfaces;
using ISEL.Sample.Entity.DataInterfaces.Base;



namespace ISEL.Sample.Entity.Data
{
       
    public partial class CalendarioDao : AbstractNHibernateDao<Calendario, long>, ICalendarioDao { }
      
    public partial class DocenteDao : AbstractNHibernateDao<Docente, long>, IDocenteDao { }
      
    public partial class AnoDao : AbstractNHibernateDao<Ano, long>, IAnoDao { }
      
    public partial class DisciplinaDao : AbstractNHibernateDao<Disciplina, long>, IDisciplinaDao { }
      
    public partial class TurmaDao : AbstractNHibernateDao<Turma, long>, ITurmaDao { }
      
    public partial class CursoDao : AbstractNHibernateDao<Curso, long>, ICursoDao { }
      
    public partial class PersonDao : AbstractNHibernateDao<Person, long>, IPersonDao { }
      
    public partial class BlogDao : AbstractNHibernateDao<Blog, long>, IBlogDao { }
      
    public partial class PostDao : AbstractNHibernateDao<Post, long>, IPostDao { }
      
    public partial class CommentDao : AbstractNHibernateDao<Comment, long>, ICommentDao { }
      
    public partial class EditorDao : AbstractNHibernateDao<Editor, long>, IEditorDao { }
      
    public partial class AlbumDao : AbstractNHibernateDao<Album, long>, IAlbumDao { }
      
    public partial class LPDao : AbstractNHibernateDao<LP, long>, ILPDao { }
      
    public partial class EPDao : AbstractNHibernateDao<EP, long>, IEPDao { }
      
    public partial class FaixaDao : AbstractNHibernateDao<Faixa, long>, IFaixaDao { }
      
    public partial class InterpreteDao : AbstractNHibernateDao<Interprete, long>, IInterpreteDao { }
      
    public partial class LojaDao : AbstractNHibernateDao<Loja, long>, ILojaDao { }
  
}
  