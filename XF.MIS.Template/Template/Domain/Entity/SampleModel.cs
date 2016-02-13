using System;
using $safeprojectname$.Domain.Repositories;

namespace $safeprojectname$.Domain.Entity
{
    [Serializable]
    public sealed class SampleModel : EntityBase<long>
    {
        public string Name { get; set; }
    }
}
