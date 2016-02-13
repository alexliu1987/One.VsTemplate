using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DapperExtensions;
using $safeprojectname$.Domain.Repositories.Specifications;

namespace $safeprojectname$.Domain.Repositories
{
    /// <summary>
    /// 只读仓储定义
    /// </summary>
    /// <typeparam name="T">领域模型</typeparam>
    /// <typeparam name="TK">模型主键类型</typeparam>
    public interface IReadOnlyRepository<T, in TK>
        where T : EntityBase<TK> where TK : struct
    {
        /// <summary>
        /// 根据主键查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T FindById(TK id);

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> FindAll();

        /// <summary>
        /// 动态查询
        /// </summary>
        /// <param name="predicate">查询条件列表</param>
        /// <returns></returns>
        IEnumerable<T> Find(object predicate);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="pages"></param>
        /// <returns>Item1：总记录数 Item2:查询列表</returns>
        Tuple<int, List<T>> FindPaging(Pages pages, object predicate);
    }
}