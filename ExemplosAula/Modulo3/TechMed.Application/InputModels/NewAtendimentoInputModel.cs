namespace TechMed.Application.InputModels;
public class NewAtendimentoInputModel
{
    public DateTime DataHora { get; set; }
    public required NewMedicoInputModel Medico { get; set; }
    public required NewPacienteInputModel Paciente {get; set;}

    public NewAtendimentoInputModel(NewMedicoInputModel NewMedico ,NewPacienteInputModel NewPaciente)
    {
        DataHora = DateTime.Now;
        Medico = NewMedico;
        Paciente = NewPaciente;
    }
}
