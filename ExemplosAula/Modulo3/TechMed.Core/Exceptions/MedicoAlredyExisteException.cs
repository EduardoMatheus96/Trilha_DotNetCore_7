namespace TechMed.Core.Exceptions;

public class MedicoAlredyExistsException : Exception
{
    public MedicoAlredyExistsException() :
        base("Já existe um médico com esse CRM.")
    {
    }
}
