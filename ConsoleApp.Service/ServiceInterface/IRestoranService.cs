using System;
namespace ConsoleApp.Service.ServiceInterface
{
    public interface IRestoranService
    {
        public void Create();

        public void Update();

        public void Delete();

        public void Get();

        public void GetAll();
    }
}

