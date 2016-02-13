using FluentValidation;

namespace $safeprojectname$.Web.Models.Validators
{
    public class SampleViewModelValidator : AbstractValidator<SampleViewModel>
    {
        public SampleViewModelValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("名称不能为空！");
        }
    }
}