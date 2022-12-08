using System;
using System.Text.RegularExpressions;
using FluentValidation;

namespace MNE.FluentValidation
{
    public static class CustomFluentValidator
    {
        public static IRuleBuilderOptions<T, string> MustBeBase64Encoded<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(x =>
            {
                if (string.IsNullOrEmpty(x))
                    return false;

            //^\s*(?:(?:[A-Za-z0-9+/]{4})+\s*)*[A-Za-z0-9+/]*={0,2}\s*$
            var isMatch = Regex.IsMatch(x, @"^\s*(?:(?:[A-Za-z0-9+/]{4})+\s*)*[A-Za-z0-9+/]*={0,2}\s*$");

                return isMatch;

            }).WithMessage("Data is not a valid base64 value.");
        }
    }
}
