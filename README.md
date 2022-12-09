# MNE.FluentValidation

A simple custom validator for use with FluentValidation, validating whether a string is a base64 encoded value.

E.g.

```CSharp
public class FileUploadModelValidator : AbstractValidator<FileUploadModel>
{
    public FileUploadModelValidator()
    {
        RuleFor(x => x.Data).MustBeBase64Encoded();
    }
}
```