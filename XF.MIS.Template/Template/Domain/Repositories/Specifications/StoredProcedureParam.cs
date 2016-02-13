using System.Data;

namespace $safeprojectname$.Domain.Repositories
{
    public class StoredProcedureParam
    {
        public string Name { get; set; }

        public object Value { get; set; } = null;

        public DbType? DbType { get; set; } = default(DbType?);

        public ParameterDirection? Direction { get; set; } = default(ParameterDirection?);

        public int? Size { get; set; } = default(int?);
    }
}
