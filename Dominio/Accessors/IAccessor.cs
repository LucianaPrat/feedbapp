using Dominio.DTO;

namespace Dominio.Accessors
{
    public interface IAccessor<T>
    {
        T GetById(int id);

        void Save(T t);
        void Update(T t);

        bool Exist(int id);

        List<T> GetAll();
        void Delete(T t);
    }
}
