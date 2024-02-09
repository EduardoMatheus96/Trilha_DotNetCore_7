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
    }
}
