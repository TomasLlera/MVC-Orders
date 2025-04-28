using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Views
{
    public static class ProductView
    {
        public static void ShowProductList(List<Product> productList)
        {
            foreach(Product var in productList)
            {
                ShowProduct(var);
            }
        }
        public static void ShowProduct(Product product)
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine($"Name: {product.Name}");
            Console.WriteLine($"Price: {product.Price}");
            Console.WriteLine($"Final price: {product.FinalPrice()}");
            Console.WriteLine($"Info: {product.Desc}");
            Console.WriteLine("-----------------------");
        }

        public static Product LoadProduct()
        {
            Product temp = new Product();
            Console.WriteLine("Product name?");
            temp.Name = Console.ReadLine();
            Console.WriteLine("Product price?");
            temp.Price = double.Parse(Console.ReadLine());
            Console.WriteLine("Product description?");
            temp.Desc = Console.ReadLine();

            return temp;
        }
        public static List<Product> LoadProductList()
        {
            string resp = "n";
            List<Product> temp = new List<Product>();
            do
            {
                temp.Add(ProductView.LoadProduct());
                Console.WriteLine("Add another product? Y/N");
                resp = Console.ReadLine();
            } while (resp.ToLower() != "n");

            return temp;
        }
    }
}
