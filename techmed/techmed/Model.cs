using Microsoft.EntityFrameworkCore;

namespace Techmed.Model;
public class TechmedContext : DbContext
{
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Medic> Medics { get; set; }

    public TechmedContext() {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        base.OnConfiguring(optionsBuilder);
        var connectionString = "server=localhost;user=dotnet;password=tic2023;database=techmed";
        var serverVersion = ServerVersion.AutoDetect(connectionString);
        optionsBuilder.UseMySql(connectionString, serverVersion);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<Medic>().ToTable("medicos").HasKey(m => m.Id);
        modelBuilder.Entity<Patient>().ToTable("pacientes").HasKey(p => p.Id);

        
    }
}

public abstract class Person
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public int Age { get; set; }
}

public class Medic : Person
{

    public string Crm { get; set; }

    public string Specialty {get; set; }

    public decimal Wage { get; set; }
}

public class Patient : Person
{
    public string Cpf { get; set; }

    public string Adress { get; set; }

    public string Phone { get; set; }
}

