namespace $safeprojectname$.Infrastructure.Const
{
    /// <summary>
    /// 设备状态
    /// </summary>
    public class PadStatus
    {
        /// <summary>
        /// 正常使用中
        /// </summary>
        public const string NormalUse = "1001";

        /// <summary>
        /// 锁屏中
        /// </summary>
        public const string LockScreen = "1002";

        /// <summary>
        /// 应用擦除
        /// </summary>
        public const string ApplicationErase = "1003";

        /// <summary>
        /// 恢复出厂
        /// </summary>
        public const string RestoreFactory = "1004";

        /// <summary>
        /// 强制密码
        /// </summary>
        public const string CompulsoryPassword = "1005";

        /// <summary>
        /// 密码指定
        /// </summary>
        public const string PasswordSpecify = "1006";
    }
}
