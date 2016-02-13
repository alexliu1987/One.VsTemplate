using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using $safeprojectname$.Domain.Repositories;
using $safeprojectname$.Domain.Repositories.Specifications;

namespace $safeprojectname$.IApplication
{
    public interface IService<T, TK>
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

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="pages"></param>
        /// <param name="func"></param>
        /// <returns>Item1：总记录数 Item2:查询列表</returns>
        Tuple<int, List<K>> FindPaging<K>(Pages pages, object predicate,
            Func<Tuple<int, List<T>>, Tuple<int, List<K>>> func);

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
    }
}
