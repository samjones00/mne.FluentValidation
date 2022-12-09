# MNE.FluentValidation
[![NuGet version (Newtonsoft.Json)](https://img.shields.io/nuget/v/mne.fluentvalidation.svg?style=flat-square)](https://www.nuget.org/packages/mne.fluentvalidation/)
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
