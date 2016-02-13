using System.ComponentModel;

namespace $safeprojectname$.Infrastructure.Enums
{
    /// <summary>
    /// 审核通过与否
    /// </summary>
    public enum ApprovalStatus
    {
        /// <summary>
        /// Yes
        /// </summary>
        [Description("Yes")]
        Yes = 1,

        /// <summary>
        /// No
        /// </summary>
        [Description("No")]
        No = 0,
    }
}
