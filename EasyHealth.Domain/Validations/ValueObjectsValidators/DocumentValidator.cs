using EasyHealth.Domain.Enums;
using EasyHealth.Domain.ValueObjects;
using FluentValidation;

namespace EasyHealth.Domain.Validations.ValueObjectsValidators;

public class DocumentValidator : AbstractValidator<Document>
{
    public DocumentValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("O campo documento não pode ser vázio!")
            .Length(11).WithMessage("O cpf deve ter 11 digitos!")
            .When(x => x.Type.ToString().Equals(EDocumentType.CPF.ToString(), StringComparison.OrdinalIgnoreCase));
        
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("O campo documento não pode ser vázio!")
            .Length(14).WithMessage("O cpf deve ter 14 digitos!")
            .When(x => x.Type.ToString().Equals(EDocumentType.CNPJ.ToString(), StringComparison.OrdinalIgnoreCase));
    }
}