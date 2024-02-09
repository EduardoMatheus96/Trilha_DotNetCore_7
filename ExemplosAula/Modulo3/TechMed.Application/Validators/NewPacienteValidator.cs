using System.Text.RegularExpressions;
using FluentValidation;
using TechMed.Application.InputModels;

namespace TechMed.Application.Validators;
public class NewPacienteValidator : AbstractValidator<NewPacienteInputModel>
{
    public NewPacienteValidator()
    {
        RuleFor(p => p.Nome)
            .NotEmpty()
                .WithMessage("O nome do paciente é obrigatorio")
            .MinimumLength(3)
                .WithMessage("O nome do paciente deve ter no minimo três caracteres");
        RuleFor(p => p.Cpf)
            .NotEmpty()
                .WithMessage("O CPF do paciente é obrigatorio.")
            .Must(ValidateCpf)
                .WithMessage("O CPF deve estar no formato 000.000.000-00.");
        RuleFor(p => p.Email)
            .EmailAddress().WithMessage("O e-mail do paciente é invalido");
    }
    public static bool ValidateCpf(string cpf)
    {
        string cpfPattern = @"^\d{3}\.\d{3}\.\d{3}-\d{2}$";

        Regex regex = new(cpfPattern);

        return regex.IsMatch(cpf);
    }
}
