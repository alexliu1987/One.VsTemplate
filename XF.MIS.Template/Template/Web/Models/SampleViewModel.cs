using System.ComponentModel.DataAnnotations;
using $safeprojectname$.Web.Models.Validators;

namespace $safeprojectname$.Web.Models
{
    [FluentValidation.Attributes.Validator(typeof(SampleViewModelValidator))]
    public class SampleViewModel
    {
        public long Id { get; set; }
        [Display(Name = "名称")]
        public string Name { get; set; }
    }
}