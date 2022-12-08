using FluentValidation;
using MNE.FluentValidation.Test.Models;

namespace MNE.FluentValidation.Test.Validators
{
    public class FileUploadModelValidator : AbstractValidator<FileUploadModel>
    {
        public FileUploadModelValidator()
        {
            RuleFor(x => x.Data).MustBeBase64Encoded();
        }
    }
}