using Dnc.API.Models;
using Dnc.Validations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dnc.API.Validations
{
    public class UserInputVmValidator
        :ValidatorBase<UserInputVm>
    {
        public UserInputVmValidator()
        {
            RuleFor(r => r.UName)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName}不允许为空")
                .MaximumLength(10)
                .WithMessage("{PropertyName}最大长度不能超过{MaxLength}");

            RuleFor(r => r.Pwd)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName}不允许为空")
                .MinimumLength(6)
                .WithMessage("{PropertyName}最小长度不能小于{MinLength}");
        }
    }
}
