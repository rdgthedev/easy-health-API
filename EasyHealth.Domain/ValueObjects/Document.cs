using EasyHealth.Domain.Shared;
using EasyHealth.Domain.Validations.ValueObjectsValidators;
using FluentValidation.Results;

namespace EasyHealth.Domain.ValueObjects;

public class Document : ValueObject
{
    public Document(string code)
        => Code = code;

    public string Code { get; private set; }

    public ValidationResult Validate()
        => new DocumentValidator().Validate(this);
}