using System.Runtime.InteropServices.JavaScript;
using System.Text.RegularExpressions;
using EasyHealth.Domain.ValueObjects;
using FluentValidation;

namespace EasyHealth.Domain.Validations.ValueObjectsValidators;

public partial class DocumentValidator : AbstractValidator<Document>
{
    private const string _pattern = @"[0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}";

    public DocumentValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("O campo cpf não pode ser vázio!")
            .Must(CpfRegex().IsMatch).WithMessage("Cpf no formato inválido!")
            .Must(Validate).WithMessage("Cpf inválido!");
    }

    [GeneratedRegex(_pattern)]
    public partial Regex CpfRegex();

    private bool Validate(string cpf)
    {
        cpf = cpf.Replace(".", "").Replace("-", "");

        if (cpf.Length != 11)
            return false;

        var CpfNumbers = new int[11];
        for (var number = 0; number < cpf.Length; number++)
            CpfNumbers[number] = (int)char.GetNumericValue(cpf[number]);

        var result = 0;
        for (var i = 0; i < CpfNumbers.Length - 2; i++)
            result += CpfNumbers[i] * (CpfNumbers.Length - 1 - i);

        result = (result * 10) % 11;

        if (result.Equals(10))
            result = 0;

        if (result.Equals(CpfNumbers[CpfNumbers.Length - 2]))
        {
            result = 0;
            for (var j = 0; j <= CpfNumbers.Length - 2; j++)
                result += CpfNumbers[j] * (CpfNumbers.Length - j);
        }

        result = (result * 10) % 11;

        return result.Equals(CpfNumbers[CpfNumbers.Length - 1]);
    }
}