using $safeprojectname$.Domain.Repositories;

namespace $safeprojectname$.Web
{
    /// <summary>
    /// Class that encapsulates most common parameters sent by DataTables plugin
    /// </summary>
    public class JQueryDataTableParamModel
    {
        /// <summary>
        /// Request sequence number sent by DataTable, same value must be returned in response
        /// </summary>       
        public int draw { get; set; }

        /// <summary>
        /// First record that should be shown(used for paging)
        /// </summary>
        public int start { get; set; }

        /// <summary>
        /// Number of records that should be shown in table
        /// </summary>
        public int length { get; set; }

        public KeyValueParamModel[] filter { get; set; }
    }
}

public class KeyValueParamModel
{
    public string Key { get; set; }
    public string Value { get; set; }
}