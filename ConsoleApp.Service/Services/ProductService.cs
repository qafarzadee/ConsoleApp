using System;
using ConsoleApp.Service.ServiceInterface;

namespace ConsoleApp.Service.Services
{
    public class ProductService : IProductService
    {
        private static RestoranRepo<Restoran> Repooo = new RestoranRepo<Restoran>();
        public void Create()
        {
            Product product = new Product();
            Console.WriteLine("Enter the name of product that you wanna add");
        AGAIN:
            string name = Console.ReadLine();
            if (Helper.Check(name))
                product.Name = name;
            else
                goto AGAIN;
            Console.WriteLine("enter the price of the product");
        AGAIN2:
            double.TryParse(Console.ReadLine(), out double value);
            while (value <= 0)
            {
                Console.WriteLine("price must be higher than 0 please enter again");
                goto AGAIN2;
            }
            Console.WriteLine("choose category of the product");
            Console.WriteLine("1-->" + CategoryProduct.FastFood);
            Console.WriteLine("2-->" + CategoryProduct.Salty);
            Console.WriteLine("3-->" + CategoryProduct.Desert);
            int.TryParse(Console.ReadLine(), out int request);

            switch (request)
            {
                case 1:
                    product.Category = CategoryProduct.FastFood; break;
                case 2:
                    product.Category = CategoryProduct.Salty; break;
                case 3:
                    product.Category = CategoryProduct.Desert; break;
                default:
                    Console.WriteLine("there are only three three choices");
                    break;
            }

            Console.WriteLine("Which restoran do you wanna add this product?");
            for (int i = 0; i < Repooo.GetAll().Count; i++)
            {
                Console.WriteLine($"name-->{Repooo.GetAll()[i].Name} ID-->{Repooo.GetAll()[i].ID}");
            }
        THERE:
            int.TryParse(Console.ReadLine(), out int selectt);
            Restoran restoran = Repooo.Get(x => x.ID == selectt);
            if (restoran == null)
            {
                Console.WriteLine("There is no any restoran with such id choose again");
                goto THERE;
            }
            restoran.Menu.Add(product);

        }

        public void Delete()
        {
            Console.WriteLine("wwhich restoran you wanna delete from?");
            for (int i = 0; i < Repooo.GetAll().Count; i++)
            {
                Console.WriteLine($"name-->{Repooo.GetAll()[i].Name}  IDD-->{Repooo.GetAll()[i].ID}");
            }
        THEREE:
            int.TryParse(Console.ReadLine(), out int selecttt);
            Restoran restoran = Repooo.Get(x => x.ID == selecttt);
            if (restoran == null)
            {
                Console.WriteLine("there is no such a restoran please enter again");
                goto THEREE;
            }
            Console.WriteLine("choose the product that you wanna delete");
            for (int i = 0; i < restoran.Menu.Count; i++)
            {
                Console.WriteLine($"name--<{restoran.Menu[i].Name}  price-->{restoran.Menu[i].Price}  ID-->{restoran.Menu[i].ID}");
            }
            int.TryParse(Console.ReadLine(), out int selectt);
            for (int i = 0; i < restoran.Menu.Count; i++)
            {
                if (restoran.Menu[i].ID == selectt)
                {
                    restoran.Menu.Remove(restoran.Menu[i]);
                }
            }
        }

        public void Get()
        {
            Console.WriteLine("in which restoran do you wanna find the product?");
            foreach (var item in Repooo.GetAll())
            {
                Console.WriteLine($"name-->{item.Name}  ID-->{item.ID}");
            }
        AGAIN10:
            int.TryParse(Console.ReadLine(), out int choice2);
            Restoran restoran10 = Repooo.Get(x => x.ID == choice2);
            if (restoran10 == null)
            {
                Console.WriteLine("there is no such a restoran please enter again");
                goto AGAIN10;
            }
            Console.WriteLine("enter id of the product that you waanna find");
            int.TryParse(Console.ReadLine(), out int IdProduct);
            for (int i = 0; i < restoran10.Menu.Count; i++)
            {
                if (restoran10.Menu[i].ID == IdProduct)
                {
                    Console.WriteLine($"name-->{restoran10.Menu[i].Name}  price-->{restoran10.Menu[i].Price} createdtime-->{restoran10.Menu[i].Createdtime}");
                }
            }
        }

        public void GetAll()
        {
            Console.WriteLine("which restoran products do you wanna see?");
            foreach (var item in Repooo.GetAll())
            {
                Console.WriteLine($"name-->{item.Name}  ID-->{item.ID}");
            }
        HEREWEGO:
            int.TryParse(Console.ReadLine(), out int IdRestoran);
            Restoran restoran = Repooo.Get(x => x.ID == IdRestoran);
            if (restoran == null)
            {
                Console.WriteLine("there is no such a restoran please enter again");
                goto HEREWEGO;
            }
            foreach (var item in restoran.Menu)
            {
                Console.WriteLine($"name-->{item.Name}  price-->{item.Price}  Id-->{item.ID}  added time-->{item.Createdtime}");
            }
        }

        public void Update()
        {
            Console.WriteLine("in which restoran do you wanna update?");
            for (int i = 0; i < Repooo.GetAll().Count; i++)
            {
                Console.WriteLine($"name-->{Repooo.GetAll()[i].Name}  ID-->{Repooo.GetAll()[i].ID}");
            }
            int.TryParse(Console.ReadLine(), out int result);
        YEAP:
            Restoran restorann = Repooo.Get(W => W.ID == result);
            if (restorann == null)
            {
                Console.WriteLine("there is no such a restoran please enter again");
                goto YEAP;
            }
            Console.WriteLine("choose the product that you wanna update");
            foreach (var item in restorann.Menu)
            {
                Console.WriteLine($"name-->{item.Name}  id-->{item.ID}");
            }
            int.TryParse(Console.ReadLine(), out int select31);
            foreach (var item in restorann.Menu)
            {
                if (item.ID == select31)
                {
                    Console.WriteLine("What do you wanna change about the product?");
                    Console.WriteLine("1-->Name");
                    Console.WriteLine("2-->Category");
                    Console.WriteLine("3-->Price");
                    int select = Convert.ToInt32(Console.ReadLine());
                    switch (select)
                    {
                        case 1:
                            Console.WriteLine("enter the new name of the product");
                        WWWW:
                            string NewName = Console.ReadLine();
                            if (Helper.Check(NewName))
                                item.Name = NewName;
                            else
                                goto WWWW; break;
                        case 2:
                            Console.WriteLine("enter the new category");
                            Console.WriteLine("1-->" + CategoryProduct.FastFood);
                            Console.WriteLine("2-->" + CategoryProduct.Desert);
                            Console.WriteLine("3-->" + CategoryProduct.Salty);
                            int.TryParse(Console.ReadLine(), out int select21);

                            switch (select21)
                            {
                                case 1:
                                    if (item.Category == CategoryProduct.FastFood)
                                        Console.WriteLine("its category is alredy fastfood");
                                    else
                                        item.Category = CategoryProduct.FastFood; break;
                                case 2:
                                    if (item.Category == CategoryProduct.Desert)
                                        Console.WriteLine("its category is alredy desert");
                                    else
                                        item.Category = CategoryProduct.Desert; break;
                                case 3:
                                    if (item.Category == CategoryProduct.Salty)
                                        Console.WriteLine("its category is alredy salty");
                                    else
                                        item.Category = CategoryProduct.Salty; break;
                                default:
                                    Console.WriteLine("there are only three choices");
                                    break;
                            }
                            break;
                        case 3:
                            Console.WriteLine("enter the new price");
                            double NewPrice = Convert.ToDouble(Console.ReadLine());
                            item.Price = NewPrice; break;
                        default:
                            Console.WriteLine("there are only 3 choices");
                            break;
                    }
                }
            }
        }
    }
}

