using EasyHealth.Domain.Shared;
using EasyHealth.Domain.Validations.ValueObjectsValidators;
using FluentValidation.Results;

namespace EasyHealth.Domain.ValueObjects;

public class Title : ValueObject
{
    public Title(string text)
        => Text = text;

    public string Text { get; private set; }

    public static implicit operator string(Title title)
        => title.ToString();

    public static implicit operator Title(string title)
        => new(title);

    public ValidationResult Validate()
        => new TitleValidator().Validate(this);

    public override string ToString()
        => Text;
}