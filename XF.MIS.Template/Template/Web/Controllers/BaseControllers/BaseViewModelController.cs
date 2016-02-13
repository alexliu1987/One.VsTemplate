using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Autofac;
using Autofac.Builder;
using AutoMapper;
using FluentValidation.Validators;
using $safeprojectname$.Domain.Repositories;
using $safeprojectname$.Domain.Repositories.Specifications;
using $safeprojectname$.IApplication;
using $safeprojectname$.Infrastructure;
using $safeprojectname$.Web.Models;

namespace $safeprojectname$.Web.Controllers
{
    public abstract class BaseViewModelController<T, TK, TViewModel> : BaseController<T, TK>
        where T : EntityBase<TK>
        where TK : struct
        where TViewModel : class
    {
        private readonly IService<T, TK> _service;

        protected BaseViewModelController()
        {
            _service = Ioc.R<IService<T, TK>>();
        }

        [HttpPost]
        public override JsonResult GetDataTable(JQueryDataTableParamModel param)
        {
            var result = _service.FindPaging(new Pages()
            {
                PageNumber = param.start / param.length,
                RecordPaginal = param.length
            }, GetPredicate(param.filter), t =>
            {
                var item2 = t.Item2.Select(Mapper.Map<T, TViewModel>).ToList();
                var res = new Tuple<int, List<TViewModel>>(t.Item1, item2);
                return res;
            });
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