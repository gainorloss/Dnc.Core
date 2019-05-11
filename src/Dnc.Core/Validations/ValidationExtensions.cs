using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Validations
{
    public static class ValidationExtensions
    {
        /// <summary>
        /// String.IsNullOrEmpty()
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ruleBuilderInitial"></param>
        /// <returns></returns>
        public static IRuleBuilderInitial<T, string> NotNullOrEmpty<T>(this IRuleBuilderInitial<T, string> ruleBuilderInitial)
        {
            ruleBuilderInitial
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName}不能为空");
            return ruleBuilderInitial;
        }

        /// <summary>
        /// Max length.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ruleBuilderInitial"></param>
        /// <returns></returns>
        public static IRuleBuilderInitial<T, string> MaxLength<T>(this IRuleBuilderInitial<T, string> ruleBuilderInitial, int maxlength)
        {
            ruleBuilderInitial
                .MaximumLength(maxlength)
                .WithMessage("{PropertyName}长度不能超过{MaxLength}");
            return ruleBuilderInitial;
        }

        /// <summary>
        /// Min length.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ruleBuilderInitial"></param>
        /// <returns></returns>
        public static IRuleBuilderInitial<T, string> MinLength<T>(this IRuleBuilderInitial<T, string> ruleBuilderInitial, int minlength)
        {
            ruleBuilderInitial
                .MinimumLength(minlength)
                .WithMessage("{PropertyName}长度不能小于{MinLength}");
            return ruleBuilderInitial;
        }

        /// <summary>
        /// Range.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ruleBuilderInitial"></param>
        /// <returns></returns>
        public static IRuleBuilderInitial<T, int> Range<T>(this IRuleBuilderInitial<T, int> ruleBuilderInitial, int max, int min)
        {
            ruleBuilderInitial
                .GreaterThanOrEqualTo(min)
                .LessThanOrEqualTo(max)
                .WithMessage("{PropertyName}必须介于{Min}与{Max}之间");
            return ruleBuilderInitial;
        }

        /// <summary>
        /// Range.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ruleBuilderInitial"></param>
        /// <returns></returns>
        public static IRuleBuilderInitial<T, int> Min<T>(this IRuleBuilderInitial<T, int> ruleBuilderInitial, int min)
        {
            ruleBuilderInitial
                .GreaterThanOrEqualTo(min)
                .WithMessage("{PropertyName}必须大于等于{Min}");
            return ruleBuilderInitial;
        }

        /// <summary>
        /// Range.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ruleBuilderInitial"></param>
        /// <returns></returns>
        public static IRuleBuilderInitial<T, int> Max<T>(this IRuleBuilderInitial<T, int> ruleBuilderInitial, int max)
        {
            ruleBuilderInitial
                .LessThanOrEqualTo(max)
                .WithMessage("{PropertyName}必须介于小于等于{Max}");
            return ruleBuilderInitial;
        }

        /// <summary>
        /// Range.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ruleBuilderInitial"></param>
        /// <returns></returns>
        public static IRuleBuilderInitial<T, int> Between<T>(this IRuleBuilderInitial<T, int> ruleBuilderInitial, int max, int min)
        {
            ruleBuilderInitial
                .InclusiveBetween(min, max)
                .WithMessage("{PropertyName}必须介于{Min}与{Max}之间");
            return ruleBuilderInitial;
        }
    }
}
