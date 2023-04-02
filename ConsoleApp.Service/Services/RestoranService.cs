using System;
using ConsoleApp.Service.ServiceInterface;

namespace ConsoleApp.Service.Services
{
    public class RestoranService : IRestoranService
    {
        public RestoranRepo<Restoran> Repo = new RestoranRepo<Restoran>();

        public void Create()
        {
            Restoran restoran = new Restoran();
            Console.WriteLine("Enter the name of the restoran");
        HERE:
            string name = Console.ReadLine();
            if (Helper.Check(name))
                restoran.Name = name;
            else
                goto HERE;
            Console.WriteLine("Choose catgory of the restoran");
            Console.WriteLine("1-->" + CategoryRestoran.Chinesee);
            Console.WriteLine("2-->" + CategoryRestoran.Italian);
            Console.WriteLine("3-->" + CategoryRestoran.Trkish);
            int.TryParse(Console.ReadLine(), out int select);
            switch (select)
            {
                case 1:
                    restoran.category = CategoryRestoran.Chinesee; break;
                case 2:
                    restoran.category = CategoryRestoran.Italian; break;
                case 3:
                    restoran.category = CategoryRestoran.Trkish; break;
                default:
                    Console.WriteLine("There are only three choices");
                    break;
            }
            Repo.Create(restoran);
        }

        public void Delete()
        {
            Console.WriteLine("Enter id of the restoran that you wanna delete");
            foreach (var item in Repo.GetAll())
            {
                Console.WriteLine($"name-->{item.Name} ID-->{item.ID}");
            }
            int.TryParse(Console.ReadLine(), out int select);
            Restoran restoran = Repo.Get(x => x.ID == select);
            if (restoran.Menu.Count == 0)
                Repo.Delete(restoran);
            else
            {
                Console.WriteLine("If you delete it all the products inside this restoran will be deleted as well are you sure?");
                Console.WriteLine("1-->YES");
                Console.WriteLine("2-->NO");
                int.TryParse(Console.ReadLine(), out int select2);
                switch (select2)
                {
                    case 1:
                        Repo.Delete(restoran); break;
                    case 2:
                        break;
                    default:
                        Console.WriteLine("There are only 2 choices");
                        break;
                }
            }

        }

        public void Get()
        {
            Console.WriteLine("enter id of the restoran that you wanna see");
            int.TryParse(Console.ReadLine(), out int select3);
            Restoran restoran1 = Repo.Get(x => x.ID == select3);
            Console.WriteLine($"name-->{restoran1.Name}  ID-->{restoran1.ID}  CreatedTime-->{restoran1.Createdtime}");
        }

        public void GetAll()
        {
            foreach (var item in Repo.GetAll())
            {
                Console.WriteLine($"name-->{item.Name}  ID--{item.ID} createdtime-->{item.Createdtime}");
            }
        }

        public void Update()
        {
            Console.WriteLine("Enter id of the restoran that you wanna uptade");
            int.TryParse(Console.ReadLine(), out int select4);
            Restoran restoran2 = Repo.Get(S => S.ID == select4);
            if (restoran2 == null)
            {
                Console.WriteLine("There is no any restoran with such ID");
                return;
            }
            Console.WriteLine("what do you wanna change about the resoran?");
            Console.WriteLine("1-->Name");
            Console.WriteLine("2-->Category");
            int.TryParse(Console.ReadLine(), out int choose);
            switch (choose)
            {
                case 1:
                    Console.WriteLine("enter the new name:");
                THERE:
                    string name = Console.ReadLine();
                    if (Helper.Check(name)) restoran2.Name = name;
                    else goto THERE; break;
                case 2:
                    Console.WriteLine("choose the new category");
                    Console.WriteLine("1-->" + CategoryRestoran.Chinesee);
                    Console.WriteLine("2-->" + CategoryRestoran.Italian);
                    Console.WriteLine("3-->" + CategoryRestoran.Trkish);
                    int.TryParse(Console.ReadLine(), out int Choice);

                    switch (Choice)
                    {
                        case 1:
                            if (restoran2.category == CategoryRestoran.Chinesee) Console.WriteLine("Its category is alredy chinesee");
                            else restoran2.category = CategoryRestoran.Chinesee; break;
                        case 2:
                            if (restoran2.category == CategoryRestoran.Italian) Console.WriteLine("Its category is alredy italian");
                            else restoran2.category = CategoryRestoran.Italian; break;
                        case 3:
                            if (restoran2.category == CategoryRestoran.Trkish) Console.WriteLine("Its category is alredy italian");
                            else restoran2.category = CategoryRestoran.Trkish; break;
                        default:
                            Console.WriteLine("there are only 3 choices");
                            break;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}

