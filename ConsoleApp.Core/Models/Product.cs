using System;
using ConsoleApp.Core.Enums;

namespace ConsoleApp.Core.Models
{
	public class Product : Base
	{
        public double Price { get; set; }

        public Category_Product Category { get; set; }

        private static int _count2 = 0;
        public Product()
		{
            _count2++;
            ID = _count2;
        }
	}
}

