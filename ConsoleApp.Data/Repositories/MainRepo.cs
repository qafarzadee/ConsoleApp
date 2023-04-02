using System;
namespace ConsoleApp.Data.Repositories
{
    public class MainRepo<T> : IMainRepositories<T>
    {
        public List<T> products = new List<T>();
        public void Create(T data)
        {
            products.Add(data);
        }

        public void Delete(T data)
        {
            products.Remove(data);
        }

        public T Get(Func<T, bool> expression)
        {
            T info = products.FirstOrDefault(expression);
            return info;
        }

        public List<T> GetAll()
        {
            return products;
        }
    }
}

