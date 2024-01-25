using TechMed.Application.InputModels;

namespace TechMed.Application.ViewModels;
public class AtendimentoViewModel
{
    public DateTime DataHora { get; set; }
    public required NewMedicoInputModel Medico { get; set; }
    public required NewPacienteInputModel Paciente {get; set;}
}
