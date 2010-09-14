
using EDM.FoundationClasses.Persistence.Core;
using EDM.FoundationClasses.Persistence.Data;
using ISEL.Sample.Entity;

namespace ISEL.Sample.Entity.DataInterfaces.Base
{
    // There's no need to declare each of the DAO interfaces in its own file, so just add them inline here.
    // But you're certainly welcome to put each declaration into its own file.
    #region Inline interface declarations 
      
    public interface IPessoaDaoBase : IDao<Pessoa, long>{ }
  
    public interface IEmpregadoDaoBase : IDao<Empregado, long>{ }
  
    public interface IManagerDaoBase : IDao<Manager, long>{ }
  
    public interface IDirectorDaoBase : IDao<Director, long>{ }
  
    public interface IDirectorPrimeiraLinhaDaoBase : IDao<DirectorPrimeiraLinha, long>{ }
  
    public interface IDirectorSegundaLinhaDaoBase : IDao<DirectorSegundaLinha, long>{ }
  
    public interface IClienteDaoBase : IDao<Cliente, long>{ }
  
    public interface ICalendarioDaoBase : IDao<Calendario, long>{ }
  
    public interface IDocenteDaoBase : IDao<Docente, long>{ }
  
    public interface IAnoDaoBase : IDao<Ano, long>{ }
  
    public interface IDisciplinaDaoBase : IDao<Disciplina, long>{ }
  
    public interface ITurmaDaoBase : IDao<Turma, long>{ }
  
    public interface ICursoDaoBase : IDao<Curso, long>{ }
  
    public interface IPersonDaoBase : IDao<Person, long>{ }
  
    public interface IBlogDaoBase : IDao<Blog, long>{ }
  
    public interface IPostDaoBase : IDao<Post, long>{ }
  
    public interface ICommentDaoBase : IDao<Comment, long>{ }
  
    public interface IEditorDaoBase : IDao<Editor, long>{ }
  
    public interface IAlbumDaoBase : IDao<Album, long>{ }
  
    public interface ILPDaoBase : IDao<LP, long>{ }
  
    public interface IEPDaoBase : IDao<EP, long>{ }
  
    public interface IFaixaDaoBase : IDao<Faixa, long>{ }
  
    public interface IInterpreteDaoBase : IDao<Interprete, long>{ }
  
    public interface ILojaDaoBase : IDao<Loja, long>{ }
  
    #endregion 
}
  