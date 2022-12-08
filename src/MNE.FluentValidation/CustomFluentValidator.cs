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

                return (x.Length % 4 == 0) && Regex.IsMatch(x, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);

            }).WithMessage("Data is not a valid base64 value.");
        }
    }
}