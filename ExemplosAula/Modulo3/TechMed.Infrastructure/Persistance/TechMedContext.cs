using TechMed.Infrastructure.Persistance.Interfaces;
namespace TechMed.Infrastructure.Persistance;
public class TechMedContext : ITechMedContext
{
   public IMedicoCollection MedicosCollection { get; } = new MedicosDB();
   public IPacienteCollection PacientesCollection { get; } = new PacientesDB();
   public IAtendimentoCollection AtendimentosCollection { get; } = new AtendimentosDB();
}
