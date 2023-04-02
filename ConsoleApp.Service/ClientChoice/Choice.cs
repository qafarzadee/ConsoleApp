using System;
namespace ConsoleApp.Service.ClientChoice
{
    public static class Select
    {

        public static void Start()
        {
            RestoranService RService = new RestoranService();
            ProductService PService = new ProductService();
        HERE:

            Console.WriteLine("<<MENNU>>");
            Console.WriteLine("Choose one of these operations");
            Console.WriteLine("1-->Operation for restoran");
            Console.WriteLine("2-->Operation for Products");
            int.TryParse(Console.ReadLine(), out int select);

            switch (select)
            {
                case 1:
                THERE:
                    Console.WriteLine("choose one of these");
                    Console.WriteLine("1->Create the restoran");
                    Console.WriteLine("2-->Delete the restoran");
                    Console.WriteLine("3-->Find the restoraan");
                    Console.WriteLine("4-->Show all the restorans");
                    Console.WriteLine("5-->Update the restoran");
                    Console.WriteLine("6-->get back the menu");
                    Console.WriteLine("7-->Create the product");
                    Console.WriteLine("8--Show All the products");
                    Console.WriteLine("9-->Delete the product");
                    Console.WriteLine("10-->Find the product");
                    Console.WriteLine("11-->Update the product");
                    Console.WriteLine("12-->Go back to menu");
                    int choose = int.Parse(Console.ReadLine());

                    switch (choose)
                    {
                        case 1:
                            Console.Clear();
                            RService.Create(); goto THERE;
                        case 2:
                            Console.Clear();
                            RService.Delete(); goto THERE;
                        case 3:
                            Console.Clear();
                            RService.Get(); goto THERE;
                        case 4:
                            Console.Clear();
                            RService.GetAll(); goto THERE;
                        case 5:
                            Console.Clear();
                            RService.Update(); goto THERE;
                        case 6:
                            Console.Clear();
                            goto HERE;
                        case 7:
                            Console.Clear();
                            PService.Create(); goto THERE;
                        case 8:
                            Console.Clear();
                            PService.GetAll(); goto THERE;
                        case 9:
                            Console.Clear();
                            PService.Delete(); goto THERE;
                        case 10:
                            Console.Clear();
                            PService.Get(); goto THERE;
                        case 11:
                            Console.Clear();
                            PService.Update(); goto THERE;
                        case 12:
                            Console.Clear();
                            goto HERE;
                        default:
                            break;
                    }
                    break;
            }


        }
    }
}

