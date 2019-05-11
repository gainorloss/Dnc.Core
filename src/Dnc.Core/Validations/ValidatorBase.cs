using FluentValidation;

namespace Dnc.Validations
{
    public class ValidatorBase<T>
        : AbstractValidator<T>
    {
        protected ValidatorBase()
            : base()
        { }
    }
}
