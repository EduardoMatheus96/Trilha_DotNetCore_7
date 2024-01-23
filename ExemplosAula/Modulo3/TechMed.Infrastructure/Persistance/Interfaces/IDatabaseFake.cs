namespace TechMed.Infrastructure.Persistance.Interfaces;
public interface IDatabaseFake
{
   public IMedicoCollection MedicosCollection { get; }
   public IPacienteCollection PacientesCollection { get; }
   public IAtendimentoCollection AtendimentosCollection { get; }
}
