using System;
namespace ConsoleApp.Service
{
    public static class Helper
    {
        public static bool Check(string name)
        {
            bool status = true;
            for (int i = 0; i < name.Length; i++)
            {
                if (char.IsDigit(name[i]))
                {
                    status = false;
                    Console.WriteLine("You can't add any digit to the name");
                    break;
                }
            }
            if (!char.IsUpper(name[0]))
            {
                status = false; Console.WriteLine("The fisrt letter of the name has to be upper");
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                status = false; Console.WriteLine("You can't add any empthy space to the name");
            }
            return status;
        }
    }
}

