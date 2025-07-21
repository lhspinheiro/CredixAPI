using CredixAPI.Communication.Request;
using FluentValidation;

namespace CredixAPI.Application.Validator;

public class ValidatorRequest : AbstractValidator<RequestLoansJson>
{
    public ValidatorRequest()
    {
        RuleFor(age => age.Age).NotEmpty().GreaterThanOrEqualTo(18).WithMessage("Age must be greater than 18.");
        RuleFor(cpf => cpf.CPF.Length).GreaterThanOrEqualTo(11).WithMessage("CPF must have 11 length.");
        RuleFor(name => name.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(income => income.Income).GreaterThanOrEqualTo(0).WithMessage("Income must be greater than 0.");
        RuleFor(location => location.Location).NotEmpty().Matches(@"^[^\d]*$").WithMessage("Location can't contain only numbers.");
    }
}