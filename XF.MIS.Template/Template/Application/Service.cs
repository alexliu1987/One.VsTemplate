using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using $safeprojectname$.Domain.Repositories;
using $safeprojectname$.Domain.Repositories.Specifications;
using $safeprojectname$.IApplication;
using $safeprojectname$.Infrastructure;

namespace $safeprojectname$.Application
{
    public class Service<T, TK> : IService<T, TK>
        where T : EntityBase<TK> where TK : struct
    {
        private readonly IRepository<T, TK> _repository = Ioc.R<IRepository<T, TK>>();

        /// <summary>
        /// 根据主键查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T FindById(TK id)
        {
            return _repository.FindById(id);
        }

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> FindAll()
        {
            return _repository.FindAll();
        }

        /// <summary>
        /// 动态查询
        /// </summary>
        /// <param name="predicate">查询条件列表</param>
        /// <returns></returns>
        public virtual IEnumerable<T> Find(object predicate)
        {
            return _repository.Find(predicate);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="pages"></param>
        /// <returns>Item1：总记录数 Item2:查询列表</returns>
        public virtual Tuple<int, List<T>> FindPaging(Pages pages, object predicate)
        {
            return _repository.FindPaging(pages, predicate);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="pages"></param>
        /// <param name="func"></param>
        /// <returns>Item1：总记录数 Item2:查询列表</returns>
        public virtual Tuple<int, List<K>> FindPaging<K>(Pages pages, object predicate, Func<Tuple<int, List<T>>, Tuple<int, List<K>>> func)
        {
            return func(_repository.FindPaging(pages, predicate));
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="item"></param>
        public virtual TK Add(T item)
        {
            return _repository.Add(item);
        }

        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="items"></param>
        public virtual void Add(IEnumerable<T> items)
        {
            _repository.Add(items);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="item"></param>
        public virtual void Remove(T item)
        {
            _repository.Remove(item);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="item"></param>
        public virtual void Update(T item)
        {
            _repository.Update(item);
        }
    }
}
