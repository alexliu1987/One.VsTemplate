using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ConfigCenter.Provider;
using Dapper;
using DapperExtensions;
using $safeprojectname$.Domain.Repositories.Specifications;

namespace $safeprojectname$.Domain.Repositories
{
    public class Repository<T, TK> : IRepository<T, TK>
        where T : EntityBase<TK> where TK : struct
    {
        //        private static IDbConnection Connection => new SqlConnection(
        //            ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);

        private static IDbConnection Connection
        {
            get
            {
                return new SqlConnection(
                    AppSetting.Get("Key_App_Report", "Key_AppSetting_ConnectionString"));
            }
        }

        public virtual TK Add(T item)
        {
            using (var cn = Connection)
            {
                cn.Open();
                return item.Id = cn.Insert<T>(item);
            }
        }

        public virtual void Add(IEnumerable<T> items)
        {
            using (var cn = Connection)
            {
                cn.Open();
                cn.Insert<T>(items);
            }
        }

        public virtual void Update(T item)
        {
            using (var cn = Connection)
            {
                cn.Open();
                cn.Update<T>(item);
            }
        }

        // ReSharper disable once InconsistentNaming
        public K AllInOneTransaction<K>(Func<IDbConnection, IDbTransaction, K> func)
        {
            using (var cn = Connection)
            {
                cn.Open();
                var tran = cn.BeginTransaction();
                try
                {
                    var result = func(cn, tran);
                    tran.Commit();
                    return result;
                }
                catch (Exception)
                {
                    tran.Rollback();
                    throw;
                }
            }
        }

        // ReSharper disable once InconsistentNaming
        public IEnumerable<K> StoredProcedureWithQuery<K>(string spName, dynamic param)
        {
            using (var conn = Connection)
            {
                conn.Open();

                var p = new DynamicParameters();
                p.AddDynamicParams(param);

                var dyList = conn.Query<K>(spName, p, commandType: CommandType.StoredProcedure);
                return dyList;
            }
        }

        public NameValueCollection StoredProcedureWithExec(string spName,
        params StoredProcedureParam[] param)
        {
            using (var conn = Connection)
            {
                conn.Open();

                var p = new DynamicParameters();
                var returnNames = new List<string>();
                foreach (var procedureParam in param)
                {
                    var name = procedureParam.Name;
                    if (procedureParam.Direction == ParameterDirection.Output ||
                        procedureParam.Direction == ParameterDirection.ReturnValue)
                    {
                        returnNames.Add(name);
                    }

                    p.Add(procedureParam.Direction == ParameterDirection.ReturnValue ?
                        name : "@" + name,
                            procedureParam.Value,
                            procedureParam.DbType,
                            procedureParam.Direction,
                            procedureParam.Size);
                }

                conn.Execute(spName, p, commandType: CommandType.StoredProcedure);

                var nv = new NameValueCollection();
                foreach (var name in returnNames)
                {
                    var value = p.Get<dynamic>(name).ToString();
                    nv.Add(name.TrimStart('@'), value);
                }
                return nv;
            }
        }


        // ReSharper disable once InconsistentNaming
        public K Execute<K>(Func<IDbConnection, K> func)
        {
            using (var cn = Connection)
            {
                cn.Open();
                return func(cn);
            }
        }

        public virtual void Remove(T item)
        {
            using (var cn = Connection)
            {
                cn.Open();
                cn.Delete<T>(item);
            }
        }

        public virtual T FindById(TK id)
        {
            using (var cn = Connection)
            {
                cn.Open();
                return cn.Get<T>(id);
            }
        }

        public virtual IEnumerable<T> Find(object predicate)
        {
            using (var cn = Connection)
            {
                cn.Open();
                return cn.GetList<T>(predicate);
            }
        }

        public virtual Tuple<int, List<T>> FindPaging(Pages pages, object predicate = null)
        {
            using (var cn = Connection)
            {
                cn.Open();

                var sortArray = pages.SortFields.Where(t => !string.IsNullOrEmpty(t)).ToList();
                if (sortArray.Count == 0)
                    sortArray.Add("ID DESC");

                var sortList = sortArray.Select(sort => sort.Split(' ')).
                    Select(s => new Sort
                    {
                        PropertyName = s[0],
                        Ascending = s[1] == "asc"
                    }).Cast<ISort>().ToList();

                var results = cn.GetPage<T>(predicate, sortList,
                    pages.PageNumber - 1,
                    pages.RecordPaginal).ToList();

                var recordCount = cn.Count<T>(predicate);
                return Tuple.Create(recordCount, results);
            }
        }

        public virtual IEnumerable<T> FindAll()
        {
            using (var cn = Connection)
            {
                cn.Open();
                return cn.GetList<T>();
            }
        }
    }
}
