using System.Collections.Generic;
using DapperExtensions;
using $safeprojectname$.Domain.Entity;
using $safeprojectname$.IApplication;
using $safeprojectname$.Web.Models;

namespace $safeprojectname$.Web.Controllers
{
    public class SampleController : BaseViewModelController<SampleModel, long, SampleViewModel>
    {
        private readonly IService<SampleModel, long> _service;

        public SampleController(IService<SampleModel, long> service)
        {
            _service = service;
        }

        protected override object GetPredicate(KeyValueParamModel[] filter)
        {
            if (filter == null) return null;
            var pg = new PredicateGroup()
            {
                Operator = GroupOperator.And,
                Predicates = new List<IPredicate>()
            };
            foreach (var model in filter)
            {
                if (model.Key == "Id"
                    && !string.IsNullOrEmpty(model.Value))
                    pg.Predicates.Add(Predicates.Field<SampleModel>(t => t.Id, Operator.Eq, model.Value));
                if (model.Key == "Name"
                    && !string.IsNullOrEmpty(model.Value))
                    pg.Predicates.Add(Predicates.Field<SampleModel>(t => t.Name, Operator.Eq, model.Value));
            }
            return pg;
        }
    }
}