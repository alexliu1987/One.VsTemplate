using System.Web.Mvc;
using Autofac;
using $safeprojectname$.Domain.Repositories;
using $safeprojectname$.Domain.Repositories.Specifications;
using $safeprojectname$.IApplication;
using $safeprojectname$.Infrastructure;
using $safeprojectname$.Web.Models;

namespace $safeprojectname$.Web.Controllers
{
    public abstract class BaseController<T,TK> : Controller
        where T : EntityBase<TK> where TK : struct
    {
        private readonly IService<T, TK> _service;

        protected BaseController()
        {
            this._service = Ioc.R<IService<T, TK>>();
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult List()
        {
            return View();
        }

        protected abstract object GetPredicate(KeyValueParamModel[] filter);

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual JsonResult GetDataTable(JQueryDataTableParamModel param)
        {
            var result = _service.FindPaging(new Pages()
            {
                PageNumber = param.start / param.length,
                RecordPaginal = param.length
            }, GetPredicate(param.filter));
            return new JsonResult()
            {
                Data = new
                {
                    draw = param.draw,
                    recordsTotal = result.Item1,
                    recordsFiltered = result.Item1,
                    data = result.Item2
                }
            };
        }
    }
}