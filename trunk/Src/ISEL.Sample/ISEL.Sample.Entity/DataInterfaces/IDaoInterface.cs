
using EDM.FoundationClasses.Persistence.Core;
using EDM.FoundationClasses.Persistence.Data;
using ISEL.Sample.Entity;
using ISEL.Sample.Entity.DataInterfaces.Base;

namespace ISEL.Sample.Entity.DataInterfaces
{
    // There's no need to declare each of the DAO interfaces in its own file, so just add them inline here.
    // But you're certainly welcome to put each declaration into its own file.
    #region Inline interface declarations

    public partial interface IDocenteDao : IDocenteDaoBase
    {
        int Soma( int a, int b );
    }

    #endregion
}
  