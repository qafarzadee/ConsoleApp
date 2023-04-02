using System;
namespace ConsoleApp.Core.İnterfacesRepositories
{
    public interface IMainRepositores<T>
    {
        public void Create(T data);

        public T Get(Func<T, bool> expression);

        public List<T> GetAll();

        public void Delete(T data);
    }
}

