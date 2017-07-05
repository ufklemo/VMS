namespace VMS.Model.Dependency
{
    #region 依赖生命周期类型枚举
    /// <summary>
    /// Lifestyles of types used in dependency injection system.
    /// </summary>
    public enum DependencyLifeStyle
    {
        /// <summary>
        /// Singleton object. Created a single object on first resolving
        /// and same instance is used for subsequent resolves.
        /// </summary>
        Singleton,

        /// <summary>
        /// Transient object. Created one object for every resolving.
        /// </summary>
        Transient
    }
    #endregion
}
