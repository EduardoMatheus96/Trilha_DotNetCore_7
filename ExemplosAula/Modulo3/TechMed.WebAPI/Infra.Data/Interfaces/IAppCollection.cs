using TechMed.WebAPI.Model;

namespace TechMed.WebAPI.Infra.Data.Interfaces;
public interface IAppCollection <T>
{
    void Create(T t);
    ICollection<T> GetAll();
    T? GetById(int id);
    void Update(int id, T t);
    void Delete(int id);
}
