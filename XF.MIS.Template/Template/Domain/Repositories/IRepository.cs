using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;

namespace $safeprojectname$.Domain.Repositories
{
    /// <summary>
    /// 仓储定义
    /// </summary>
    /// <typeparam name="T">领域模型</typeparam>
    /// <typeparam name="TK">模型主键类型</typeparam>
    public interface IRepository<T, TK> : IReadOnlyRepository<T, TK>
        where T : EntityBase<TK> where TK : struct
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="item"></param>
        TK Add(T item);

        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="items"></param>
        void Add(IEnumerable<T> items);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="item"></param>
        void Remove(T item);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="item"></param>
        void Update(T item);

        /// <summary>
        /// 事务打包
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        // ReSharper disable once InconsistentNaming
        K AllInOneTransaction<K>(Func<IDbConnection, IDbTransaction,K> func);

        /// <summary>
        /// 执行存储过程(返回查询列表)
        /// </summary>
        /// <param name="spName">存储过程名称</param>
        /// <param name="param">存储过程参数</param>
        /// <returns></returns>
        // ReSharper disable once InconsistentNaming
        IEnumerable<K> StoredProcedureWithQuery<K>(string spName, dynamic param);

        /// <summary>
        /// 执行存储过程(返回Output或Return参数)
        /// </summary>
        /// <param name="spName">存储过程名称</param>
        /// <param name="param">存储过程参数</param>
        /// <returns></returns>
        NameValueCollection StoredProcedureWithExec(string spName, params StoredProcedureParam[] param);

        /// <summary>
        /// 执行Sql入口
        /// </summary>
        /// <typeparam name="K">返回结果</typeparam>
        /// <param name="func">执行委托</param>
        /// <returns></returns>
        // ReSharper disable once InconsistentNaming
        K Execute<K>(Func<IDbConnection, K> func);
    }
}