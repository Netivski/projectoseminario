
using EDM.FoundationClasses.Persistence.Core;
using EDM.FoundationClasses.Persistence.Data;
using ISEL.Sample.Entity;
using ISEL.Sample.Entity.DataInterfaces;
using ISEL.Sample.Entity.DataInterfaces.Base;

namespace ISEL.Sample.Entity.Data
{
    public partial class DocenteDao : AbstractNHibernateDao<Docente, long>, IDocenteDao
    {
        public int Soma(int a, int b) { return a + b; }
    }
}
