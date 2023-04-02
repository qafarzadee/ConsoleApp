using System;
using ConsoleApp.Core.Enums;

namespace ConsoleApp.Core.Models

{
    public class Restaurant : Base
    {
        private static int _count1 = 0;

        public Category_Restaurant category { get; set; }

        public List<Product> Menu;

        public Restaurant()
        {
            _count1++;
            ID = _count1;
            Menu = new List<Product>();
        }
    }
}

