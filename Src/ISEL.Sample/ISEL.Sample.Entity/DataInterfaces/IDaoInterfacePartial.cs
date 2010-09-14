
using EDM.FoundationClasses.Persistence.Core;
using EDM.FoundationClasses.Persistence.Data;
using ISEL.Sample.Entity;
using ISEL.Sample.Entity.DataInterfaces.Base;

namespace ISEL.Sample.Entity.DataInterfaces
{
    // There's no need to declare each of the DAO interfaces in its own file, so just add them inline here.
    // But you're certainly welcome to put each declaration into its own file.
    #region Inline interface declarations
    
    public partial interface IPessoaDao : IPessoaDaoBase{ }
  
    public partial interface IEmpregadoDao : IEmpregadoDaoBase{ }
  
    public partial interface IManagerDao : IManagerDaoBase{ }
  
    public partial interface IDirectorDao : IDirectorDaoBase{ }
  
    public partial interface IDirectorPrimeiraLinhaDao : IDirectorPrimeiraLinhaDaoBase{ }
  
    public partial interface IDirectorSegundaLinhaDao : IDirectorSegundaLinhaDaoBase{ }
  
    public partial interface IClienteDao : IClienteDaoBase{ }
  
    public partial interface ICalendarioDao : ICalendarioDaoBase{ }
  
    public partial interface IDocenteDao : IDocenteDaoBase{ }
  
    public partial interface IAnoDao : IAnoDaoBase{ }
  
    public partial interface IDisciplinaDao : IDisciplinaDaoBase{ }
  
    public partial interface ITurmaDao : ITurmaDaoBase{ }
  
    public partial interface ICursoDao : ICursoDaoBase{ }
  
    public partial interface IPersonDao : IPersonDaoBase{ }
  
    public partial interface IBlogDao : IBlogDaoBase{ }
  
    public partial interface IPostDao : IPostDaoBase{ }
  
    public partial interface ICommentDao : ICommentDaoBase{ }
  
    public partial interface IEditorDao : IEditorDaoBase{ }
  
    public partial interface IAlbumDao : IAlbumDaoBase{ }
  
    public partial interface ILPDao : ILPDaoBase{ }
  
    public partial interface IEPDao : IEPDaoBase{ }
  
    public partial interface IFaixaDao : IFaixaDaoBase{ }
  
    public partial interface IInterpreteDao : IInterpreteDaoBase{ }
  
    public partial interface ILojaDao : ILojaDaoBase{ }
  
    public partial interface ILojaAlbumDao : ILojaAlbumDaoBase{ }
   
    #endregion
}
  